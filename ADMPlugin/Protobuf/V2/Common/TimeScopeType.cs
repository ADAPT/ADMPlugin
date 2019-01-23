using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class TimeScopeType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Description));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.DateContext));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.TimeStamp1));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.TimeStamp2));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Location1));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Location2));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.TimeScope.Duration));
    }
  }
}
