using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class NumericRepresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation), Constants.UseDefaults);
      type.AddField(130, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.DecimalDigits));
      type.AddField(131, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.MinValue));
      type.AddField(132, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.MaxValue));
      type.AddField(133, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation.Dimension));
    }
  }
}
