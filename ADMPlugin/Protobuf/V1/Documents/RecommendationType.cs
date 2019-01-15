using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class RecommendationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Recommendation), Constants.UseDefaults);
      type.AddField(529, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Recommendation.WorkItemIds));
    }
  }
}
