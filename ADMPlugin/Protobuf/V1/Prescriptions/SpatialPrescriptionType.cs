using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class SpatialPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription), Constants.UseDefaults);
      type.AddField(731, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription.BoundingBox));
      type.AddField(732, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription.OutOfFieldRate));
      type.AddField(733, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.SpatialPrescription.LossOfGpsRate));

      type.AddSubType(734, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription));
      type.AddSubType(746, typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.VectorPrescription));
    }
  }
}
