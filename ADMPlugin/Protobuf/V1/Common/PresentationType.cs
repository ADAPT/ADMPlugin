using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class PresentationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation), Constants.UseDefaults);
      type.AddField(591, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.Description));
      type.AddField(592, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.EntryFormatRegEx));
      type.AddField(593, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.DisplayFormatRegEx));
      type.AddField(594, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.Presentation.GeoPoliticalContextIds));
    }
  }
}
