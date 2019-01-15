using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class CropProtectionProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct.Biological));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct.Organophosphate));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct.Carbamate));
    }
  }
}
