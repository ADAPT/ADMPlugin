using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using ProtoBuf;
using ProtoBuf.Meta;

namespace ADMPlugin
{
    public interface IProtobufSerializer
    {
        void Write<T>(string path, T content);
        void WriteSpatialRecords(string path, IEnumerable<SpatialRecord> spatialRecords);
        T Read<T>(string path);
        IEnumerable<SpatialRecord> ReadSpatialRecords(string path);
    }

    public class ProtobufSerializer : IProtobufSerializer
    {
        public ProtobufSerializer()
        {
            AddDataContracts();
        }

        public void Write<T>(string path, T content)
        {
            using (var fileStream = File.Open(path, FileMode.Create))
            {
                Serializer.Serialize(fileStream, content);
            }

        }

        public T Read<T>(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                return Serializer.Deserialize<T>(fileStream);
            }
        }

        public void WriteSpatialRecords(string path, IEnumerable<SpatialRecord> spatialRecords)
        {
            using (var fileStream = File.Open(path, FileMode.Create))
            {
                foreach (var spatialRecord in spatialRecords)
                {
                    Serializer.SerializeWithLengthPrefix(fileStream, spatialRecord, PrefixStyle.Base128, 1);
                }
            }
        }

        public IEnumerable<SpatialRecord> ReadSpatialRecords(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                while (!IsEndOfStream(fileStream))
                {
                    yield return Serializer.DeserializeWithLengthPrefix<SpatialRecord>(fileStream, PrefixStyle.Base128, 1);
                }
            }
        }

        private bool IsEndOfStream(FileStream fileStream)
        {
            return fileStream.Position + 20 > fileStream.Length;
        }

        private static void AddDataContracts()
        {
            if(HaveDataContractsBeenAdded())
                return;
            RuntimeTypeModel.Default.Add(typeof(SpatialRecord), false).Add("Geometry", "Timestamp", "_appliedLatencyValues", "_meterValues");

            RuntimeTypeModel.Default.Add(typeof (CompoundIdentifier), false).Add("ReferenceId", "UniqueIds");
            RuntimeTypeModel.Default.Add(typeof (UniqueId), false).Add("Id", "CiTypeEnum", "Source", "SourceType");

            RuntimeTypeModel.Default.Add(typeof (Representation), false).Add("Id", "CodeSource", "Code", "Description", "LongDescription");
            RuntimeTypeModel.Default[typeof (Representation)].AddSubType(108, typeof (NumericRepresentation));
            RuntimeTypeModel.Default[typeof (Representation)].AddSubType(109, typeof (StringRepresentation));
            RuntimeTypeModel.Default[typeof (Representation)].AddSubType(110, typeof (EnumeratedRepresentation));
            RuntimeTypeModel.Default.Add(typeof (NumericRepresentation), false).Add("DecimalDigits", "MinValue", "MaxValue", "Dimension");
            RuntimeTypeModel.Default.Add(typeof(StringRepresentation), false).Add("MinCharacters", "MaxCharacters");
            RuntimeTypeModel.Default.Add(typeof(EnumeratedRepresentation), false).Add("EnumeratedMembers", "RepresentationGroupId");
            RuntimeTypeModel.Default.Add(typeof(EnumerationMember), false).Add("Code", "Value");

            RuntimeTypeModel.Default.Add(typeof (RepresentationValue), false).Add("Code", "Designator", "Color");
            RuntimeTypeModel.Default[typeof (RepresentationValue)].AddSubType(111, typeof (NumericRepresentationValue));
            RuntimeTypeModel.Default[typeof (RepresentationValue)].AddSubType(112, typeof (StringValue));
            RuntimeTypeModel.Default[typeof (RepresentationValue)].AddSubType(113, typeof (EnumeratedValue));
            RuntimeTypeModel.Default.Add(typeof (NumericRepresentationValue), false).Add("Representation", "Value", "UserProvidedUnitOfMeasure");
            RuntimeTypeModel.Default.Add(typeof (StringValue), false).Add("Representation", "Value");
            RuntimeTypeModel.Default.Add(typeof (EnumeratedValue), false).Add("Representation", "Value");

            RuntimeTypeModel.Default.Add(typeof (NumericValue), false).Add("Value", "UnitOfMeasure");
            RuntimeTypeModel.Default.Add(typeof (UnitOfMeasure), false).Add("Id", "Code", "Dimension", "IsReferenceForDimension", "Scale", "Offset");

            RuntimeTypeModel.Default.Add(typeof (Section), false).Add("Id", "OperationDataId", "Depth", "Order", "SectionWidth", "TotalDistanceTravelled", "TotalElapsedTime");
            RuntimeTypeModel.Default.Add(typeof (Meter), false).Add("Id", "SectionId", "Representation", "AppliedLatency", "ReportedLatency", "TriggerId");
            RuntimeTypeModel.Default[typeof(Meter)].AddSubType(114, typeof(EnumeratedMeter));
            RuntimeTypeModel.Default[typeof(Meter)].AddSubType(115, typeof(NumericMeter));
            RuntimeTypeModel.Default.Add(typeof(NumericMeter), false).Add("UnitOfMeasure", "Values");
            RuntimeTypeModel.Default.Add(typeof(EnumeratedMeter), false).Add("ValueCodes");

            RuntimeTypeModel.Default.Add(typeof (Shape), true).Add("Id", "Type");
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(10, typeof (LinearRing));
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(11, typeof (LineString));
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(12, typeof (MultiLineString));
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(13, typeof (MultiPoint));
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(14, typeof (MultiPolygon));
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(15, typeof (Point));
            RuntimeTypeModel.Default[typeof (Shape)].AddSubType(16, typeof (Polygon));
            RuntimeTypeModel.Default.Add(typeof (LinearRing), false).Add("Points");
            RuntimeTypeModel.Default.Add(typeof (LineString), false).Add("Points");
            RuntimeTypeModel.Default.Add(typeof (MultiLineString), false).Add("LineStrings");
            RuntimeTypeModel.Default.Add(typeof (MultiPoint), false).Add("Points");
            RuntimeTypeModel.Default.Add(typeof (MultiPolygon), false).Add("Polygons");
            RuntimeTypeModel.Default.Add(typeof (Point), false).Add("X", "Y", "Z");
            RuntimeTypeModel.Default.Add(typeof (Polygon), false).Add("ExteriorRing", "InteriorRings");
        }

        private static bool HaveDataContractsBeenAdded()
        {
            var schema = RuntimeTypeModel.Default.GetSchema(typeof(SpatialRecord));

            return schema != "package AgGateway.ADAPT.ApplicationDataModel.LoggedData;\r\n\r\nmessage SpatialRecord {\r\n}\r\n";
        }
    }
}
