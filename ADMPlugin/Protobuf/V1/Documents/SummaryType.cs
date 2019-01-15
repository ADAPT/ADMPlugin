using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class SummaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary), Constants.UseDefaults);
      type.AddField(835, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.Id));
      type.AddField(836, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.WorkRecordId));
      type.AddField(837, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.GrowerId));
      type.AddField(684, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.FarmId));
      type.AddField(685, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.FieldId));
      type.AddField(686, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.CropZoneId));
      type.AddField(838, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.TimeScopes));
      type.AddField(520, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.PersonRoleIds));
      type.AddField(602, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.EquipmentConfigurationGroup));
      type.AddField(839, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.GuidanceAllocationIds));
      type.AddField(524, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.WorkItemIds));
      type.AddField(523, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.LoggedDataIds));
      type.AddField(522, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.Notes));
      type.AddField(516, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.SummaryData));
      type.AddField(525, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.OperationSummaries));
    }
  }
}
