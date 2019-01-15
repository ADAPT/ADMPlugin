using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Documents
{
  public static class DocumentCorrelationType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.RelationshipType));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.DocumentId));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.OriginatingDocumentId));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.TimeScopes));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Documents.DocumentCorrelation.PersonRoleIds));
    }
  }
}
