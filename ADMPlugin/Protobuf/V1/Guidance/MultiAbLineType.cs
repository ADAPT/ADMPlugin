using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class MultiAbLineType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.MultiAbLine), Constants.UseDefaults);
      type.AddField(279, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.MultiAbLine.AbLines));
    }
  }
}
