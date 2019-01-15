using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.FieldBoundaries
{
  public static class InteriorBoundaryAttributeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute.Shape));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute.IsPassable));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries.InteriorBoundaryAttribute.Description));
    }
  }
}
