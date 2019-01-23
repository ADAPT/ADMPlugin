using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class FacilityType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility), Constants.UseDefaults);
      type.AddField(401, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.Id));
      type.AddField(402, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.CompanyId));
      type.AddField(403, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.Description));
      type.AddField(404, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.ContactInfo));
      type.AddField(405, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.FacilityType));
      type.AddField(406, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.ContextItems));
    }
  }
}
