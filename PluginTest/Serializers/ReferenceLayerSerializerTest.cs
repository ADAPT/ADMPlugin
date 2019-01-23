using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ADMPlugin.Converters;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Moq;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest.Serializers
{
  [TestFixture]
  public class ReferenceLayerSerializerTest
  {
    private string _filepath;
    private List<ReferenceLayer> _referenceLayers;

    private Mock<IReferenceLayerConverter> _converterMock;
    private Mock<IBaseSerializer> _baseSerializerMock;

    [SetUp]
    public void Setup()
    {
      _filepath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
      _referenceLayers = new List<ReferenceLayer>();

      Directory.CreateDirectory(_filepath);

      _converterMock = new Mock<IReferenceLayerConverter>();
      _baseSerializerMock = new Mock<IBaseSerializer>();
    }

    [Test]
    public void GivenFilenameAndReferenceLayersWhenExportThenConverterCalled()
    {
      _referenceLayers.Add(new RasterReferenceLayer());

      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      serializer.Serialize(_baseSerializerMock.Object, _referenceLayers, _filepath);

      _converterMock.Verify(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.First()), Times.Once());
    }

    [Test]
    public void GivenFilenameAndRefenceLayerWhenExportThenSeralizableReferenceLayersAreSerialized()
    {
      var output = Path.Combine(_filepath, DatacardConstants.ReferenceLayersFile);
      _referenceLayers.Add(new RasterReferenceLayer());

      var serializableReferenceLayer = new SerializableReferenceLayer();
      _converterMock.Setup(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.First())).Returns(serializableReferenceLayer);
      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      serializer.Serialize(_baseSerializerMock.Object, _referenceLayers, _filepath);

      _baseSerializerMock.Verify(x => x.Serialize(new List<SerializableReferenceLayer> { serializableReferenceLayer }, output), Times.Once);
    }

    [Test]
    public void GivenFilenameAndMultipleRefenceLayersWhenExportThenSeralizableReferenceLayersAreSerialized()
    {
      var output = Path.Combine(_filepath, DatacardConstants.ReferenceLayersFile);
      _referenceLayers.Add(new RasterReferenceLayer());
      _referenceLayers.Add(new RasterReferenceLayer());

      var serializableReferenceLayer = new SerializableReferenceLayer();
      var serializableReferenceLayer2 = new SerializableReferenceLayer();
      _converterMock.Setup(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.First())).Returns(serializableReferenceLayer);
      _converterMock.Setup(x => x.ConvertToSerializableReferenceLayer(_referenceLayers.ElementAt(1))).Returns(serializableReferenceLayer2);
      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      serializer.Serialize(_baseSerializerMock.Object, _referenceLayers, _filepath);

      _baseSerializerMock.Verify(x => x.Serialize(new List<SerializableReferenceLayer> { serializableReferenceLayer, serializableReferenceLayer2 }, output), Times.Once);
    }

    [Test]
    public void GivenFilenameWhenImportThenSerializerReadIsCalled()
    {
      var output = Path.Combine(_filepath, DatacardConstants.ReferenceLayersFile);
      File.Create(output).Close();

      var serializableReferenceLayer = new SerializableReferenceLayer();
      _baseSerializerMock.Setup(x => x.Deserialize<List<SerializableReferenceLayer>>(output)).Returns(new List<SerializableReferenceLayer> { serializableReferenceLayer });

      var rasterReferenceLayer = new RasterReferenceLayer { Description = "woopwoopwoop" };
      _converterMock.Setup(x => x.ConvertToReferenceLayer(serializableReferenceLayer)).Returns(rasterReferenceLayer);

      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      var result = serializer.Deserialize(_baseSerializerMock.Object, _filepath);

      Assert.AreEqual(rasterReferenceLayer.Description, result.First().Description);
    }

    [Test]
    public void GivenFilenameWhenImportThenMultipleReferenceLayersReturned()
    {
      var output = Path.Combine(_filepath, DatacardConstants.ReferenceLayersFile);
      File.Create(output).Close();

      var serializableReferenceLayer = new SerializableReferenceLayer();
      var serializableReferenceLayer2 = new SerializableReferenceLayer();
      _baseSerializerMock.Setup(x => x.Deserialize<List<SerializableReferenceLayer>>(output)).Returns(new List<SerializableReferenceLayer> { serializableReferenceLayer, serializableReferenceLayer2 });

      var rasterReferenceLayer = new RasterReferenceLayer { Description = "woopwoopwoop" };
      var rasterReferenceLayer2 = new RasterReferenceLayer { Description = "nopenopenope" };
      _converterMock.Setup(x => x.ConvertToReferenceLayer(serializableReferenceLayer)).Returns(rasterReferenceLayer);
      _converterMock.Setup(x => x.ConvertToReferenceLayer(serializableReferenceLayer2)).Returns(rasterReferenceLayer2);

      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      var result = serializer.Deserialize(_baseSerializerMock.Object, _filepath).ToList();

      Assert.AreEqual(rasterReferenceLayer.Description, result[0].Description);
      Assert.AreEqual(rasterReferenceLayer2.Description, result[1].Description);
    }

    [Test]
    public void GivenNullReferenceLayersWhenExportThenNoFileWritten()
    {
      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      serializer.Serialize(_baseSerializerMock.Object, null, _filepath);

      _baseSerializerMock.Verify(x => x.Serialize(It.IsAny<Object>(), Path.Combine(_filepath, DatacardConstants.ReferenceLayersFile)), Times.Never);
    }

    [Test]
    public void GivenFilenameThatDoesNotExistWhenImportThenReturnsEmptyList()
    {
      var serializer = new ReferenceLayersSerializer(_converterMock.Object);
      var result = serializer.Deserialize(_baseSerializerMock.Object, _filepath);

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
