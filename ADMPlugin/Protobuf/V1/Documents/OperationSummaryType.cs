using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class OperationSummaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary), Constants.UseDefaults);
      type.AddField(831, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.Id));
      type.AddField(511, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.OperationType));
      type.AddField(512, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.ProductId));
      type.AddField(513, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.WorkItemOperationId));
      type.AddField(514, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.Data));
      type.AddField(832, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.EquipmentConfigurationIds));
      type.AddField(833, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.CoverageShape));
      type.AddField(834, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.OperationSummary.ContextItems));

      // Description added in v2
    }
  }
}
