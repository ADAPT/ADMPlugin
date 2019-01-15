using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class AvailableProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.ProductId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.GrowerId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.ContextItems));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.AvailableProduct.TimeScopes));
    }
  }
}
