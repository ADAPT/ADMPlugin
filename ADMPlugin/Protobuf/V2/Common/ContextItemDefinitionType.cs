using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class ContextItemDefinitionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Id));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.ParentId));
      type.AddField(16, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Code));
      type.AddField(17, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Version));
      type.AddField(18, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.ValueType));
      type.AddField(19, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Description));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Keywords));
      type.AddField(20, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.AgGlossaryURL)).AsReference = Constants.UseAsReference;
      type.AddField(21, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.AgrovocURL)).AsReference = Constants.UseAsReference;
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Lexicalizations));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Properties));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.NestedDefIds));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.Presentations));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.EnumItems));
      type.AddField(22, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.DefaultUOM));
      type.AddField(23, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.AllowConversion));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.TimeScopes));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.ModelScopeIds));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.ContextItemDefinition.GeoPoliticalContextIds));
    }
  }
}
