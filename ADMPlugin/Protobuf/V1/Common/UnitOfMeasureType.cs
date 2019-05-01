using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf.Meta;

namespace AgGateway.ADAPT.ADMPlugin.Protobuf.V1.Common
{
  public static class UnitOfMeasureType
  {
    public static void Configure(RuntimeTypeModel model)
    {
      var type = model.Add(typeof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure), Constants.UseDefaults);
      type.AddField(103, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Id));
      type.AddField(104, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Code));
      type.AddField(105, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Dimension));
      type.AddField(106, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.IsReferenceForDimension));
      type.AddField(107, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Scale));
      type.AddField(108, nameof(AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure.Offset));
    }
  }
}
