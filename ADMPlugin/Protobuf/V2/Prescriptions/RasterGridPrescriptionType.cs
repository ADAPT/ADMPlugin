using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Prescriptions
{
  public static class RasterGridPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.Origin));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.RowCount));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.ColumnCount));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.CellWidth));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.CellHeight));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.Rates));
    }
  }
}
