using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.FieldBoundaries
{
  public static class HeadlandType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.Headland), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.Headland.Description));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.ConstantOffsetHeadland));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.DrivenHeadland));
    }
  }
}
