using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class NumericRepresentationValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue), Constants.UseDefaults);
      type.AddField(135, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue.Representation));
      type.AddField(136, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue.Value));
      type.AddField(137, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue.UserProvidedUnitOfMeasure));
    }
  }
}
