using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class DeviceElementConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.DeviceElementId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.Description));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.TimeScopes));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.Offsets));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration));
    }
  }
}
