using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class CompanyType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.Name));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.ContactInfoId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.ContextItems));
    }
  }
}
