using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class PivotGuidancePatternType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.StartPoint));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.EndPoint));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.Center));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.Radius));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.DefinitionMethod));
      // type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.Point1));
      // type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.Point2));
      // type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern.Point3));
    }
  }
}
