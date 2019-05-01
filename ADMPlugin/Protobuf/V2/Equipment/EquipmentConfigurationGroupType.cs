using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class EquipmentConfigurationGroupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.EquipmentConfigurations));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfigurationGroup.TimeScopes));
    }
  }
}
