using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class EnumeratedValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedValue), Constants.UseDefaults);
      type.AddField(125, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedValue.Representation));
      type.AddField(126, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedValue.Value));
    }
  }
}
