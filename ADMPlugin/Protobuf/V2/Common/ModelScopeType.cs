using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class ModelScopeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.Code));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.Description));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.ModelScopeType));
    }
  }
}
