using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class RasterGridPrescriptionType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription), Constants.UseDefaults);
      type.AddField(735, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.Origin));
      type.AddField(736, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.RowCount));
      type.AddField(737, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.ColumnCount));
      type.AddField(738, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.CellWidth));
      type.AddField(739, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.CellHeight));
      type.AddField(740, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RasterGridPrescription.Rates));
    }
  }
}
