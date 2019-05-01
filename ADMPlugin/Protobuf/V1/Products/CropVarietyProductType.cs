using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class CropVarietyProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct), Constants.UseDefaults);
      type.AddField(785, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct.CropId));
      type.AddField(786, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct.TraitIds));
      type.AddField(787, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropVarietyProduct.GeneticallyEnhanced));
    }
  }
}
