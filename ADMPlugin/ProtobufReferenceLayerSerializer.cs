using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;

namespace AgGateway.ADAPT.ADMPlugin
{
    public interface IProtobufReferenceLayerSerializer
    {
        void Export(string filepath, string filename, IEnumerable<ReferenceLayer> referenceLayers);
        IEnumerable<ReferenceLayer> Import(string filepath, string filename);

    }

    public class ProtobufReferenceLayerSerializer : IProtobufReferenceLayerSerializer
    {
        private readonly IProtobufReferenceLayerConverter _protobufReferenceLayerConverter;
        private readonly IProtobufSerializer _protobufSerializer;

        public ProtobufReferenceLayerSerializer() : this(new ProtobufReferenceLayerConverter(), new ProtobufSerializer())
        {
            
        }

        public ProtobufReferenceLayerSerializer(IProtobufReferenceLayerConverter protobufReferenceLayerConverter, IProtobufSerializer protobufSerializer)
        {
            _protobufReferenceLayerConverter = protobufReferenceLayerConverter;
            _protobufSerializer = protobufSerializer;
        }

        public void Export(string filepath, string filename, IEnumerable<ReferenceLayer> referenceLayers)
        {
            if (referenceLayers == null)
                return;
            var serializableReferenceLayer = referenceLayers.Select(x => _protobufReferenceLayerConverter.ConvertToSerializableReferenceLayer(x)).ToList();
            _protobufSerializer.Write(Path.Combine(filepath, filename), serializableReferenceLayer);
        }

        public IEnumerable<ReferenceLayer> Import(string filepath, string filename)
        {
            var file = Path.Combine(filepath, filename);

            if (!File.Exists(file))
                yield break;

            var serializableReferenceLayers = _protobufSerializer.Read<List<SerializableReferenceLayer>>(file);

            foreach (var serializableReferenceLayer in serializableReferenceLayers)
            {
                yield return _protobufReferenceLayerConverter.ConvertToReferenceLayer(serializableReferenceLayer);
            }

        }
    }
}
