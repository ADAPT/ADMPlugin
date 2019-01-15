using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class CropVarietyProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct.CropId));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct.TraitIds));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct.GeneticallyEnhanced));
    }
  }
}
