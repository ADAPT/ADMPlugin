using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class EquipmentConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration), Constants.UseDefaults);
      type.AddField(662, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Id));
      type.AddField(663, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Description));
      type.AddField(664, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Connector1Id));
      type.AddField(665, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Connector2Id));
      type.AddField(666, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.DataLogTriggers));
    }
  }
}
