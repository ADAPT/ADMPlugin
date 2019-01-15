using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.FieldBoundaries
{
  public static class FieldBoundaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary), Constants.UseDefaults);
      type.AddField(699, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.Id));
      type.AddField(700, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.Description));
      type.AddField(701, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.FieldId));
      type.AddField(702, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.SpatialData));
      type.AddField(827, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.TimeScopes));
      type.AddField(704, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.Headlands));
      type.AddField(705, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.GpsSource));
      type.AddField(706, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.OriginalEpsgCode));
      type.AddField(707, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.InteriorBoundaryAttributes));
      type.AddField(708, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.ContextItems));
    }
  }
}
