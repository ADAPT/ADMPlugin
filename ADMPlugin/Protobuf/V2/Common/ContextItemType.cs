using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class ContextItemType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.Code));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.Value));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.ValueUOM));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.NestedItems));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItem.TimeScopes));
    }
  }
}
