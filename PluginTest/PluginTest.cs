using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using AgGateway.ADAPT.TestUtilities;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ADMPlugin.Models;

namespace AgGateway.ADAPT.PluginTest
{
  [TestFixture]
  public class PluginTest
  {
    private Version _currentVersion = typeof(Plugin).Assembly.GetName().Version;
    private string _cardPath;
    private string _tempPath;

    private Mock<IVersionInfoSerializer> _versionInfoSerializerMock;
    private Mock<IAdmSerializer> _admSerializerMock;

    [SetUp]
    public void Setup()
    {
      _cardPath = DatacardUtility.WriteDatacard("TestDatacard_V1");
      _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

      var versionInfo = new AdmVersionInfo { PluginVersion = _currentVersion, SerializationVersion = SerializationVersionEnum.V1 };
      var versionInfoFileName = Path.Combine(_cardPath, DatacardConstants.DataFolder, DatacardConstants.VersionFile);

      _versionInfoSerializerMock = new Mock<IVersionInfoSerializer>();
      _versionInfoSerializerMock.Setup(x => x.Deserialize(versionInfoFileName)).Returns(versionInfo);

      _admSerializerMock = new Mock<IAdmSerializer>();
      _admSerializerMock.Setup(x => x.VersionSerializer).Returns(_versionInfoSerializerMock.Object);
    }

    [Test]
    public void GivenPluginWhenGetNameThenAdmIsReturned()
    {
      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.Name;

      Assert.AreEqual("ADM", result);
    }

    [Test]
    public void GivenPluginWhenGetVersionThenVersionIsReturned()
    {
      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.Version;

      Assert.AreEqual(_currentVersion.ToString(), result);
    }

    [Test]
    public void GivenPluginWhenGetOwnerThenAgGatewayIsReturned()
    {
      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.Owner;

      Assert.AreEqual("AgGateway", result);
    }

    [Test]
    public void GivenPluginAndDataCardWhenIsDataCardSupportedThenTrueIsReturned()
    {
      var sourcePath = Path.Combine(_cardPath, DatacardConstants.DataFolder);
      Directory.CreateDirectory(sourcePath);

      using (File.Create(Path.Combine(sourcePath, "TestFile.adm")))
      {
        var plugin = new Plugin(_admSerializerMock.Object);
        var result = plugin.IsDataCardSupported(_cardPath);

        Assert.IsTrue(result);
      }
    }

    [Test]
    public void GivenPluginWithInvalidStructureWhenIsDataCardSupportedThenFalseIsReturned()
    {
      Directory.Delete(_cardPath, true);
      _cardPath = DatacardUtility.WriteDatacard("IncorrectHierarchy_V1");

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.IsFalse(result);
    }

    [Test]
    public void GivenPluginWithInvalidFileWhenIsDataCardSupportedThenFalseIsReturned()
    {
      Directory.Delete(_cardPath, true);
      _cardPath = DatacardUtility.WriteDatacard("IncorrectFiles_V1");

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.IsFalse(result);
    }

    [Test]
    public void GivenPluginWhenValidateDataOnCardThenNewListReturned()
    {
      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.ValidateDataOnCard(_cardPath);

      Assert.IsEmpty(result);
    }

    [Test]
    public void GivenPluginWhenGetPropertiesThenNewPropertiesIsReturned()
    {
      var sourcePath = Path.Combine(_cardPath, DatacardConstants.DataFolder);
      Directory.CreateDirectory(sourcePath);

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.GetProperties(sourcePath);

      Assert.IsInstanceOf<Properties>(result);
    }

    [Test]
    public void GivenPluginAndCardPathWhenExportThenAdmSerializerSerializeCalled()
    {
      var dataModel = new ApplicationDataModel.ADM.ApplicationDataModel();

      var plugin = new Plugin(_admSerializerMock.Object);
      plugin.Export(dataModel, _cardPath);

      _admSerializerMock.Verify(x => x.Serialize(dataModel, _cardPath));
    }

    [Test]
    public void GivenCardPathWhenImportThenAdmSerializerDeserializeCalled()
    {
      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.Import(_cardPath);

      _admSerializerMock.Verify(x => x.Deserialize(_cardPath));
    }

    [Test]
    public void GivenCardPathWhenIsSupportedThenTrueIfNoPluginVersion()
    {
      var versionInfo = new AdmVersionInfo
      {
        PluginVersion = null,
        SerializationVersion = SerializationVersionEnum.V1
      };
      var expectedFilename = Path.Combine(_cardPath, DatacardConstants.DataFolder, DatacardConstants.VersionFile);
      _versionInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(versionInfo);

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.That(result, Is.True);
    }

    [Test]
    public void GivenCardPathWhenIsSupportedThenTrueIfDataMajorVersionMatches()
    {
      var pluginVersion = typeof(Plugin).Assembly.GetName().Version;
      var dataVersion = new Version(pluginVersion.Major, pluginVersion.Minor);

      var versionInfo = new AdmVersionInfo
      {
        PluginVersion = dataVersion,
        SerializationVersion = SerializationVersionEnum.V1
      };
      var expectedFilename = Path.Combine(_cardPath, DatacardConstants.DataFolder, DatacardConstants.VersionFile);
      _versionInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(versionInfo);

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.That(result, Is.True);
    }

    [Test]
    public void GivenCardPathWhenIsSupportedThenTrueIfDataMajorVersionLower()
    {
      var pluginVersion = typeof(Plugin).Assembly.GetName().Version;
      var dataVersion = new Version(pluginVersion.Major - 1, pluginVersion.Minor);

      var versionInfo = new AdmVersionInfo
      {
        PluginVersion = dataVersion,
        SerializationVersion = SerializationVersionEnum.V1
      };
      var expectedFilename = Path.Combine(_cardPath, DatacardConstants.DataFolder, DatacardConstants.VersionFile);
      _versionInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(versionInfo);

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.That(result, Is.True);
    }

    [Test]
    public void GivenCardPathWhenIsSupportedThenFalseIfDataMajorVersionGreater()
    {
      var pluginVersion = typeof(Plugin).Assembly.GetName().Version;
      var dataVersion = new Version(pluginVersion.Major + 1, pluginVersion.Minor);

      var versionInfo = new AdmVersionInfo
      {
        PluginVersion = dataVersion,
        SerializationVersion = SerializationVersionEnum.V1
      };
      var expectedFilename = Path.Combine(_cardPath, DatacardConstants.DataFolder, DatacardConstants.VersionFile);
      _versionInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(versionInfo);

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.That(result, Is.False);
    }

    [Test]
    public void GivenCardPathWithoutVersionFileWhenIsSupportedThenTrue()
    {
      _versionInfoSerializerMock.Setup(x => x.Deserialize(It.IsAny<string>())).Returns(null as AdmVersionInfo);

      var plugin = new Plugin(_admSerializerMock.Object);
      var result = plugin.IsDataCardSupported(_cardPath);

      Assert.That(result, Is.True);
    }

    [TearDown]
    public void Teardown()
    {
      Directory.Delete(_cardPath, true);
      if (Directory.Exists(_tempPath))
      {
        Directory.Delete(_tempPath, true);
      }
    }
  }
}
