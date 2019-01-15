using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class SectionSummaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.SectionId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.TotalDistanceTravelled));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.TotalElapsedTime));
    }
  }
}
