using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Representations
{
  public static class RepresentationValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue.Code));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue.Designator));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue.Color));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedValue));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringValue));
    }
  }
}
