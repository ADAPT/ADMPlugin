using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;
using AgGateway.ADAPT.TestUtilities;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ADMPlugin.Protobuf;

namespace AgGateway.ADAPT.PluginTest.Protobuf
{
  [TestFixture]
  public class BaseProtobufSerializerTest
  {
    private string _tempPath;

    [SetUp]
    public void Setup()
    {
      _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
    }

    [Test]
    public void HasStaticV1Instance()
    {
      Assert.IsNotNull(BaseProtobufSerializer.InstanceV1);
    }

    [Test]
    public void HasStaticV2Instance()
    {
      Assert.IsNotNull(BaseProtobufSerializer.InstanceV2);
    }

    [Test]
    public void SerializeCreatesDestinationPath()
    {
      var filePath = Path.Combine(_tempPath, "adm", "Catalog.adm");
      var catalog = new Catalog();

      var protobufSerializer = BaseProtobufSerializer.InstanceV1;
      protobufSerializer.Serialize(catalog, filePath);

      Assert.IsTrue(Directory.Exists(Path.GetDirectoryName(filePath)));
    }

    [Test]
    public void CanSerializeAndDeserializeV1()
    {
      var filePath = Path.Combine(_tempPath, "adm", "Catalog.adm");
      var catalog = new Catalog();
      catalog.Growers.Add(new ApplicationDataModel.Logistics.Grower { Name = "TEST" });

      var protobufSerializer = BaseProtobufSerializer.InstanceV1;
      protobufSerializer.Serialize(catalog, filePath);
      var result = protobufSerializer.Deserialize<Catalog>(filePath);

      Assert.AreEqual(catalog.Growers.First().Name, result.Growers.First().Name);
    }

    [Test]
    public void CanSerializeAndDeserializeV2()
    {
      var filePath = Path.Combine(_tempPath, "adm", "Catalog.adm");
      var catalog = new Catalog();
      catalog.Growers.Add(new ApplicationDataModel.Logistics.Grower { Name = "TEST" });

      var protobufSerializer = BaseProtobufSerializer.InstanceV2;
      protobufSerializer.Serialize(catalog, filePath);
      var result = protobufSerializer.Deserialize<Catalog>(filePath);

      Assert.AreEqual(catalog.Growers.First().Name, result.Growers.First().Name);
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
