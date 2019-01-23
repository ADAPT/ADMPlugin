using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class DeviceModelType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceModel), Constants.UseDefaults);
      type.AddField(623, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceModel.Id));
      type.AddField(624, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceModel.Description));
      type.AddField(625, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceModel.SeriesId));
      type.AddField(626, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceModel.BrandId));
    }
  }
}
