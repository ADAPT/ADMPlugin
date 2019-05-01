using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class VectorPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.VectorPrescription), Constants.UseDefaults);
      type.AddField(747, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.VectorPrescription.RxShapeLookups));
    }
  }
}
