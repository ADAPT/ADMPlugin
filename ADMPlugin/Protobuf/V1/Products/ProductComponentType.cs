using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class ProductComponentType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductComponent), Constants.UseDefaults);
      type.AddField(803, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductComponent.IngredientId));
      type.AddField(804, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductComponent.Quantity));
      type.AddField(805, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductComponent.IsProduct));
      type.AddField(806, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.ProductComponent.IsCarrier));
    }
  }
}
