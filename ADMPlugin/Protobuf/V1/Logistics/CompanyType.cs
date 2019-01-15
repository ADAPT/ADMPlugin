using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class CompanyType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company), Constants.UseDefaults);
      type.AddField(383, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.Id));
      type.AddField(384, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.Name));
      type.AddField(385, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.ContactInfoId));
      type.AddField(386, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Company.ContextItems));
    }
  }
}
