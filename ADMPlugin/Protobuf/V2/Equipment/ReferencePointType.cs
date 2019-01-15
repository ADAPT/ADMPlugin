using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class ReferencePointType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.XOffset));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.YOffset));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.ZOffset));
    }
  }
}
