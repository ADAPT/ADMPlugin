using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.FieldBoundaries
{
  public static class HeadlandType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.Headland), Constants.UseDefaults);
      type.AddField(694, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.Headland.Description));

      type.AddSubType(695, typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.ConstantOffsetHeadland));
      type.AddSubType(697, typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.DrivenHeadland));
    }
  }
}
