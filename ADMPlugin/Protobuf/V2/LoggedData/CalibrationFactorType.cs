using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class CalibrationFactorType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.CalibrationFactor), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.CalibrationFactor.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.CalibrationFactor.MeterId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.CalibrationFactor.TimeScopeIds));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.CalibrationFactor.Value));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.CalibrationFactor.OperationDataId));
    }
  }
}
