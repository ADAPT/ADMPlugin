using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class ModelScopeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope), Constants.UseDefaults);
      type.AddField(587, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.Id));
      type.AddField(588, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.Code));
      type.AddField(589, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.Description));
      type.AddField(590, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ModelScope.ModelScopeType));
    }
  }
}
