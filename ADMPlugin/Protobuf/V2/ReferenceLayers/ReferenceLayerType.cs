using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class ReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.LayerType));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.TimeScopes));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.BoundingPolygon));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.ContextItems));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.FieldIds));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ReferenceLayer.CropZoneIds));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.ShapeReferenceLayer));
    }
  }
}
