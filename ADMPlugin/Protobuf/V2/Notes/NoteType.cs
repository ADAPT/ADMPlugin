using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Notes
{
  public static class NoteType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.Description));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.Value));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.TimeStamps));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Notes.Note.SpatialContext));
    }
  }
}
