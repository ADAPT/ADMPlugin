using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class RasterDataEnumeratedRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation, AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>), Constants.UseDefaults);
      type.AddField(463, nameof(AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers.RasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation, AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>.Representation));
    }
  }
}
