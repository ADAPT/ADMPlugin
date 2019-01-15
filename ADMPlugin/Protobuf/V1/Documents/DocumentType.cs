using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class DocumentType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document), Constants.UseDefaults);
      type.AddField(355, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Id));
      type.AddField(356, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.ContextItems));
      type.AddField(357, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.CropIds));
      type.AddField(358, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.CropZoneIds));
      type.AddField(359, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Description));
      type.AddField(360, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.EstimatedArea));
      type.AddField(361, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.FarmIds));
      type.AddField(362, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.FieldIds));
      type.AddField(363, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.GrowerId));
      type.AddField(364, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Notes));
      type.AddField(365, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.PersonRoleIds));
      type.AddField(821, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.TimeScopes));
      type.AddField(367, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Version));

      type.AddSubType(223, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Plan));
      type.AddSubType(224, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Recommendation));
      type.AddSubType(253, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkOrder));
      type.AddSubType(222, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkRecord));
    }
  }
}
