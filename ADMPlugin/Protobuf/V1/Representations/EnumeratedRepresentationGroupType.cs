using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class EnumeratedRepresentationGroupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentationGroup), Constants.UseDefaults);
      type.AddField(119, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentationGroup.Id));
      type.AddField(120, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentationGroup.Description));
    }
  }
}
