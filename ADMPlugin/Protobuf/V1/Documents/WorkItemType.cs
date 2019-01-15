using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class WorkItemType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem), Constants.UseDefaults);
      type.AddField(228, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.Id));
      type.AddField(232, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.Notes));
      type.AddField(822, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.TimeScopes));
      type.AddField(233, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.WorkItemPriority));
      type.AddField(235, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.PeopleRoleIds));
      type.AddField(236, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.GrowerId));
      type.AddField(237, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.FarmId));
      type.AddField(238, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.FieldId));
      type.AddField(239, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.CropZoneId));
      type.AddField(241, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.ReferenceLayerIds));
      type.AddField(242, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.BoundaryId));
      type.AddField(243, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.WorkItemOperationIds));
      type.AddField(244, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.GuidanceAllocationIds));
      type.AddField(245, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.StatusUpdates));
      type.AddField(231, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.WorkOrderIds));
      type.AddField(246, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.ParentDocumentId));
      type.AddField(603, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItem.EquipmentConfigurationGroup));
    }
  }
}
