using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class HitchPointType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.HitchPoint), Constants.UseDefaults);
      type.AddField(631, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.HitchPoint.Id));
      type.AddField(632, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.HitchPoint.HitchTypeEnum));
      type.AddField(840, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.HitchPoint.ReferencePoint));
    }
  }
}
