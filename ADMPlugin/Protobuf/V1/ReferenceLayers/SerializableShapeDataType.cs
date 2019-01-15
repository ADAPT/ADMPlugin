using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ReferenceLayers
{
  public static class SerializableShapeDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ADMPlugin.Models.SerializableShapeData), Constants.UseDefaults);
      type.AddField(851, nameof(AgGateway.ADAPT.ADMPlugin.Models.SerializableShapeData.shapeLookups));
    }
  }
}
