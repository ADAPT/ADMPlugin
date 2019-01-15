using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class EquipmentConfigurationGroupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup), Constants.UseDefaults);
      type.AddField(627, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.Id));
      type.AddField(628, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.Description));
      type.AddField(629, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.EquipmentConfigurations));
      type.AddField(630, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.TimeScopes));
    }
  }
}
