using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class ContactInfoType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.AddressLine1));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.AddressLine2));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.PoBoxNumber));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.PostalCode));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.City));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.StateOrProvince));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Country));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.CountryCode));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Contacts));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Location));
      type.AddField(12, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.ContextItems));
    }
  }
}
