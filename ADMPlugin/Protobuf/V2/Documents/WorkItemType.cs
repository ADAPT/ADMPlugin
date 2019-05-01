using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class WorkItemType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.Id));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.Notes));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.TimeScopes));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.WorkItemPriority));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.PeopleRoleIds));
      type.AddField(16, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.GrowerId));
      type.AddField(17, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.FarmId));
      type.AddField(18, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.FieldId));
      type.AddField(19, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.CropZoneId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.ReferenceLayerIds));
      type.AddField(20, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.BoundaryId));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.WorkItemOperationIds));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.GuidanceAllocationIds));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.StatusUpdates));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.WorkOrderIds));
      type.AddField(21, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.ParentDocumentId));
      type.AddField(22, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.EquipmentConfigurationGroup));
    }
  }
}
