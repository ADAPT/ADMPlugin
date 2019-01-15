using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class ManufacturerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Manufacturer), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Manufacturer.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Manufacturer.Description));
    }
  }
}
