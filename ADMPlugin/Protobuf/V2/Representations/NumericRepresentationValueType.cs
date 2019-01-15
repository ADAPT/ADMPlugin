using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Representations
{
  public static class NumericRepresentationValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue.Representation)).AsReference = Constants.UseAsReference;
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue.Value));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue.UserProvidedUnitOfMeasure)).AsReference = Constants.UseAsReference;
    }
  }
}
