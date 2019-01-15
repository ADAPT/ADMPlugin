using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class GeoPoliticalContextType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext.Code));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.GeoPoliticalContext.Description));
    }
  }
}
