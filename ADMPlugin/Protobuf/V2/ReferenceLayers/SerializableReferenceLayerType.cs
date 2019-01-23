using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class SerializableReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.RasterReferenceLayer));
      type.AddField(2, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.StringValues));
      type.AddField(3, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.EnumerationMemberValues));
      type.AddField(4, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.NumericValueValues));
      type.AddField(5, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.ShapeReferenceLayer));
      type.AddField(6, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.ShapeLookupValues));
    }
  }
}
