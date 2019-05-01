using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class SerializableRasterDataEnumerationMemberType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>), Constants.UseDefaults);
      type.AddField(467, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>.values));
      type.AddField(470, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember>.Representation));
    }
  }
}
