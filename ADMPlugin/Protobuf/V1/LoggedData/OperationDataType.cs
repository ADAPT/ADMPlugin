using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class OperationDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(ApplicationDataModel.LoggedData.OperationData), Constants.UseDefaults);
      type.AddField(60, nameof(ApplicationDataModel.LoggedData.OperationData.Id));
      type.AddField(63, nameof(ApplicationDataModel.LoggedData.OperationData.LoadId));
      type.AddField(64, nameof(ApplicationDataModel.LoggedData.OperationData.OperationType));
      type.AddField(65, nameof(ApplicationDataModel.LoggedData.OperationData.PrescriptionId));
      type.AddField(66, nameof(ApplicationDataModel.LoggedData.OperationData.ProductIds));
      type.AddField(67, nameof(ApplicationDataModel.LoggedData.OperationData.VarietyLocatorId));
      type.AddField(68, nameof(ApplicationDataModel.LoggedData.OperationData.WorkItemOperationId));
      type.AddField(69, nameof(ApplicationDataModel.LoggedData.OperationData.MaxDepth));
      type.AddField(70, nameof(ApplicationDataModel.LoggedData.OperationData.SpatialRecordCount));
      type.AddField(551, nameof(ApplicationDataModel.LoggedData.OperationData.EquipmentConfigurationIds));
      type.AddField(598, nameof(ApplicationDataModel.LoggedData.OperationData.ContextItems));
    }
  }
}
