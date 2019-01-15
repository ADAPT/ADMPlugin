using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Prescriptions
{
  public static class ManualPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.ProductUses));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.TotalArea));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.TankAmount));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.TotalTanks));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription.ApplicationStrategy));
    }
  }
}
