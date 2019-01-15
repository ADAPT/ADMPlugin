using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class StampedMeteredValuesType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.StampedMeteredValues), Constants.UseDefaults);
      type.AddField(682, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StampedMeteredValues.Values));
      type.AddField(683, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StampedMeteredValues.Stamp));
    }
  }
}
