using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class CropZoneType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.TimeScopes));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Description));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.FieldId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.CropId));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Area));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.BoundingRegion));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.BoundarySource));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Notes));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.GuidanceGroupIds));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.ContextItems));
    }
  }
}
