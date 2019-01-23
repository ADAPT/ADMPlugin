using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class ManualPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription), Constants.UseDefaults);
      type.AddField(725, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.ProductUses));
      type.AddField(726, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.TotalArea));
      type.AddField(727, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.TankAmount));
      type.AddField(728, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.TotalTanks));
      type.AddField(729, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.ApplicationStrategy));
    }
  }
}
