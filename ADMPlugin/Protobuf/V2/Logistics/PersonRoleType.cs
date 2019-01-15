using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class PersonRoleType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.PersonId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.Role));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.GrowerId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.TimeScopes));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.CompanyId));
    }
  }
}
