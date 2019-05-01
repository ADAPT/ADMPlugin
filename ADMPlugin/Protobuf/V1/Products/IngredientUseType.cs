using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class IngredientUseType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse), Constants.UseDefaults);
      type.AddField(796, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.Id));
      type.AddField(797, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.ProductId));
      type.AddField(798, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.IngredientId));
      type.AddField(799, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.Fraction));
      type.AddField(800, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.IngredientUse.IsProduct));
    }
  }
}
