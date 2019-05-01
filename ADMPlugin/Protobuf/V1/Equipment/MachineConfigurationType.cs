using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class MachineConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration), Constants.UseDefaults);
      type.AddField(645, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.GpsReceiverXOffset));
      type.AddField(646, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.GpsReceiverYOffset));
      type.AddField(647, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.GpsReceiverZOffset));
      type.AddField(648, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.OriginAxleLocation));
    }
  }
}
