using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class DensityFactorType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.ProductId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.BatchNo));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.LotNo));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.Density));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.DensityFactor.TimeScopeIds));
    }
  }
}
