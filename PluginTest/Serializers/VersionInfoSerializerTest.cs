using System;
using System.IO;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest.Serializers
{
  [TestFixture]
  public class VersionInfoSerializerTest
  {
    private string _tempPath;

    [SetUp]
    public void Setup()
    {
      _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    }

    [Test]
    public void SerializeCreatesDestinationPath()
    {
      var serializer = new VersionInfoSerializer();
      serializer.Serialize(SerializationVersionEnum.V1, _tempPath);

      Assert.IsTrue(Directory.Exists(_tempPath));
    }

    [Test]
    public void GivenFilenameWhenWriteFileThenFileExists()
    {
      var serializer = new VersionInfoSerializer();
      serializer.Serialize(SerializationVersionEnum.V1, _tempPath);

      Assert.That(File.Exists(Path.Combine(_tempPath, DatacardConstants.VersionFile)), Is.True);
    }

    [Test]
    public void GivenFilenameWhenSerializeDeserializeThenFileContainsCorrectVersionInfo()
    {
      var serializationVersion = SerializationVersionEnum.V1;
      var expectedVersion = typeof(Plugin).Assembly.GetName().Version;

      var serializer = new VersionInfoSerializer();
      serializer.Serialize(serializationVersion, _tempPath);
      var result = serializer.Deserialize(_tempPath);

      Assert.That(result.PluginVersion, Is.EqualTo(expectedVersion));
      Assert.That(result.SerializationVersion, Is.EqualTo(serializationVersion));
    }

    [Test]
    public void GivenFilenameWhenDeserialzieThenCorrectVersionInfo()
    {
      var versionInfo = new AdmVersionInfo
      {
        PluginVersion = new Version("1.2.3.4"),
        SerializationVersion = SerializationVersionEnum.V1
      };
      Directory.CreateDirectory(_tempPath);
      File.WriteAllText(Path.Combine(_tempPath, DatacardConstants.VersionFile), JsonConvert.SerializeObject(versionInfo));

      var serializer = new VersionInfoSerializer();
      var result = serializer.Deserialize(_tempPath);

      Assert.That(result.PluginVersion, Is.EqualTo(versionInfo.PluginVersion));
      Assert.That(result.SerializationVersion, Is.EqualTo(versionInfo.SerializationVersion));
    }

    [Test]
    public void GivenFilenameThatDoesNotExistWhenReadThenNull()
    {
      var filename = Path.Combine(_tempPath, DatacardConstants.VersionFile);

      var serializer = new VersionInfoSerializer();
      var model = serializer.Deserialize(filename);

      Assert.That(model, Is.Null);
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
