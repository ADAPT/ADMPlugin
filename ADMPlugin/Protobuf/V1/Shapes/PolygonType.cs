using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Shapes
{
  public static class PolygonType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Polygon), Constants.UseDefaults);
      type.AddField(165, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Polygon.ExteriorRing));
      type.AddField(166, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Polygon.InteriorRings));
    }
  }
}
