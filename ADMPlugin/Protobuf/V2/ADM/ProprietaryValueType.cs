using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.ADM
{
  public static class ProprietaryValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ADM.ProprietaryValue), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.ProprietaryValue.Key));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.ProprietaryValue.Value));
    }
  }
}
