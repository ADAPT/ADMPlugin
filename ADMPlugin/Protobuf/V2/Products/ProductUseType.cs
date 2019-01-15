using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class ProductUseType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.ProductId));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.Rate));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.AppliedArea));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.ProductTotal));
    }
  }
}
