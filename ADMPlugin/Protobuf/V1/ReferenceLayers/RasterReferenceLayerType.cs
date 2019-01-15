using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class RasterReferenceLayerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer), Constants.UseDefaults);
      type.AddField(342, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.Origin));
      type.AddField(343, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.RowCount));
      type.AddField(344, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.ColumnCount));
      type.AddField(345, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.CellWidth));
      type.AddField(346, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.CellHeight));
      type.AddField(347, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.EnumeratedRasterValues));
      type.AddField(348, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.StringRasterValues));
      type.AddField(349, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterReferenceLayer.NumericRasterValues));
    }
  }
}
