using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.FieldBoundaries
{
  public static class FieldBoundaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.FieldId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.SpatialData));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.TimeScopes));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.Headlands));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.GpsSource));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.OriginalEpsgCode));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.InteriorBoundaryAttributes));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.FieldBoundary.ContextItems));
    }
  }
}
