using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class EnumeratedWorkingDataType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.EnumeratedWorkingData), Constants.UseDefaults);
      type.AddField(483, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.EnumeratedWorkingData.ValueCodes));
    }
  }
}
