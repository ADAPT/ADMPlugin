using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class AbLineType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.A));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.B));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.Heading));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.EastShiftComponent));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.NorthShiftComponent));
    }
  }
}
