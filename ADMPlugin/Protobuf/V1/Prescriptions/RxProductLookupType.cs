using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Prescriptions
{
  public static class RxProductLookupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup), Constants.UseDefaults);
      type.AddField(712, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.Id));
      type.AddField(713, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.ProductId));
      type.AddField(714, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.Representation));
      type.AddField(715, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.UnitOfMeasure));
    }
  }
}
