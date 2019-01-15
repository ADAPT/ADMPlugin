using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AgGateway.ADAPT.ADMPlugin.Json;
using AgGateway.ADAPT.ADMPlugin.Protobuf;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
  public class AdmSerializer : IAdmSerializer
  {
    private readonly IVersionInfoSerializer _versionSerializer;
    private readonly ISerializer<List<ProprietaryValue>> _propriataryValuesSerializer;
    private readonly ISerializer<Catalog> _catalogSerializer;
    private readonly ISerializer<Documents> _documentsSerializer;
    private readonly ISerializer<IEnumerable<ReferenceLayer>> _referenceLayersSerializer;

    private readonly SerializationVersionEnum _defaultSerializationVersion;

    public AdmSerializer() : this(new VersionInfoSerializer(), new SimpleSerializer<List<ProprietaryValue>>(DatacardConstants.ProprietaryValuesFile), new SimpleSerializer<Catalog>(DatacardConstants.CatalogFile), new DocumentsSerializer(), new ReferenceLayersSerializer(), SerializationVersionEnum.V2)
    {
    }

    public AdmSerializer(SerializationVersionEnum defaultSerializationVersion) : this(new VersionInfoSerializer(), new SimpleSerializer<List<ProprietaryValue>>(DatacardConstants.ProprietaryValuesFile), new SimpleSerializer<Catalog>(DatacardConstants.CatalogFile), new DocumentsSerializer(), new ReferenceLayersSerializer(), defaultSerializationVersion)
    {
    }

    public AdmSerializer(IVersionInfoSerializer versionSerializer, ISerializer<List<ProprietaryValue>> propriataryValuesSerializer, ISerializer<Catalog> catalogSerializer, ISerializer<Documents> documentsSerializer, ISerializer<IEnumerable<ReferenceLayer>> referenceLayersSerializer, SerializationVersionEnum defaultSerializationVersion)
    {
      _versionSerializer = versionSerializer;
      _propriataryValuesSerializer = propriataryValuesSerializer;
      _catalogSerializer = catalogSerializer;
      _documentsSerializer = documentsSerializer;
      _referenceLayersSerializer = referenceLayersSerializer;
      _defaultSerializationVersion = defaultSerializationVersion;
    }

    public IVersionInfoSerializer VersionSerializer => _versionSerializer;

    public void Serialize(ApplicationDataModel.ADM.ApplicationDataModel dataModel, string path)
    {
      var dataPath = Path.Combine(path, DatacardConstants.DataFolder);
      if (!Directory.Exists(dataPath))
      {
        Directory.CreateDirectory(dataPath);
      }

      _propriataryValuesSerializer.Serialize(GetPropriataryValuesBaseSerializer(_defaultSerializationVersion), dataModel.ProprietaryValues, dataPath);
      _catalogSerializer.Serialize(GetCatalogBaseSerializer(_defaultSerializationVersion), dataModel.Catalog, dataPath);
      _documentsSerializer.Serialize(GetDocumentsBaseSerializer(_defaultSerializationVersion), dataModel.Documents, dataPath);
      _referenceLayersSerializer.Serialize(GetReferenceLayersBaseSerializer(_defaultSerializationVersion), dataModel.ReferenceLayers, dataPath);
      _versionSerializer.Serialize(_defaultSerializationVersion, dataPath);
    }

    public ApplicationDataModel.ADM.ApplicationDataModel Deserialize(string path)
    {
      var dataPath = Path.Combine(path, DatacardConstants.DataFolder);
      var serializationVersion = GetDeserializationVersion(dataPath);

      return new ApplicationDataModel.ADM.ApplicationDataModel
      {
        ProprietaryValues = _propriataryValuesSerializer.Deserialize(GetPropriataryValuesBaseSerializer(serializationVersion), dataPath),
        Catalog = _catalogSerializer.Deserialize(GetCatalogBaseSerializer(serializationVersion), dataPath),
        Documents = _documentsSerializer.Deserialize(GetDocumentsBaseSerializer(serializationVersion), dataPath),
        ReferenceLayers = _referenceLayersSerializer.Deserialize(GetReferenceLayersBaseSerializer(serializationVersion), dataPath)
      };
    }

    private SerializationVersionEnum GetDeserializationVersion(string dataPath)
    {
      var versionInfo = _versionSerializer.Deserialize(dataPath);

      if (versionInfo == null || versionInfo.SerializationVersion == SerializationVersionEnum.Unknown)
      {
        return SerializationVersionEnum.V1;
      }

      return versionInfo.SerializationVersion;
    }

    private IBaseSerializer GetPropriataryValuesBaseSerializer(SerializationVersionEnum version)
    {
      if (version == SerializationVersionEnum.V1)
      {
        return BaseJsonSerializer.Instance;
      }

      return BaseProtobufSerializer.InstanceV2;
    }

    private IBaseSerializer GetCatalogBaseSerializer(SerializationVersionEnum version)
    {
      if (version == SerializationVersionEnum.V1)
      {
        return BaseJsonSerializer.Instance;
      }

      return BaseProtobufSerializer.InstanceV2;
    }

    private IBaseSerializer GetDocumentsBaseSerializer(SerializationVersionEnum version)
    {
      if (version == SerializationVersionEnum.V1)
      {
        return BaseProtobufSerializer.InstanceV1;
      }

      return BaseProtobufSerializer.InstanceV2;
    }

    private IBaseSerializer GetReferenceLayersBaseSerializer(SerializationVersionEnum version)
    {
      if (version == SerializationVersionEnum.V1)
      {
        return BaseProtobufSerializer.InstanceV1;
      }

      return BaseProtobufSerializer.InstanceV2;
    }
  }
}
