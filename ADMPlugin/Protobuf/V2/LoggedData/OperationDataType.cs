using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class OperationDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.LoadId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.OperationType));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.PrescriptionId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.ProductIds));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.VarietyLocatorId));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.WorkItemOperationId));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.MaxDepth));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.SpatialRecordCount));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.EquipmentConfigurationIds));
    }
  }
}
