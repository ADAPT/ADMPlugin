using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class LanguageType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.Language), Constants.UseDefaults);
      type.AddField(581, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Language.Id));
      type.AddField(582, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Language.Code));
      type.AddField(583, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Language.Description));
    }
  }
}
