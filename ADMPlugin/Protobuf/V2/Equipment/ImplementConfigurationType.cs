using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Equipment
{
  public static class ImplementConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.Width));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.TrackSpacing));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.PhysicalWidth));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.InGroundTurnRadius));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.ImplementLength));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.VerticalCuttingEdgeZOffset));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.GPSReceiverZOffset));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.YOffset));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.ControlPoint));
    }
  }
}
