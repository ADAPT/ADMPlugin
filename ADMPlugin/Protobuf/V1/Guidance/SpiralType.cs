
using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class SpiralType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.Spiral), Constants.UseDefaults);
      type.AddField(305, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.Spiral.Shape));
    }
  }
}
