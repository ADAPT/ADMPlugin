using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class ContextItemType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem), Constants.UseDefaults);
      type.AddField(595, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.Code));
      type.AddField(90, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.Value));
      type.AddField(596, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.ValueUOM));
      type.AddField(597, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.NestedItems));
      type.AddField(498, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.TimeScopes));
    }
  }
}
