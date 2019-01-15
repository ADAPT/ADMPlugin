using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class LanguageType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.Language), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Language.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Language.Code));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Language.Description));
    }
  }
}
