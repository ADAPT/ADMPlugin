using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class RasterDataEnumeratedRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation, AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation, AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>.Representation)).AsReference = Constants.UseAsReference;
    }
  }
}
