using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class ProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Product), Constants.UseDefaults);
      type.AddField(765, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Id));
      type.AddField(766, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.BrandId));
      type.AddField(767, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Category));
      type.AddField(768, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ContextItems));
      type.AddField(769, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Density));
      type.AddField(770, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Description));
      type.AddField(771, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Form));
      type.AddField(772, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasCropProtection));
      type.AddField(773, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasCropNutrition));
      type.AddField(774, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasCropVariety));
      type.AddField(775, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.HasHarvestCommodity));
      type.AddField(776, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ManufacturerId));
      type.AddField(777, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ProductComponents));
      type.AddField(778, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.ProductType));
      type.AddField(779, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Product.Status));

      type.AddSubType(830, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.GenericProduct));
      type.AddSubType(828, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.HarvestedCommodityProduct));
      type.AddSubType(780, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct));
      type.AddSubType(784, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct));
      type.AddSubType(794, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionProduct));
      type.AddSubType(807, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct));
    }
  }
}
