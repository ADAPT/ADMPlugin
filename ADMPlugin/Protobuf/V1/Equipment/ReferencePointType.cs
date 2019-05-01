using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class ReferencePointType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint), Constants.UseDefaults);
      type.AddField(668, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.Id));
      type.AddField(669, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.XOffset));
      type.AddField(670, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.YOffset));
      type.AddField(671, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ReferencePoint.ZOffset));
    }
  }
}
