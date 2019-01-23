using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Representations
{
  public static class NumericRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.DecimalDigits));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.MinValue));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.MaxValue));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.Dimension));
    }
  }
}
