using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class CropNutritionProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionProduct), Constants.UseDefaults);
      type.AddField(795, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionProduct.IsManure));
    }
  }
}
