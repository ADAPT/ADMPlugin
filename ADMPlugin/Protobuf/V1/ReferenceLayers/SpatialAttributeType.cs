using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class SpatialAttributeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.SpatialAttribute), Constants.UseDefaults);
      type.AddField(354, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.SpatialAttribute.Values));
    }
  }
}
