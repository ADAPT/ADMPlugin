using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class ProductUseType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse), Constants.UseDefaults);
      type.AddField(811, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.ProductId));
      type.AddField(812, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.Rate));
      type.AddField(813, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.AppliedArea));
      type.AddField(814, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductUse.ProductTotal));
    }
  }
}
