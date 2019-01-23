using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class StatusUpdateType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate), Constants.UseDefaults);
      type.AddField(225, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate.Status));
      type.AddField(530, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate.Note));
      type.AddField(227, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.StatusUpdate.TimeStamp));
    }
  }
}
