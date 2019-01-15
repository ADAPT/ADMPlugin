using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class OperationDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData), Constants.UseDefaults);
      type.AddField(60, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.Id));
      type.AddField(63, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.LoadId));
      type.AddField(64, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.OperationType));
      type.AddField(65, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.PrescriptionId));
      type.AddField(66, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.ProductIds));
      type.AddField(67, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.VarietyLocatorId));
      type.AddField(68, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.WorkItemOperationId));
      type.AddField(69, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.MaxDepth));
      type.AddField(70, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.SpatialRecordCount));
      type.AddField(551, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.OperationData.EquipmentConfigurationIds));
    }
  }
}
