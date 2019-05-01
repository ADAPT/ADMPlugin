using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class DestinationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination), Constants.UseDefaults);
      type.AddField(439, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.Id));
      type.AddField(440, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.Description));
      type.AddField(441, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.Location));
      type.AddField(442, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Destination.FacilityId));
    }
  }
}
