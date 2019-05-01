using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class StatusUpdateType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate.Status));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate.Note));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate.TimeStamp));
    }
  }
}
