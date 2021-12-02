using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class SpatialRecordType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(ApplicationDataModel.LoggedData.SpatialRecord), Constants.UseDefaults);
      type.AddField(1, nameof(ApplicationDataModel.LoggedData.SpatialRecord.Geometry));
      type.AddField(2, nameof(ApplicationDataModel.LoggedData.SpatialRecord.Timestamp));
      type.AddField(3, "_meterValues");
      type.AddField(4, "_appliedLatencyValues");
      type.AddField(5, nameof(ApplicationDataModel.LoggedData.SpatialRecord.SignalType));
    }
  }
}
