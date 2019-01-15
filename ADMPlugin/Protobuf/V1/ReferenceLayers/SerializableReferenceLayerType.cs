using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class SerializableReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer), Constants.UseDefaults);
      type.AddField(472, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.RasterReferenceLayer));
      type.AddField(473, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.StringValues));
      type.AddField(474, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.EnumerationMemberValues));
      type.AddField(475, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.NumericValueValues));
      type.AddField(849, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.ShapeReferenceLayer));
      type.AddField(850, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableReferenceLayer.ShapeLookupValues));
    }
  }
}
