using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class CropProtectionProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct), Constants.UseDefaults);
      type.AddField(781, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct.Biological));
      type.AddField(782, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct.Organophosphate));
      type.AddField(783, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.CropProtectionProduct.Carbamate));
    }
  }
}
