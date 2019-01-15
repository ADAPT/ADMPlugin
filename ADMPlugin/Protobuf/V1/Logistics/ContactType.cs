using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class ContactType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Contact), Constants.UseDefaults);
      type.AddField(387, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Contact.Number));
      type.AddField(388, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Contact.Type));
    }
  }
}
