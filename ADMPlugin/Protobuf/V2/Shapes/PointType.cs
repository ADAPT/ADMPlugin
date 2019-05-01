using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Shapes
{
  public static class PointType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point.X));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point.Y));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point.Z));
    }
  }
}
