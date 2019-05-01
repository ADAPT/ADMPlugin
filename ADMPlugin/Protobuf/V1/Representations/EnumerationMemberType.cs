using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class EnumerationMemberType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember), Constants.UseDefaults);
      type.AddField(109, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember.Code));
      type.AddField(110, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumerationMember.Value));
    }
  }
}
