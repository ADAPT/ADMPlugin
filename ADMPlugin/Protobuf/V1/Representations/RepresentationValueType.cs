using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Representations
{
  public static class RepresentationValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue), Constants.UseDefaults);
      type.AddField(121, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue.Code));
      type.AddField(122, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue.Designator));
      type.AddField(123, nameof(AgGateway.ADAPT.ApplicationDataModel.Representations.RepresentationValue.Color));

      type.AddSubType(124, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedValue));
      type.AddSubType(134, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentationValue));
      type.AddSubType(141, typeof(AgGateway.ADAPT.ApplicationDataModel.Representations.StringValue));
    }
  }
}
