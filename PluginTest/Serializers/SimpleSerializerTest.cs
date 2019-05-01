using System;
using System.IO;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest.Serializers
{
  [TestFixture]
  public class SimpleSerializerTest
  {
    private string _tempPath;

    private Mock<IBaseSerializer> _baseSerializerMock;

    [SetUp]
    public void Setup()
    {
      _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

      _baseSerializerMock = new Mock<IBaseSerializer>();
    }

    [Test]
    public void SerializeDoesNothingIfContentIsNull()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);

      var serializer = new SimpleSerializer<Catalog>(DatacardConstants.CatalogFile);
      serializer.Serialize(_baseSerializerMock.Object, null, dataPath);

      _baseSerializerMock.Verify(x => x.Serialize(It.IsAny<Catalog>(), It.IsAny<string>()), Times.Never());
    }

    [Test]
    public void SerializeCallsBaseSerializerIfContentIsNotNull()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);
      var catalog = new Catalog();

      var serializer = new SimpleSerializer<Catalog>(DatacardConstants.CatalogFile);
      serializer.Serialize(_baseSerializerMock.Object, catalog, dataPath);

      _baseSerializerMock.Verify(x => x.Serialize(catalog, Path.Combine(dataPath, DatacardConstants.CatalogFile)), Times.Once());
    }

    [Test]
    public void DeserializeDoesNothingIfFileDoesNotExist()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);
      Directory.CreateDirectory(dataPath);

      var serializer = new SimpleSerializer<Catalog>(DatacardConstants.CatalogFile);
      serializer.Deserialize(_baseSerializerMock.Object, dataPath);

      _baseSerializerMock.Verify(x => x.Deserialize<Catalog>(It.IsAny<string>()), Times.Never());
    }

    [Test]
    public void DeserializeCallsBaseSerializerIfFileExists()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);
      Directory.CreateDirectory(dataPath);
      var filePath = Path.Combine(dataPath, DatacardConstants.CatalogFile);
      File.WriteAllText(filePath, string.Empty);

      var serializer = new SimpleSerializer<Catalog>(DatacardConstants.CatalogFile);
      serializer.Deserialize(_baseSerializerMock.Object, dataPath);

      _baseSerializerMock.Verify(x => x.Deserialize<Catalog>(filePath), Times.Once());
    }

    [TearDown]
    public void Teardown()
    {
      if (Directory.Exists(_tempPath))
      {
        Directory.Delete(_tempPath, true);
      }
    }
  }
}
