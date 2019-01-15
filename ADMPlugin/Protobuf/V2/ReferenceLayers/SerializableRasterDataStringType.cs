using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class SerializableRasterDataStringType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<string>), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<string>.values));
      type.AddField(2, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<string>.Representation)).AsReference = Constants.UseAsReference;
    }
  }
}
