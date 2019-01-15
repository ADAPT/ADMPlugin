using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class APlusType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus.Point));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus.Heading));
    }
  }
}
