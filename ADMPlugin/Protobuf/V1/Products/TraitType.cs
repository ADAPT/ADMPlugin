using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Products
{
  public static class TraitType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait), Constants.UseDefaults);
      type.AddField(815, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.Id));
      type.AddField(816, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.TraitCode));
      type.AddField(817, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.Description));
      type.AddField(818, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.ManufacturerId));
      type.AddField(819, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.CropIds));
    }
  }
}
