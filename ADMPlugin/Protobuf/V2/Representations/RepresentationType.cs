using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Representations
{
  public static class RepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.CodeSource));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.Code));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.Description));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.Representation.LongDescription));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringRepresentation));
    }
  }
}
