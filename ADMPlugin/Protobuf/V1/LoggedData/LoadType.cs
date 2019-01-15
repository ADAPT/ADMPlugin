using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.LoggedData
{
  public static class LoadType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load), Constants.UseDefaults);
      type.AddField(26, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.Id));
      type.AddField(27, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.Description));
      // type.AddField(28, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.TimeScopeIds)); Swapped for timescopes in v2
      type.AddField(29, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.LoadNumber));
      type.AddField(30, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.LoadType));
      type.AddField(31, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.LoadQuantity));
      type.AddField(32, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.DestinationIds));
    }
  }
}
