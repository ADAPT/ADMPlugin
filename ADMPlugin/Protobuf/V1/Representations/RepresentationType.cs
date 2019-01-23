using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class RepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation), Constants.UseDefaults);
      type.AddField(111, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.Id));
      type.AddField(112, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.CodeSource));
      type.AddField(113, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.Code));
      type.AddField(114, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.Description));
      type.AddField(115, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.LongDescription));

      type.AddSubType(116, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation));
      type.AddSubType(129, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation));
      type.AddSubType(138, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringRepresentation));
    }
  }
}
