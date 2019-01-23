using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class PresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.Description));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.EntryFormatRegEx));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.DisplayFormatRegEx));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.GeoPoliticalContextIds));
    }
  }
}
