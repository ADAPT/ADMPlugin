using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class NumericWorkingDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData.UnitOfMeasure)).AsReference = Constants.UseAsReference;
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData.Values));
    }
  }
}
