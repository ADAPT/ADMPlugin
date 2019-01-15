using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Shapes
{
  public static class BoundingBoxType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MinY));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MinX));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MaxY));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Shapes.BoundingBox.MaxX));
    }
  }
}
