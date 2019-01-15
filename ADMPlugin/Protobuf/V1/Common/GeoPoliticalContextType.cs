using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class GeoPoliticalContextType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext), Constants.UseDefaults);
      type.AddField(578, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext.Id));
      type.AddField(579, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext.Code));
      type.AddField(580, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext.Description));
    }
  }
}
