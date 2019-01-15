using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class CropZoneType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone), Constants.UseDefaults);
      type.AddField(368, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Id));
      type.AddField(823, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.TimeScopes));
      type.AddField(370, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Description));
      type.AddField(371, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.FieldId));
      type.AddField(372, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.CropId));
      type.AddField(373, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Area));
      type.AddField(374, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.BoundingRegion));
      type.AddField(375, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.BoundarySource));
      type.AddField(376, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.Notes));
      type.AddField(377, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.GuidanceGroupIds));
      type.AddField(378, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.CropZone.ContextItems));
    }
  }
}
