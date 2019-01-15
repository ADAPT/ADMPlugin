using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class SectionSummaryType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary), Constants.UseDefaults);
      type.AddField(79, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.Id));
      type.AddField(80, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.SectionId));
      type.AddField(81, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.TotalDistanceTravelled));
      type.AddField(82, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.SectionSummary.TotalElapsedTime));
    }
  }
}
