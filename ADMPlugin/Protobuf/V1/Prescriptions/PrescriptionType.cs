using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class PrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription), Constants.UseDefaults);
      type.AddField(716, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.Id));
      type.AddField(717, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.Description));
      type.AddField(718, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.OperationType));
      type.AddField(719, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.FieldId));
      type.AddField(720, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.CropZoneId));
      type.AddField(721, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.RxProductLookups));
      type.AddField(722, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.ProductIds));
      type.AddField(723, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.ContextItems));

      // TimeScopes and PersonRoles added in v2

      type.AddSubType(724, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription));
      type.AddSubType(730, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription));
    }
  }
}
