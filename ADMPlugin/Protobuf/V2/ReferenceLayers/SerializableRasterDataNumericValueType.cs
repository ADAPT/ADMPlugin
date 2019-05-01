using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ReferenceLayers
{
  public static class SerializableRasterDataNumericValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>.values));
      type.AddField(2, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableRasterData<AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue>.Representation)).AsReference = Constants.UseAsReference;
    }
  }
}
