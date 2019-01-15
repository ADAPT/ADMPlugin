using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class PivotGuidancePatternType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern), Constants.UseDefaults);
      type.AddField(843, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.StartPoint));
      type.AddField(844, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.EndPoint));
      type.AddField(845, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.Center));
    }
  }
}
