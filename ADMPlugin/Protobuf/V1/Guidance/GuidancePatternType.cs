using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Guidance
{
  public static class GuidancePatternType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern), Constants.UseDefaults);
      type.AddField(255, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.Id));
      type.AddField(256, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.GuidancePatternType));
      type.AddField(257, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.GpsSource));
      type.AddField(258, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.OriginalEpsgCode));
      type.AddField(259, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.Description));
      type.AddField(260, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.SwathWidth));
      type.AddField(261, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.PropagationDirection));
      type.AddField(262, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.Extension));
      type.AddField(263, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.NumbersOfSwathsLeft));
      type.AddField(264, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.NumbersOfSwathsRight));
      type.AddField(265, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.BoundingPolygon));

      type.AddSubType(266, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve));
      type.AddSubType(272, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine));
      type.AddSubType(278, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.MultiAbLine));
      type.AddSubType(280, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus));
      type.AddSubType(842, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern));
      type.AddSubType(304, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.Spiral));
    }
  }
}
