using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Prescriptions
{
  public static class RxShapeLookupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxShapeLookup), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxShapeLookup.Shape));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxShapeLookup.Rates));
    }
  }
}
