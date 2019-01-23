using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Representations
{
  public static class EnumeratedRepresentationGroupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentationGroup), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentationGroup.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentationGroup.Description));
    }
  }
}
