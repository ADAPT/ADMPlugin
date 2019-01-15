using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class IngredientType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Ingredient.ContextItems));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.ActiveIngredient));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropNutritionIngredient));
    }
  }
}
