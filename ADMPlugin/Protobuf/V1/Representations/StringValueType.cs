using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class StringValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringValue), Constants.UseDefaults);
      type.AddField(142, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringValue.Representation));
      type.AddField(143, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringValue.Value));
    }
  }
}
