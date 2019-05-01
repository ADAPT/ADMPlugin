using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class PersonRoleType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole), Constants.UseDefaults);
      type.AddField(457, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.Id));
      type.AddField(458, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.PersonId));
      type.AddField(459, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.Role));
      type.AddField(460, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.GrowerId));
      type.AddField(461, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.TimeScopes));
      type.AddField(462, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PersonRole.CompanyId));
    }
  }
}
