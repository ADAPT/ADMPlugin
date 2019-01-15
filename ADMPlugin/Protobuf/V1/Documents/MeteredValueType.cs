using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class MeteredValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.MeteredValue), Constants.UseDefaults);
      type.AddField(509, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.MeteredValue.Value));
      type.AddField(510, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.MeteredValue.MeterId));
      // DeviceConfigerationId added in v2
    }
  }
}
