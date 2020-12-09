using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class LoggedDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.Id));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.WorkRecordId));
      type.AddField(16, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.GrowerId));
      type.AddField(17, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.FarmId));
      type.AddField(18, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.FieldId));
      type.AddField(19, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.CropZoneId));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.TimeScopes));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.PersonRoleIds));
      type.AddField(20, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.EquipmentConfigurationGroup));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.GuidanceAllocationIds));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.WorkItemIds));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.SummaryId));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.Notes));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.OperationData));
      type.AddField(22, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.CalibrationFactors));
      type.AddField(21, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.LoggedData.Description));
    }
  }
}
