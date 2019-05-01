using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class FacilityType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.CompanyId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.Description));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.ContactInfo));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.FacilityType));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Facility.ContextItems));
    }
  }
}
