using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class ShapeReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeReferenceLayer), Constants.UseDefaults);
      type.AddField(353, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeReferenceLayer.ShapeLookups));
    }
  }
}
