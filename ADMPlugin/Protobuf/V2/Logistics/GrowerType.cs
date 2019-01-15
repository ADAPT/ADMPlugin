using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class GrowerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.Name));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.ContactInfo));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Grower.ContextItems));
    }
  }
}
