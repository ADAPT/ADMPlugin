using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class EnumeratedRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation), Constants.UseDefaults);
      type.AddField(117, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation.EnumeratedMembers));
      type.AddField(118, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation.RepresentationGroupId));
    }
  }
}
