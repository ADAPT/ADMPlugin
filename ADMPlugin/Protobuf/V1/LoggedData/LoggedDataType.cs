using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class LoggedDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData), Constants.UseDefaults);
      type.AddField(689, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.Id));
      type.AddField(848, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.WorkRecordId));
      type.AddField(679, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.GrowerId));
      type.AddField(52, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.FarmId));
      type.AddField(53, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.FieldId));
      type.AddField(54, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.CropZoneId));
      type.AddField(680, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.TimeScopes));
      type.AddField(690, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.PersonRoleIds));
      type.AddField(550, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.EquipmentConfigurationGroup));
      type.AddField(51, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.GuidanceAllocationIds));
      type.AddField(48, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.WorkItemIds));
      type.AddField(56, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.SummaryId));
      type.AddField(49, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.Notes));
      type.AddField(55, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.OperationData));
      type.AddField(681, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.Description));
    }
  }
}
