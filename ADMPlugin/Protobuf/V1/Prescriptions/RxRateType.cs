using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class RxRateType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxRate), Constants.UseDefaults);
      type.AddField(741, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxRate.Rate));
      type.AddField(742, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxRate.RxProductLookupId));
    }
  }
}
