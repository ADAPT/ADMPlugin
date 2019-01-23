using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class DocumentType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.ContextItems));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.CropIds));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.CropZoneIds));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Description));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.EstimatedArea));
      type.AddField(7, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.FarmIds));
      type.AddField(8, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.FieldIds));
      type.AddField(9, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.GrowerId));
      type.AddField(10, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Notes));
      type.AddField(11, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.PersonRoleIds));
      type.AddField(12, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.TimeScopes));
      type.AddField(15, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.Document.Version));

      type.AddSubType(101, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Plan));
      type.AddSubType(102, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.Recommendation));
      type.AddSubType(103, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkOrder));
      type.AddSubType(104, typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.WorkRecord));
    }
  }
}
