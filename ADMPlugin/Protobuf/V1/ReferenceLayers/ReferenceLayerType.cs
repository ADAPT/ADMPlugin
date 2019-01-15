using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class ReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer), Constants.UseDefaults);
      type.AddField(333, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.Id));
      type.AddField(334, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.Description));
      type.AddField(335, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.LayerType));
      type.AddField(336, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.TimeScopes));
      type.AddField(337, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.BoundingPolygon));
      type.AddField(338, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.ContextItems));
      type.AddField(339, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.FieldIds));
      type.AddField(340, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.CropZoneIds));

      type.AddSubType(341, typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer));
      type.AddSubType(352, typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeReferenceLayer));
    }
  }
}
