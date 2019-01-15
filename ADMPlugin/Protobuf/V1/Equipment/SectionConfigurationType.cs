using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class SectionConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration), Constants.UseDefaults);
      type.AddField(649, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration.SectionWidth));
      type.AddField(650, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration.LateralOffset));
      type.AddField(651, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.SectionConfiguration.InlineOffset));
    }
  }
}
