using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class UniqueIdType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId), Constants.UseDefaults);
      type.AddField(99, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.Id));
      type.AddField(820, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.IdType));
      type.AddField(101, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.Source));
      type.AddField(102, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.SourceType));
    }
  }
}
