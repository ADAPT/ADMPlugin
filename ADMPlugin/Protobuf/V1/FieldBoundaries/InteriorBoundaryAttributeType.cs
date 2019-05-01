using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.FieldBoundaries
{
  public static class InteriorBoundaryAttributeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute), Constants.UseDefaults);
      // type.AddField(709, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute.ShapeIdRef)); Replaced by Shape in v2
      type.AddField(710, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute.IsPassable));
      type.AddField(711, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute.Description));
    }
  }
}
