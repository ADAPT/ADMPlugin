using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class TimeScopeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope), Constants.UseDefaults);
      type.AddField(95, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Id));
      type.AddField(96, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Description));
      type.AddField(499, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.DateContext));
      type.AddField(500, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.TimeStamp1));
      type.AddField(501, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.TimeStamp2));
      type.AddField(502, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Location1));
      type.AddField(503, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Location2));
      type.AddField(504, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Duration));
    }
  }
}
