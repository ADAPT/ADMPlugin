using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class RasterReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.Origin));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.RowCount));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.ColumnCount));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.CellWidth));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.CellHeight));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.EnumeratedRasterValues));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.StringRasterValues));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.NumericRasterValues));
    }
  }
}
