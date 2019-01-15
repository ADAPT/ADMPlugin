using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class SummaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.Id));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.WorkRecordId));
      type.AddField(16, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.GrowerId));
      type.AddField(17, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.FarmId));
      type.AddField(18, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.FieldId));
      type.AddField(19, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.CropZoneId));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.TimeScopes));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.PersonRoleIds));
      type.AddField(20, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.EquipmentConfigurationGroup));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.GuidanceAllocationIds));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.WorkItemIds));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.LoggedDataIds));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.Notes));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.SummaryData));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Summary.OperationSummaries));
    }
  }
}
