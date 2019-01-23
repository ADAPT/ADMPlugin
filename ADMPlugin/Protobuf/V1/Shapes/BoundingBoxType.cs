using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Shapes
{
  public static class BoundingBoxType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox), Constants.UseDefaults);
      type.AddField(324, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MinY));
      type.AddField(325, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MinX));
      type.AddField(326, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MaxY));
      type.AddField(327, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MaxX));
    }
  }
}
