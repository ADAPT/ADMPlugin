using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class EquipmentConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Connector1Id));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.Connector2Id));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.EquipmentConfiguration.DataLogTriggers));
    }
  }
}
