using System;
using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Moq;
using NUnit.Framework;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ADMPlugin.Json;
using AgGateway.ADAPT.ADMPlugin.Protobuf;

namespace AgGateway.ADAPT.PluginTest.Serializers
{
  [TestFixture]
  public class AdmSerializerTest
  {
    private string _tempPath;
    private ApplicationDataModel.ADM.ApplicationDataModel _dataModel;

    private Mock<IVersionInfoSerializer> _versionSerializerMock;
    private Mock<ISerializer<List<ProprietaryValue>>> _propriataryValuesSerializerMock;
    private Mock<ISerializer<Catalog>> _catalogSearializerMock;
    private Mock<ISerializer<Documents>> _documentsSerializerMock;
    private Mock<ISerializer<IEnumerable<ReferenceLayer>>> _referenceLayersSerializerMock;

    [SetUp]
    public void Setup()
    {
      _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

      _dataModel = new ApplicationDataModel.ADM.ApplicationDataModel();
      _dataModel.ProprietaryValues = new List<ProprietaryValue>();
      _dataModel.Catalog = new Catalog();
      _dataModel.Documents = new Documents();
      _dataModel.ReferenceLayers = new List<ReferenceLayer>();

      _versionSerializerMock = new Mock<IVersionInfoSerializer>();
      _propriataryValuesSerializerMock = new Mock<ISerializer<List<ProprietaryValue>>>();
      _catalogSearializerMock = new Mock<ISerializer<Catalog>>();
      _documentsSerializerMock = new Mock<ISerializer<Documents>>();
      _referenceLayersSerializerMock = new Mock<ISerializer<IEnumerable<ReferenceLayer>>>();
    }

    [Test]
    public void EmptyConstructorWorks()
    {
      var admSerializer = new AdmSerializer();

      Assert.IsTrue(true);
    }

    [Test]
    public void SimpleConstructorWorks()
    {
      var admSerializer = new AdmSerializer(SerializationVersionEnum.V2);

      Assert.IsTrue(true);
    }

    [Test]
    public void AfterConstructorVersionSerializerPropertyIsDefined()
    {
      var admSerializer = new AdmSerializer(_versionSerializerMock.Object, _propriataryValuesSerializerMock.Object, _catalogSearializerMock.Object, _documentsSerializerMock.Object, _referenceLayersSerializerMock.Object, SerializationVersionEnum.V2);
      var result = admSerializer.VersionSerializer;

      Assert.AreSame(_versionSerializerMock.Object, result);
    }

    [Test]
    public void GivenCardPathWhenSerializeWithV1AsDefaultThenV1SerializationHappens()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);

      var admSerializer = new AdmSerializer(_versionSerializerMock.Object, _propriataryValuesSerializerMock.Object, _catalogSearializerMock.Object, _documentsSerializerMock.Object, _referenceLayersSerializerMock.Object, SerializationVersionEnum.V1);
      admSerializer.Serialize(_dataModel, _tempPath);

      _propriataryValuesSerializerMock.Verify(x => x.Serialize(BaseJsonSerializer.Instance, _dataModel.ProprietaryValues, dataPath));
      _catalogSearializerMock.Verify(x => x.Serialize(BaseJsonSerializer.Instance, _dataModel.Catalog, dataPath));
      _documentsSerializerMock.Verify(x => x.Serialize(BaseProtobufSerializer.InstanceV1, _dataModel.Documents, dataPath));
      _referenceLayersSerializerMock.Verify(x => x.Serialize(BaseProtobufSerializer.InstanceV1, _dataModel.ReferenceLayers, dataPath));
      _versionSerializerMock.Verify(x => x.Serialize(SerializationVersionEnum.V1, dataPath));
    }

    [Test]
    public void GivenCardPathWhenSerializeWithV2AsDefaultThenV2SerializationHappens()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);

      var admSerializer = new AdmSerializer(_versionSerializerMock.Object, _propriataryValuesSerializerMock.Object, _catalogSearializerMock.Object, _documentsSerializerMock.Object, _referenceLayersSerializerMock.Object, SerializationVersionEnum.V2);
      admSerializer.Serialize(_dataModel, _tempPath);

      _propriataryValuesSerializerMock.Verify(x => x.Serialize(BaseProtobufSerializer.InstanceV2, _dataModel.ProprietaryValues, dataPath));
      _catalogSearializerMock.Verify(x => x.Serialize(BaseProtobufSerializer.InstanceV2, _dataModel.Catalog, dataPath));
      _documentsSerializerMock.Verify(x => x.Serialize(BaseProtobufSerializer.InstanceV2, _dataModel.Documents, dataPath));
      _referenceLayersSerializerMock.Verify(x => x.Serialize(BaseProtobufSerializer.InstanceV2, _dataModel.ReferenceLayers, dataPath));
      _versionSerializerMock.Verify(x => x.Serialize(SerializationVersionEnum.V2, dataPath));
    }

    [Test]
    public void GivenCardPathWithNoVersionInfoWhenDeserializeThenV1DeserializationHappens()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);

      var admSerializer = new AdmSerializer(_versionSerializerMock.Object, _propriataryValuesSerializerMock.Object, _catalogSearializerMock.Object, _documentsSerializerMock.Object, _referenceLayersSerializerMock.Object, SerializationVersionEnum.V1);
      admSerializer.Deserialize(_tempPath);

      _propriataryValuesSerializerMock.Verify(x => x.Deserialize(BaseJsonSerializer.Instance, dataPath));
      _catalogSearializerMock.Verify(x => x.Deserialize(BaseJsonSerializer.Instance, dataPath));
      _documentsSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV1, dataPath));
      _referenceLayersSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV1, dataPath));
    }

    [Test]
    public void GivenCardPathWithV1VersionInfoWhenDeserializeThenV1DeserializationHappens()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);
      var versionInfo = new AdmVersionInfo { SerializationVersion = SerializationVersionEnum.V1 };
      _versionSerializerMock.Setup(x => x.Deserialize(dataPath)).Returns(versionInfo);

      var admSerializer = new AdmSerializer(_versionSerializerMock.Object, _propriataryValuesSerializerMock.Object, _catalogSearializerMock.Object, _documentsSerializerMock.Object, _referenceLayersSerializerMock.Object, SerializationVersionEnum.V1);
      admSerializer.Deserialize(_tempPath);

      _propriataryValuesSerializerMock.Verify(x => x.Deserialize(BaseJsonSerializer.Instance, dataPath));
      _catalogSearializerMock.Verify(x => x.Deserialize(BaseJsonSerializer.Instance, dataPath));
      _documentsSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV1, dataPath));
      _referenceLayersSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV1, dataPath));
    }

    [Test]
    public void GivenCardPathWithV2VersionInfoWhenDeserializeThenV2DeserializationHappens()
    {
      var dataPath = Path.Combine(_tempPath, DatacardConstants.DataFolder);
      var versionInfo = new AdmVersionInfo { SerializationVersion = SerializationVersionEnum.V2 };
      _versionSerializerMock.Setup(x => x.Deserialize(dataPath)).Returns(versionInfo);

      var admSerializer = new AdmSerializer(_versionSerializerMock.Object, _propriataryValuesSerializerMock.Object, _catalogSearializerMock.Object, _documentsSerializerMock.Object, _referenceLayersSerializerMock.Object, SerializationVersionEnum.V2);
      admSerializer.Deserialize(_tempPath);

      _propriataryValuesSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV2, dataPath));
      _catalogSearializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV2, dataPath));
      _documentsSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV2, dataPath));
      _referenceLayersSerializerMock.Verify(x => x.Deserialize(BaseProtobufSerializer.InstanceV2, dataPath));
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
