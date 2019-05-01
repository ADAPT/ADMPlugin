using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class PersonType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person), Constants.UseDefaults);
      type.AddField(450, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.Id));
      type.AddField(451, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.FirstName));
      type.AddField(452, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.MiddleName));
      type.AddField(453, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.LastName));
      type.AddField(454, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.CombinedName));
      type.AddField(455, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.ContactInfoId));
      type.AddField(456, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Person.ContextItems));
    }
  }
}
