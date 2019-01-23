using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class SpatialRecordType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SpatialRecord), Constants.UseDefaults);
      type.AddField(83, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SpatialRecord.Geometry));
      type.AddField(84, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SpatialRecord.Timestamp));
      type.AddField(85, "_meterValues");
      type.AddField(86, "_appliedLatencyValues");
    }
  }
}
