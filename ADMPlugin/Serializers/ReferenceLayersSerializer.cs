using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin.Converters;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
  public class ReferenceLayersSerializer : ISerializer<IEnumerable<ReferenceLayer>>
  {
    private readonly IReferenceLayerConverter _protobufReferenceLayerConverter;

    public ReferenceLayersSerializer() : this(new ReferenceLayerConverter())
    {
    }

    public ReferenceLayersSerializer(IReferenceLayerConverter protobufReferenceLayerConverter)
    {
      _protobufReferenceLayerConverter = protobufReferenceLayerConverter;
    }

    public void Serialize(IBaseSerializer baseSerializer, IEnumerable<ReferenceLayer> referenceLayers, string path)
    {
      if (referenceLayers == null)
      {
        return;
      }

      var serializableReferenceLayers = referenceLayers.Select(x => _protobufReferenceLayerConverter.ConvertToSerializableReferenceLayer(x)).ToList();
      baseSerializer.Serialize(serializableReferenceLayers, Path.Combine(path, DatacardConstants.ReferenceLayersFile));
    }

    public IEnumerable<ReferenceLayer> Deserialize(IBaseSerializer baseSerializer, string path)
    {
      var filePath = Path.Combine(path, DatacardConstants.ReferenceLayersFile);

      if (!File.Exists(filePath))
      {
        return new List<ReferenceLayer>();
      }

      var serializableReferenceLayers = baseSerializer.Deserialize<List<SerializableReferenceLayer>>(filePath);

      return serializableReferenceLayers.Select(x => _protobufReferenceLayerConverter.ConvertToReferenceLayer(x));
    }
  }
}
