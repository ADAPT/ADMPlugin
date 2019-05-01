using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class WorkItemOperationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.OperationType));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.PrescriptionId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.EquipmentConfigurationIds));
    }
  }
}
