using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Logistics
{
  public static class FieldType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.FarmId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Area));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.ActiveBoundaryId));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.ContextItems));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Slope));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Aspect));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.SlopeLength));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.GuidanceGroupIds));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.TimeScopes));
    }
  }
}
