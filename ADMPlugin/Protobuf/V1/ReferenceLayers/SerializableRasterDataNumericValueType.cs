using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class SerializableRasterDataNumericValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>), Constants.UseDefaults);
      type.AddField(468, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>.values));
      type.AddField(471, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>.Representation));
    }
  }
}
