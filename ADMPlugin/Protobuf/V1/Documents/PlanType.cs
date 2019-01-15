using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class PlanType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Plan), Constants.UseDefaults);
      type.AddField(528, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Plan.WorkItemIds));
    }
  }
}
