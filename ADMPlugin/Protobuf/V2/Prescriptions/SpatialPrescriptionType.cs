using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Prescriptions
{
  public static class SpatialPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription.BoundingBox));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription.OutOfFieldRate));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription.LossOfGpsRate));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.VectorPrescription));
    }
  }
}
