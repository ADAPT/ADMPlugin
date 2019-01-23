using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class AbCurveType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.NumberOfSegments));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.Heading));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.EastShiftComponent));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.NorthShiftComponent));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve.Shape));
    }
  }
}
