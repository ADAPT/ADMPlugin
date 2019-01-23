using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class DeviceElementUseType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse), Constants.UseDefaults);
      type.AddField(672, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.Id));
      type.AddField(673, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.DeviceConfigurationId));
      type.AddField(674, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.OperationDataId));
      type.AddField(675, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.Depth));
      type.AddField(676, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.Order));
      type.AddField(677, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.TotalDistanceTravelled));
      type.AddField(678, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementUse.TotalElapsedTime));
    }
  }
}
