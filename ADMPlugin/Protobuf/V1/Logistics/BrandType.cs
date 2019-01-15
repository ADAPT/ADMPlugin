using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class BrandType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Brand), Constants.UseDefaults);
      type.AddField(379, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Brand.Id));
      type.AddField(380, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Brand.Description));
      type.AddField(381, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Brand.ManufacturerId));
      type.AddField(382, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Brand.ContextItems));
    }
  }
}
