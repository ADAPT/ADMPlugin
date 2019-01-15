using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class CompoundIdentifierType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.CompoundIdentifier), Constants.UseDefaults);
      type.AddField(87, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.CompoundIdentifier.ReferenceId));
      type.AddField(88, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.CompoundIdentifier.UniqueIds));
    }
  }
}
