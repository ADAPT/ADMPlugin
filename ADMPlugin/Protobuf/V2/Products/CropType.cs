using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class CropType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.Name));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.ParentId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.ReferenceWeight));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.StandardPayableMoisture));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.ContextItems));
    }
  }
}
