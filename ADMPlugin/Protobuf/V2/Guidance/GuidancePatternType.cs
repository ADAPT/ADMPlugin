using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Guidance
{
  public static class GuidancePatternType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.GuidancePatternType));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.GpsSource));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.OriginalEpsgCode));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.Description));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.SwathWidth));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.PropagationDirection));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.Extension));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.NumbersOfSwathsLeft));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.NumbersOfSwathsRight));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.Guidance.GuidancePattern.BoundingPolygon));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbCurve));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.AbLine));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.MultiAbLine));
      type.AddSubType(104, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.APlus));
      type.AddSubType(105, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.PivotGuidancePattern));
      type.AddSubType(106, typeof(AgGateway.ADAPT.ApplicationDataModel.Guidance.Spiral));
    }
  }
}
