using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class SerializableRasterDataEnumerationMemberType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>.values));
      type.AddField(2, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>.Representation)).AsReference = Constants.UseAsReference;
    }
  }
}
