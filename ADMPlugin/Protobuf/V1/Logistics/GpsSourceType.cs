using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class GpsSourceType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource), Constants.UseDefaults);
      type.AddField(426, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.SourceType));
      type.AddField(427, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.EstimatedPrecision));
      type.AddField(428, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.HorizontalAccuracy));
      type.AddField(429, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.VerticalAccuracy));
      type.AddField(430, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.NumberOfSatellites));
      type.AddField(431, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.GpsUtcTime));
    }
  }
}
