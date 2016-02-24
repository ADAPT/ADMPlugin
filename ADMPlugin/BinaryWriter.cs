using System;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace ADMPlugin
{
    public interface IBinaryWriter
    {
        void Write(SpatialRecord spatialRecord, string documentsPath);
    }

    public class BinaryWriter : IBinaryWriter
    {
        public void Write(SpatialRecord spatialRecord, string documentsPath)
        {
            throw new NotImplementedException();
        }
    }
}
