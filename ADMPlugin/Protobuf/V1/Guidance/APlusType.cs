using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class APlusType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus), Constants.UseDefaults);
      type.AddField(281, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus.Point));
      type.AddField(282, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus.Heading));
    }
  }
}
