using System;
using System.Collections.Generic;
using System.Text;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;

namespace AgGateway.ADAPT.ADMPlugin.Converters
{
  public interface IReferenceLayerConverter
  {
    SerializableReferenceLayer ConvertToSerializableReferenceLayer(ReferenceLayer referenceLayer);

    ReferenceLayer ConvertToReferenceLayer(SerializableReferenceLayer serializableReferenceLayer);
  }
}
