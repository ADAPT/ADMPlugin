using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace ADMPlugin
{
    public interface IBinaryWriter
    {
        void Write(IEnumerable<SpatialRecord> spatialRecords, IEnumerable<Meter> meters, string documentsPath);
        void Write(IEnumerable<Section> sections, string documentsPath);
        void Write(IEnumerable<Meter> meters, string documentsPath);
    }

    public class BinaryWriter : IBinaryWriter
    {
        public void Write(IEnumerable<SpatialRecord> spatialRecords, IEnumerable<Meter> meters, string documentsPath)
        {
            using (var writer = new System.IO.BinaryWriter(File.Open(documentsPath, FileMode.Create)))
            {
                foreach (var spatialRecord in spatialRecords)
                {
                    writer.Write(spatialRecord.Geometry.Id.ReferenceId);
                    writer.Write(spatialRecord.Geometry.Id.UniqueIds.Count);
                    foreach (var uniqueId in spatialRecord.Geometry.Id.UniqueIds)
                    {
                        writer.Write(Convert.ToByte(uniqueId.Id)); 
                        writer.Write(Convert.ToByte(uniqueId.Source)); 
                        writer.Write((int)uniqueId.CiTypeEnum); 
                        writer.Write((int)uniqueId.SourceType); 
                    }
                }
            }
        }

        public void Write(IEnumerable<Section> sections, string documentsPath)
        {
            throw new NotImplementedException();
        }

        public void Write(IEnumerable<Meter> meters, string documentsPath)
        {
            throw new NotImplementedException();
        }
    }
}
