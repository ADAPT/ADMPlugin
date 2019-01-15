using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class AbCurveType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve), Constants.UseDefaults);
      type.AddField(267, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.NumberOfSegments));
      type.AddField(268, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.Heading));
      type.AddField(269, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.EastShiftComponent));
      type.AddField(270, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.NorthShiftComponent));
      type.AddField(271, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.Shape));
    }
  }
}
