using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class WorkItemOperationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation), Constants.UseDefaults);
      type.AddField(247, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.Description));
      type.AddField(248, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.Id));
      type.AddField(249, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.OperationType));
      type.AddField(250, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.PrescriptionId));
      type.AddField(604, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkItemOperation.EquipmentConfigurationIds));
    }
  }
}
