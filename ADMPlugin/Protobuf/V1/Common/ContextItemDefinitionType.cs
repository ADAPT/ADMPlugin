using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class ContextItemDefinitionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition), Constants.UseDefaults);
      type.AddField(552, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Id));
      type.AddField(553, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.ParentId));
      type.AddField(554, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Code));
      type.AddField(555, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Version));
      type.AddField(556, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.ValueType));
      type.AddField(557, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Description));
      type.AddField(558, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Keywords));
      type.AddField(559, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.AgGlossaryURL));
      type.AddField(560, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.AgrovocURL));
      type.AddField(561, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Lexicalizations));
      type.AddField(562, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Properties));
      type.AddField(563, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.NestedDefIds));
      type.AddField(564, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Presentations));
      type.AddField(565, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.EnumItems));
      type.AddField(566, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.DefaultUOM));
      type.AddField(567, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.AllowConversion));
      type.AddField(568, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.TimeScopes));
      type.AddField(569, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.ModelScopeIds));
      type.AddField(570, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.GeoPoliticalContextIds));
    }
  }
}
