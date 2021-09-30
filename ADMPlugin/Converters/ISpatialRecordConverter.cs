using System.Collections.Generic;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ADMPlugin.Converters
{
    public interface ISpatialRecordConverter
    {
        IEnumerable<SpatialRecord> ConvertToSpatialRecords(IEnumerable<SerializableSpatialRecord> protobufSpatialRecords, IEnumerable<WorkingData> workingData);
        IEnumerable<SerializableSpatialRecord> ConvertToSerializableSpatialRecords(IEnumerable<SpatialRecord> spatialRecords, List<WorkingData> workingData);
    }
}
