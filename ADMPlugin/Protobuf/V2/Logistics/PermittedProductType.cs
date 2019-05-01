using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class PermittedProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.TimeScopes));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.GrowerId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.ProductId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.ContextItems));
    }
  }
}
