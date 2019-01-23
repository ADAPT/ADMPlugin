using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Shapes
{
  public static class PointType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point), Constants.UseDefaults);
      type.AddField(161, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point.X));
      type.AddField(162, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point.Y));
      type.AddField(163, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.Point.Z));
    }
  }
}
