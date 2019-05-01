using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class DensityFactorType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor), Constants.UseDefaults);
      type.AddField(788, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.Id));
      type.AddField(789, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.ProductId));
      type.AddField(790, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.BatchNo));
      type.AddField(791, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.LotNo));
      type.AddField(792, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.Density));
      type.AddField(793, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.TimeScopeIds));
    }
  }
}
