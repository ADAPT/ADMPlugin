using System.Collections.Generic;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.ADMPlugin.Models
{
  public class SerializableReferenceLayer
  {
    public RasterReferenceLayer RasterReferenceLayer { get; set; }
    public List<SerializableRasterData<string>> StringValues { get; set; }
    public List<SerializableRasterData<EnumerationMember>> EnumerationMemberValues { get; set; }
    public List<SerializableRasterData<NumericValue>> NumericValueValues { get; set; }

    public ShapeReferenceLayer ShapeReferenceLayer { get; set; }
    public List<SerializableShapeData> ShapeLookupValues { get; set; }
  }
}
