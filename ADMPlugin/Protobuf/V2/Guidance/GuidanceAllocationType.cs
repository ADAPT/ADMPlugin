using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class GuidanceAllocationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.GuidanceGroupId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.GuidanceShift));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.TimeScopes));
    }
  }
}
