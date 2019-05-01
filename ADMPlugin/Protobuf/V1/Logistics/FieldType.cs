using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Logistics
{
  public static class FieldType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field), Constants.UseDefaults);
      type.AddField(413, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Id));
      type.AddField(414, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Description));
      type.AddField(415, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.FarmId));
      type.AddField(416, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Area));
      type.AddField(417, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.ActiveBoundaryId));
      type.AddField(418, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.ContextItems));
      type.AddField(419, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Slope));
      type.AddField(420, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.Aspect));
      type.AddField(421, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.SlopeLength));
      type.AddField(422, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.GuidanceGroupIds));
      type.AddField(825, nameof(AgGateway.ADAPT.ApplicationDataModel.Logistics.Field.TimeScopes));
    }
  }
}
