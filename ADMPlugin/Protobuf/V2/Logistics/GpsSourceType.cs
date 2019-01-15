using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class GpsSourceType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.SourceType));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.EstimatedPrecision));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.HorizontalAccuracy));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.VerticalAccuracy));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.NumberOfSatellites));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.GpsSource.GpsUtcTime));
    }
  }
}
