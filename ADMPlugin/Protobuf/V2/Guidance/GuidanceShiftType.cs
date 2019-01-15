using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class GuidanceShiftType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift.GuidanceGroupId));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift.GuidancePatterId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift.EastShift));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift.NorthShift));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift.PropagationOffset));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceShift.TimeScopeIds));
    }
  }
}
