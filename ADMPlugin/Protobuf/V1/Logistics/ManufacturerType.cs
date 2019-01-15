using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class ManufacturerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Manufacturer), Constants.UseDefaults);
      type.AddField(443, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Manufacturer.Id));
      type.AddField(444, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Manufacturer.Description));
    }
  }
}
