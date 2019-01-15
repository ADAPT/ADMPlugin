using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class PersonType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.FirstName));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.MiddleName));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.LastName));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.CombinedName));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.ContactInfoId));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.ContextItems));
    }
  }
}
