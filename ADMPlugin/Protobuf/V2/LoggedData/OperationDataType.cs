using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class OperationDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(ApplicationDataModel.LoggedData.OperationData), Constants.UseDefaults);
      type.AddField(1, nameof(ApplicationDataModel.LoggedData.OperationData.Id));
      type.AddField(2, nameof(ApplicationDataModel.LoggedData.OperationData.LoadId));
      type.AddField(3, nameof(ApplicationDataModel.LoggedData.OperationData.OperationType));
      type.AddField(4, nameof(ApplicationDataModel.LoggedData.OperationData.PrescriptionId));
      type.AddField(5, nameof(ApplicationDataModel.LoggedData.OperationData.ProductIds));
      type.AddField(6, nameof(ApplicationDataModel.LoggedData.OperationData.VarietyLocatorId));
      type.AddField(7, nameof(ApplicationDataModel.LoggedData.OperationData.WorkItemOperationId));
      type.AddField(8, nameof(ApplicationDataModel.LoggedData.OperationData.MaxDepth));
      type.AddField(9, nameof(ApplicationDataModel.LoggedData.OperationData.SpatialRecordCount));
      type.AddField(10, nameof(ApplicationDataModel.LoggedData.OperationData.EquipmentConfigurationIds));
      type.AddField(11, nameof(ApplicationDataModel.LoggedData.OperationData.ContextItems));
    }
  }
}
