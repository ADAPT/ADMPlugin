using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class ContactInfoType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo), Constants.UseDefaults);
      type.AddField(389, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Id));
      type.AddField(390, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.AddressLine1));
      type.AddField(391, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.AddressLine2));
      type.AddField(392, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.PoBoxNumber));
      type.AddField(393, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.PostalCode));
      type.AddField(394, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.City));
      type.AddField(395, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.StateOrProvince));
      type.AddField(396, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Country));
      type.AddField(397, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.CountryCode));
      type.AddField(398, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Contacts));
      type.AddField(399, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.Location));
      type.AddField(400, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.ContactInfo.ContextItems));
    }
  }
}
