using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class WorkingDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.DeviceElementUseId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.Representation)).AsReference = Constants.UseAsReference;
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.AppliedLatency));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.WorkingData.ReportedLatency));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.EnumeratedWorkingData));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData));
    }
  }
}
