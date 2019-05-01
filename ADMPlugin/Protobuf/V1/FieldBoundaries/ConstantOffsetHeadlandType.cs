using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.FieldBoundaries
{
  public static class ConstantOffsetHeadlandType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.ConstantOffsetHeadland), Constants.UseDefaults);
      type.AddField(696, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.ConstantOffsetHeadland.Value));
    }
  }
}
