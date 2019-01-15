using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Shapes
{
  public static class ShapeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Shape), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Shape.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Shape.Type));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.LinearRing));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.LineString));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiLineString));
      type.AddSubType(104, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiPoint));
      type.AddSubType(105, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiPolygon));
      type.AddSubType(106, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point));
      type.AddSubType(107, typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Polygon));
    }
  }
}
