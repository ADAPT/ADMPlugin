using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class SectionConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration.SectionWidth));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration.LateralOffset));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration.InlineOffset));
    }
  }
}
