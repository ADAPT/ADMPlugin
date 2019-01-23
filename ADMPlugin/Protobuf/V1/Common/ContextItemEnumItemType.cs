using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class ContextItemEnumItemType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem), Constants.UseDefaults);
      type.AddField(571, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Value));
      type.AddField(572, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Version));
      type.AddField(573, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Description));
      type.AddField(574, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.AgGlossaryURL));
      type.AddField(575, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.AgrovocURL));
      type.AddField(576, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Lexicalizations));
      type.AddField(577, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Properties));
    }
  }
}
