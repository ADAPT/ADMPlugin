using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class FarmType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.GrowerId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.ContactInfo));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.TimeScopes));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.ContextItems));
    }
  }
}
