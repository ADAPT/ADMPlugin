using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class SpatialRecordType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SpatialRecord), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SpatialRecord.Geometry));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SpatialRecord.Timestamp));
      type.AddField(3, "_meterValues");
      type.AddField(4, "_appliedLatencyValues");
    }
  }
}
