using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Prescriptions
{
  public static class RxProductLookupType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.ProductId));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.Representation)).AsReference = Constants.UseAsReference;
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Prescriptions.RxProductLookup.UnitOfMeasure)).AsReference = Constants.UseAsReference;
    }
  }
}
