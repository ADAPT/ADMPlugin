using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Prescriptions
{
  public static class PrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.OperationType));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.FieldId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.CropZoneId));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.RxProductLookups));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.ProductIds));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.ContextItems));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.TimeScopes));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.Prescription.PersonRoles));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.ManualPrescription));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription));
    }
  }
}
