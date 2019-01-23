using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.ADM
{
  public static class ProprietaryValueType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.ADM.ProprietaryValue), Constants.UseDefaults);
      type.AddField(181, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.ProprietaryValue.Key));
      type.AddField(182, nameof(AgGateway.ADAPT.ApplicationDataModel.ADM.ProprietaryValue.Value));
    }
  }
}
