using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Equipment
{
  public static class ImplementConfigurationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration), Constants.UseDefaults);
      type.AddField(635, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.Width));
      type.AddField(636, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.TrackSpacing));
      type.AddField(637, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.PhysicalWidth));
      type.AddField(638, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.InGroundTurnRadius));
      type.AddField(639, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.ImplementLength));
      type.AddField(640, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.VerticalCuttingEdgeZOffset));
      type.AddField(641, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.GPSReceiverZOffset));
      type.AddField(642, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.YOffset));
      type.AddField(643, nameof(AgGateway.ADAPT.ApplicationDataModel.Equipment.ImplementConfiguration.ControlPoint));
    }
  }
}
