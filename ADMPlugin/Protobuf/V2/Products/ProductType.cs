using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class ProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Product), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Id));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.BrandId));
      type.AddField(16, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Category));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ContextItems));
      type.AddField(17, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Density));
      type.AddField(18, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Description));
      type.AddField(19, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Form));
      type.AddField(20, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasCropProtection));
      type.AddField(21, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasCropNutrition));
      type.AddField(22, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasCropVariety));
      type.AddField(23, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasHarvestCommodity));
      type.AddField(24, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ManufacturerId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ProductComponents));
      type.AddField(25, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ProductType));
      type.AddField(26, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Status));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.GenericProduct));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.HarvestedCommodityProduct));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct));
      type.AddSubType(104, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct));
      type.AddSubType(105, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionProduct));
      type.AddSubType(106, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct));
    }
  }
}
