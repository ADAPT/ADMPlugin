using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class NumericWorkingDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData), Constants.UseDefaults);
      type.AddField(489, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData.UnitOfMeasure));
      type.AddField(490, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.NumericWorkingData.Values));
    }
  }
}
