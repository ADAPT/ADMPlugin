using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class HarvestedCommodityProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.HarvestedCommodityProduct), Constants.UseDefaults);
      type.AddField(829, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.HarvestedCommodityProduct.CropId));
    }
  }
}
