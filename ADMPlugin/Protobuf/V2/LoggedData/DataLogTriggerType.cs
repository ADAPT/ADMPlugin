using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class DataLogTriggerType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogMethod));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogDistanceInterval));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogTimeInterval));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogThresholdMinimum));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogThresholdMaximum));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DataLogThresholdChange));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.ContextItems));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.LoggingLevel));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.Representation)).AsReference = Constants.UseAsReference;
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.DataLogTrigger.DeviceElementId));
    }
  }
}
