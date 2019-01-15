using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Shapes
{
  public static class ShapeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Shape), Constants.UseDefaults);
      type.AddField(148, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Shape.Id));
      type.AddField(149, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Shape.Type));

      type.AddSubType(150, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.LinearRing));
      type.AddSubType(152, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.LineString));
      type.AddSubType(154, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiLineString));
      type.AddSubType(156, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiPoint));
      type.AddSubType(158, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiPolygon));
      type.AddSubType(160, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point));
      type.AddSubType(164, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Polygon));
    }
  }
}
