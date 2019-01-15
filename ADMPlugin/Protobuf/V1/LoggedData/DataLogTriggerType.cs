using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class DataLogTriggerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger), Constants.UseDefaults);
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.Id));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogMethod));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogDistanceInterval));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogTimeInterval));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogThresholdMinimum));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogThresholdMaximum));
      type.AddField(12, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogThresholdChange));
      type.AddField(13, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.ContextItems));
      type.AddField(14, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.LoggingLevel));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.Representation));
      type.AddField(847, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DeviceElementId));
    }
  }
}
