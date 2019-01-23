using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class CompoundIdentifierType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.CompoundIdentifier), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.CompoundIdentifier.ReferenceId));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.CompoundIdentifier.UniqueIds));
    }
  }
}
