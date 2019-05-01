using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class MixProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct), Constants.UseDefaults);
      type.AddField(808, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct.TotalQuantity));
      type.AddField(809, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct.IsTemporary));
      type.AddField(810, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.MixProduct.IsHotMix));
    }
  }
}
