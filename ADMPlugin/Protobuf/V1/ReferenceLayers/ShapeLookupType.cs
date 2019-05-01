using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class ShapeLookupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeLookup), Constants.UseDefaults);
      type.AddField(350, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeLookup.Shape));
      type.AddField(351, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeLookup.SpatialAttribute));
    }
  }
}
