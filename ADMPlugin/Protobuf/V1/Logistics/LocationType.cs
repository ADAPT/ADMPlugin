using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class LocationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location), Constants.UseDefaults);
      type.AddField(436, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location.Position));
      type.AddField(437, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location.ContextItems));
      type.AddField(438, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Location.GpsSource));
    }
  }
}
