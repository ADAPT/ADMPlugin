using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.LoggedData
{
  public static class LoadType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.TimeScopes));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.LoadNumber));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.LoadType));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.LoadQuantity));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.DestinationIds));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.LoggedData.Load.ContextItems));
    }
  }
}
