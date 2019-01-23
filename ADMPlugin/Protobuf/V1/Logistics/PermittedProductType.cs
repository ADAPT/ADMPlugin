using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class PermittedProductType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct), Constants.UseDefaults);
      type.AddField(445, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.Id));
      type.AddField(446, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.TimeScopes));
      type.AddField(447, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.GrowerId));
      type.AddField(448, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.ProductId));
      type.AddField(449, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.PermittedProduct.ContextItems));
    }
  }
}
