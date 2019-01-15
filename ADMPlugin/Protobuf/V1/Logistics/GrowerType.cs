using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class GrowerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower), Constants.UseDefaults);
      type.AddField(432, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.Id));
      type.AddField(433, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.Name));
      type.AddField(434, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.ContactInfo));
      type.AddField(435, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.ContextItems));
    }
  }
}
