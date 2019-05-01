using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class ContextItemEnumItemType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Value));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Version));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Description));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.AgGlossaryURL)).AsReference = Constants.UseAsReference;
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.AgrovocURL)).AsReference = Constants.UseAsReference;
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Lexicalizations));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemEnumItem.Properties));
    }
  }
}
