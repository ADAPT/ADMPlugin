using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Shapes
{
  public static class MultiLineStringType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiLineString), Constants.UseDefaults);
      type.AddField(155, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.MultiLineString.LineStrings));
    }
  }
}
