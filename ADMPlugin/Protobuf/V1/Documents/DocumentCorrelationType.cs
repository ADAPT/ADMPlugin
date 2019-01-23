using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Documents
{
  public static class DocumentCorrelationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation), Constants.UseDefaults);
      type.AddField(216, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.Id));
      type.AddField(217, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.RelationshipType));
      type.AddField(218, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.DocumentId));
      type.AddField(527, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.OriginatingDocumentId));
      type.AddField(328, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.TimeScopes));
      type.AddField(221, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.PersonRoleIds));
    }
  }
}
