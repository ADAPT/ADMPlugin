using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class DeviceElementType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement), Constants.UseDefaults);
      type.AddField(607, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.Id));
      type.AddField(608, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.Description));
      type.AddField(609, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.SerialNumber));
      type.AddField(610, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.ManufacturerId));
      type.AddField(611, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.BrandId));
      type.AddField(612, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.SeriesId));
      type.AddField(613, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.ContextItems));
      type.AddField(614, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.DeviceClassification));
      type.AddField(615, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.DeviceModelId));
      type.AddField(616, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.DeviceElementType));
      type.AddField(617, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElement.ParentDeviceId));
    }
  }
}
