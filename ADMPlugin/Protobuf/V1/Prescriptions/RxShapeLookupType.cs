using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class RxShapeLookupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxShapeLookup), Constants.UseDefaults);
      type.AddField(744, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxShapeLookup.Shape));
      type.AddField(745, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxShapeLookup.Rates));
    }
  }
}
