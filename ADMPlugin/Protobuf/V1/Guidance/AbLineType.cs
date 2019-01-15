using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class AbLineType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine), Constants.UseDefaults);
      type.AddField(273, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.A));
      type.AddField(274, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.B));
      type.AddField(275, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.Heading));
      type.AddField(276, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.EastShiftComponent));
      type.AddField(277, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine.NorthShiftComponent));
    }
  }
}
