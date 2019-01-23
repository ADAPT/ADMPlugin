using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Shapes
{
  public static class LineStringType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.LineString), Constants.UseDefaults);
      type.AddField(153, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.LineString.Points));
    }
  }
}
