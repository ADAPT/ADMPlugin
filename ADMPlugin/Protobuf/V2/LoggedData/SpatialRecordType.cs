using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class SpatialRecordType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(SpatialRecord), Constants.UseDefaults);
      type.AddField(1, nameof(SpatialRecord.Geometry));
      type.AddField(2, nameof(SpatialRecord.Timestamp));
      type.AddField(3, "_meterValues");
      type.AddField(4, "_appliedLatencyValues");
    }
  }
}
