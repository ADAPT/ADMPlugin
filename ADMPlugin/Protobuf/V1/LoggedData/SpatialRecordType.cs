using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class SpatialRecordType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(ApplicationDataModel.LoggedData.SpatialRecord), Constants.UseDefaults);
      type.AddField(83, nameof(ApplicationDataModel.LoggedData.SpatialRecord.Geometry));
      type.AddField(84, nameof(ApplicationDataModel.LoggedData.SpatialRecord.Timestamp));
      type.AddField(85, "_meterValues");
      type.AddField(86, "_appliedLatencyValues");
      type.AddField(87, nameof(ApplicationDataModel.LoggedData.SpatialRecord.SignalType));
    }
  }
}
