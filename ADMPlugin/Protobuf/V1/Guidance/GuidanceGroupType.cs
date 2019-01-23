using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class GuidanceGroupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceGroup), Constants.UseDefaults);
      type.AddField(294, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceGroup.Id));
      type.AddField(295, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceGroup.Description));
      type.AddField(296, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceGroup.GuidancePatternIds));
      type.AddField(297, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidanceGroup.BoundingPolygon));
    }
  }
}
