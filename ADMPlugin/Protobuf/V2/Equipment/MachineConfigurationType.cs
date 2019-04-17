using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class MachineConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.GpsReceiverXOffset));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.GpsReceiverYOffset));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.GpsReceiverZOffset));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.MachineConfiguration.OriginAxleLocation));
    }
  }
}
