using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class AvailableProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct), Constants.UseDefaults);
      type.AddField(753, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.Id));
      type.AddField(754, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.ProductId));
      type.AddField(755, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.GrowerId));
      type.AddField(756, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.ContextItems));
      type.AddField(846, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.TimeScopes));
    }
  }
}
