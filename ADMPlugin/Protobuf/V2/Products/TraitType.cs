using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Products
{
  public static class TraitType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.TraitCode));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.Description));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.ManufacturerId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Products.Trait.CropIds));
    }
  }
}
