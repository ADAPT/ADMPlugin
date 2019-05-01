using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class WorkRecordType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkRecord), Constants.UseDefaults);
      type.AddField(605, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkRecord.LoggedDataIds));
      type.AddField(606, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkRecord.SummariesIds));
    }
  }
}
