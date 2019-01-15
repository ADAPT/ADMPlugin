using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class DeviceElementType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.SerialNumber));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.ManufacturerId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.BrandId));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.SeriesId));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.ContextItems));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.DeviceClassification));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.DeviceModelId));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.DeviceElementType));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.ParentDeviceId));
    }
  }
}
