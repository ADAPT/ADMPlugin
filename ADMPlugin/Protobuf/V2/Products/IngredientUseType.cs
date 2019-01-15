using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class IngredientUseType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.ProductId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.IngredientId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.Fraction));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.IsProduct));
    }
  }
}
