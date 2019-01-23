using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class GuidanceAllocationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation), Constants.UseDefaults);
      type.AddField(287, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.Id));
      type.AddField(288, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.GuidanceGroupId));
      type.AddField(533, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.GuidanceShift));
      type.AddField(329, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceAllocation.TimeScopes));
    }
  }
}
