using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class UniqueIdType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.IdType));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.Source)).AsReference = Constants.UseAsReference;
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UniqueId.SourceType));
    }
  }
}
