using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class LexicalizationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.Lexicalization), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Lexicalization.Text));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Lexicalization.LanguageId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Lexicalization.GeoPoliticalContextIds));
    }
  }
}
