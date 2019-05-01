using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class DestinationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.Location));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.FacilityId));
    }
  }
}
