using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class DeviceElementConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration), Constants.UseDefaults);
      type.AddField(618, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.Id));
      type.AddField(619, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.DeviceElementId));
      type.AddField(620, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.Description));
      type.AddField(621, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.TimeScopes));
      type.AddField(622, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.DeviceElementConfiguration.Offsets));

      type.AddSubType(634, typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration));
      type.AddSubType(644, typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration));
      type.AddSubType(648, typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration));
    }
  }
}
