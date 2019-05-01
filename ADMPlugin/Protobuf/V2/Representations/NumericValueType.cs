using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Representations
{
  public static class NumericValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue.Value));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericValue.UnitOfMeasure)).AsReference = Constants.UseAsReference;
    }
  }
}
