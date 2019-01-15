using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class FarmType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm), Constants.UseDefaults);
      type.AddField(407, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.Id));
      type.AddField(408, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.Description));
      type.AddField(409, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.GrowerId));
      type.AddField(410, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.ContactInfo));
      type.AddField(824, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.TimeScopes));
      type.AddField(412, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Farm.ContextItems));
    }
  }
}
