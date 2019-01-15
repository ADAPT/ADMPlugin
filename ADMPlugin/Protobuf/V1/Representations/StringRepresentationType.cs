using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class StringRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringRepresentation), Constants.UseDefaults);
      type.AddField(139, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringRepresentation.MinCharacters));
      type.AddField(140, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringRepresentation.MaxCharacters));
    }
  }
}
