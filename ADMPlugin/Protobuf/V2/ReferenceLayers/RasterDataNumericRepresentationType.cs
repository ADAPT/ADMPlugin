using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class RasterDataNumericRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation, AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation, AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>.Representation)).AsReference = Constants.UseAsReference;
    }
  }
}
