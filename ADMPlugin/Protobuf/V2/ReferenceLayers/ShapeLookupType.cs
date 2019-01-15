using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class ShapeLookupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeLookup), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeLookup.Shape));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeLookup.SpatialAttribute));
    }
  }
}
