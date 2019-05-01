using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class CropType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop), Constants.UseDefaults);
      type.AddField(757, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.Id));
      type.AddField(758, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.Name));
      type.AddField(759, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.ParentId));
      type.AddField(760, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.ReferenceWeight));
      type.AddField(761, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.StandardPayableMoisture));
      type.AddField(762, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Crop.ContextItems));
    }
  }
}
