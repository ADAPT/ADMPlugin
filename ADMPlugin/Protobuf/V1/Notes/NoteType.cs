using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Notes
{
  public static class NoteType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note), Constants.UseDefaults);
      type.AddField(315, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.Description));
      type.AddField(316, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.Value));
      type.AddField(330, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.TimeStamps));
      type.AddField(318, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.SpatialContext));
    }
  }
}
