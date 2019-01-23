using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V2.Common
{
  public static class UnitOfMeasureType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure), Constants.UseDefaults);
      type.AddField(1, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Id));
      type.AddField(2, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Code));
      type.AddField(3, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Dimension));
      type.AddField(4, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.IsReferenceForDimension));
      type.AddField(5, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Scale));
      type.AddField(6, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Offset));
    }
  }
}
