using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class OperationSummaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.OperationType));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.ProductId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.WorkItemOperationId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.Data));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.EquipmentConfigurationIds));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.CoverageShape));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.ContextItems));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.Description));
    }
  }
}
