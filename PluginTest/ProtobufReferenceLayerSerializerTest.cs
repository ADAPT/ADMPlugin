using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using Moq;
using NUnit.Framework;

namespace PluginTest
{
    [TestFixture]
    public class ProtobufReferenceLayerSerializerTest
    {
        private string _filepath;
        private ProtobufReferenceLayerSerializer _serializer;
        private List<ReferenceLayer> _referenceLayers;

        private Mock<IProtobufReferenceLayerConverter> _converterMock;
        private Mock<IProtobufSerializer> _serializerMock;

        [SetUp]
        public void Setup()
        {
            _filepath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            _referenceLayers = new List<ReferenceLayer>();
            
            Directory.CreateDirectory(_filepath);

            _converterMock = new Mock<IProtobufReferenceLayerConverter>();
            _serializerMock = new Mock<IProtobufSerializer>();

            _serializer = new ProtobufReferenceLayerSerializer(_converterMock.Object, _serializerMock.Object);
        }

        [Test]
        public void GivenFilenameAndReferenceLayersWhenExportThenConverterCalled()
        {
            _referenceLayers.Add(new RasterReferenceLayer());

            _serializer.Export(_filepath, "file.bin", _referenceLayers);

            _converterMock.Verify(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.First()), Times.Once());
        }

        [Test]
        public void GivenFilenameAndRefenceLayerWhenExportThenSeralizableReferenceLayersAreSerialized()
        {
            string filename = "file.bin";
            var output = Path.Combine(_filepath, filename);
            _referenceLayers.Add(new RasterReferenceLayer());

            var serializableReferenceLayer = new SerializableReferenceLayer();
            _converterMock.Setup(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.First())).Returns(serializableReferenceLayer);
            _serializer.Export(_filepath, "file.bin", _referenceLayers);

            _serializerMock.Verify(x => x.Write(output, new List<SerializableReferenceLayer>{serializableReferenceLayer}), Times.Once);
        }

        [Test]
        public void GivenFilenameAndMultipleRefenceLayersWhenExportThenSeralizableReferenceLayersAreSerialized()
        {
            string filename = "file.bin";
            var output = Path.Combine(_filepath, filename);
            _referenceLayers.Add(new RasterReferenceLayer());
            _referenceLayers.Add(new RasterReferenceLayer());

            var serializableReferenceLayer = new SerializableReferenceLayer();
            var serializableReferenceLayer2 = new SerializableReferenceLayer();
            _converterMock.Setup(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.First())).Returns(serializableReferenceLayer);
            _converterMock.Setup(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.ElementAt(1))).Returns(serializableReferenceLayer2);
            _serializer.Export(_filepath, "file.bin", _referenceLayers);

            _serializerMock.Verify(x => x.Write(output, new List<SerializableReferenceLayer> { serializableReferenceLayer, serializableReferenceLayer2 }), Times.Once);
        }

        [Test]
        public void GivenFilenameWhenImportThenSerializerReadIsCalled()
        {
            string filename = "file.bin";
            var output = Path.Combine(_filepath, filename);
            File.Create(output).Close();

            var serializableReferenceLayer = new SerializableReferenceLayer();
            _serializerMock.Setup(x => x.Read<List<SerializableReferenceLayer>>(output)).Returns(new List<SerializableReferenceLayer>{serializableReferenceLayer});

            var rasterReferenceLayer = new RasterReferenceLayer{ Description = "woopwoopwoop"};
            _converterMock.Setup(x => x.ConvertToReferenceLayer(serializableReferenceLayer)).Returns(rasterReferenceLayer);

            var result = _serializer.Import(_filepath, filename);

            Assert.AreEqual(rasterReferenceLayer.Description, result.First().Description);
        }

        [Test]
        public void GivenFilenameWhenImportThenMultipleReferenceLayersReturned()
        {
            string filename = "file.bin";
            var output = Path.Combine(_filepath, filename);
            File.Create(output).Close();

            var serializableReferenceLayer = new SerializableReferenceLayer();
            var serializableReferenceLayer2 = new SerializableReferenceLayer();
            _serializerMock.Setup(x => x.Read<List<SerializableReferenceLayer>>(output)).Returns(new List<SerializableReferenceLayer> { serializableReferenceLayer, serializableReferenceLayer2 });

            var rasterReferenceLayer = new RasterReferenceLayer { Description = "woopwoopwoop" };
            var rasterReferenceLayer2 = new RasterReferenceLayer { Description = "nopenopenope" };
            _converterMock.Setup(x => x.ConvertToReferenceLayer(serializableReferenceLayer)).Returns(rasterReferenceLayer);
            _converterMock.Setup(x => x.ConvertToReferenceLayer(serializableReferenceLayer2)).Returns(rasterReferenceLayer2);

            var result = _serializer.Import(_filepath, filename).ToList();

            Assert.AreEqual(rasterReferenceLayer.Description, result[0].Description);
            Assert.AreEqual(rasterReferenceLayer2.Description, result[1].Description);
        }

        [Test]
        public void GivenNullReferenceLayersWhenExportThenNoFileWritten()
        {
            _serializer.Export(_filepath, "file.bin", null);

            _serializerMock.Verify(x => x.Write(Path.Combine(_filepath, "file.bin"), It.IsAny<Object>()), Times.Never);
        }

        [Test]
        public void GivenFilenameThatDoesNotExistWhenImportThenReturnsEmptyList()
        {
            var result = _serializer.Import(_filepath, "notaFile.bin");

            Assert.AreEqual(0, result.Count());
        }

        [TearDown]
        public void Teardown()
        {
            if (Directory.Exists(_filepath))
            {
                Directory.Delete(_filepath, true);
            }
        }

    }
}
