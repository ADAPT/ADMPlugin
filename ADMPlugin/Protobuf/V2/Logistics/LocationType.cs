using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class LocationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location.Position));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location.ContextItems));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location.GpsSource));
    }
  }
}
