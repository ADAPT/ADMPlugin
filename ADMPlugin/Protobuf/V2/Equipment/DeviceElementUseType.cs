using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class DeviceElementUseType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.DeviceConfigurationId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.OperationDataId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.Depth));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.Order));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.TotalDistanceTravelled));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.TotalElapsedTime));
    }
  }
}
