using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class WorkingDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData), Constants.UseDefaults);
      type.AddField(476, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.Id));
      type.AddField(477, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.DeviceElementUseId));
      type.AddField(478, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.Representation));
      type.AddField(479, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.AppliedLatency));
      type.AddField(480, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.ReportedLatency));

      type.AddSubType(482, typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.EnumeratedWorkingData));
      type.AddSubType(488, typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData));
    }
  }
}
