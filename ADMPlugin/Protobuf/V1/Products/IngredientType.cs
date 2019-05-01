using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class IngredientType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient), Constants.UseDefaults);
      type.AddField(748, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient.Id));
      type.AddField(749, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient.Description));
      type.AddField(750, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient.ContextItems));

      type.AddSubType(751, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.ActiveIngredient));
      type.AddSubType(763, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionIngredient));
    }
  }
}
