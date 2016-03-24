using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.FieldBoundaries;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
using AgGateway.ADAPT.ApplicationDataModel.Prescriptions;
using AgGateway.ADAPT.ApplicationDataModel.Products;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
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

            RuntimeTypeModel.Default.Add(typeof(Brand), false).Add("Id", "Description", "ManufacturerId", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(BoundingBox), false).Add("MinLatitude", "MinLongitude", "MaxLatitude", "MaxLongitude");
            RuntimeTypeModel.Default.Add(typeof(Catalog), false).Add("Brands", "Connectors", "Containers", "Crops", "CropProtectionProducts", "CropVarieties", "CropZones", "EquipmentConfigs", "Farms", "Fields", "FieldBoundaries", "Growers", "Ingredients", "GuidancePatterns", "GuidanceGroups", "Implements", "ImplementModels", "ImplementTypes", "ImplementConfigurations", "Description", "Persons", "PersonRoles", "ContactInfo", "Prescriptions", "FertilizerProducts", "ProductMixes", "TimeScopes", "Machines", "MachineModels", "MachineSeries", "MachineTypes", "MachineConfigurations");
            RuntimeTypeModel.Default.Add(typeof(Company), false).Add("Id", "Name", "ContactInfoId", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(CompoundIdentifier), false).Add("ReferenceId", "UniqueIds");
            RuntimeTypeModel.Default.Add(typeof(Connector), false).Add("Id", "ConnectorType", "ConnectorPointOffset");
            RuntimeTypeModel.Default.Add(typeof(Contact), false).Add("Number", "Type");
            RuntimeTypeModel.Default.Add(typeof(ContactInfo), false).Add("Id", "AddressLine1", "AddressLine2", "PoBoxNumber", "PostalCode", "City", "StateOrProvince", "Country", "CountryCode", "Contacts", "Location", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(Container), false).Add("Id", "ProductAmount", "Capacity", "ContextItems", "Description");
            RuntimeTypeModel.Default.Add(typeof(ContextItem), false).Add("ContextItemType", "Value", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(Crop), false).Add("Id", "Name", "ParentId", "ReferenceWeight", "StandardPayableMoisture", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(CropZone), false).Add("Id", "TimeScopeIds", "Description", "FieldId", "CropId", "Area", "BoundingRegion", "BoundarySource", "Notes", "GuidanceGroupIds", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(DataLogTrigger), false).Add("Id", "DataLogMethod", "DataLogDistanceInterval", "DataLogTimeInterval", "DataLogThresholdMinimum", "DataLogThresholdMaximum", "DataLogThresholdChange", "ContextItems", "LoggingLevel", "Representation", "SectionIds", "MeterIds");
            RuntimeTypeModel.Default.Add(typeof(DateWithContext), false).Add("TimeStamp", "DateContext", "Location");
            RuntimeTypeModel.Default.Add(typeof(EquipmentConfig), false).Add("Id", "TimeScope", "MachineConfigurationId", "ImplementConfigurationId", "Meters", "Sections", "Triggers");
            RuntimeTypeModel.Default.Add(typeof(Farm), false).Add("Id", "Description", "GrowerId", "ContactInfo", "TimeScopeIds", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(Field), false).Add("Id", "Description", "FarmId", "Area", "ActiveBoundaryId", "ContextItems", "Slope", "Aspect", "SlopeLength", "GuidanceGroupIds", "TimeScopeIds");
            RuntimeTypeModel.Default.Add(typeof(FieldBoundary), false).Add("Id", "Description", "FieldId", "SpatialData", "TimeScopeIds", "Headlands", "GpsSource", "OriginalEpsgCode", "InteriorBoundaryAttributes", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(GpsSource), false).Add("SourceType", "EstimatedPrecision", "HorizontalAccuracy", "VerticalAccuracy", "NumberOfSatellites", "GpsUtcTime");
            RuntimeTypeModel.Default.Add(typeof(Grower), false).Add("Id", "Name", "ContactInfo", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(GuidanceGroup), false).Add("Id", "Description", "GuidancePatternIds", "BoundingPolygon");
            RuntimeTypeModel.Default.Add(typeof(InteriorBoundaryAttribute), false).Add("ShapeIdRef", "IsPassable", "Description");
            RuntimeTypeModel.Default.Add(typeof(Location), false).Add("Position", "ContextItems", "GpsSource");
            RuntimeTypeModel.Default.Add(typeof(Note), false).Add("Description", "Value", "TimeStamp", "SpatialContext");
            RuntimeTypeModel.Default.Add(typeof(NumericValue), false).Add("Value", "UnitOfMeasure");
            RuntimeTypeModel.Default.Add(typeof(Person), false).Add("Id", "FirstName", "MiddleName", "LastName", "CombinedName", "ContactInfoId", "ContextItems");
            RuntimeTypeModel.Default.Add(typeof(PersonRole), false).Add("Id", "PersonId", "Role", "GrowerId", "ActiveScopes", "CompanyId");
            RuntimeTypeModel.Default.Add(typeof(ReferencePoint), false).Add("Id", "XOffset", "YOffset", "ZOffset");
            RuntimeTypeModel.Default.Add(typeof(RxRates), false).Add("RxRate");
            RuntimeTypeModel.Default.Add(typeof(RxRate), false).Add("Rate", "ProductId");
            RuntimeTypeModel.Default.Add(typeof(SpatialRecord), false).Add("Geometry", "Timestamp", "_appliedLatencyValues", "_meterValues");
            RuntimeTypeModel.Default.Add(typeof(TimeScope), false).Add("Id", "Description", "Stamp1", "Stamp2");
            RuntimeTypeModel.Default.Add(typeof(UniqueId), false).Add("Id", "CiTypeEnum", "Source", "SourceType");
            RuntimeTypeModel.Default.Add(typeof(UnitOfMeasure), false).Add("Id", "Code", "Dimension", "IsReferenceForDimension", "Scale", "Offset");

            RuntimeTypeModel.Default.Add(typeof(Headland), false).Add("Description");
            RuntimeTypeModel.Default[typeof(Headland)].AddSubType(101, typeof(DrivenHeadland));
            RuntimeTypeModel.Default[typeof(Headland)].AddSubType(102, typeof(ConstantOffsetHeadland));
            RuntimeTypeModel.Default.Add(typeof(DrivenHeadland), false).Add("SpatialData");
            RuntimeTypeModel.Default.Add(typeof(ConstantOffsetHeadland), false).Add("Value");

            RuntimeTypeModel.Default.Add(typeof(Ingredient), false).Add("Id", "Description", "ContextItems");
            RuntimeTypeModel.Default[typeof(Ingredient)].AddSubType(101, typeof(CropNutritionIngredient));
            RuntimeTypeModel.Default[typeof(Ingredient)].AddSubType(102, typeof(ActiveIngredient));
            RuntimeTypeModel.Default.Add(typeof(CropNutritionIngredient), false).Add("IngredientCode");
            RuntimeTypeModel.Default.Add(typeof(ActiveIngredient), false).Add("ModesOfAction");

            RuntimeTypeModel.Default.Add(typeof(GuidancePattern), false).Add("Id", "GuidancePatternType", "GpsSource", "OriginalEpsgCode", "Description", "SwathWidth", "PropagationDirection", "Extension", "NumbersOfSwathsLeft", "NumbersOfSwathsRight", "BoundingPolygon");
            RuntimeTypeModel.Default[typeof(GuidancePattern)].AddSubType(101, typeof(Spiral));
            RuntimeTypeModel.Default[typeof(GuidancePattern)].AddSubType(102, typeof(MultiAbLine));
            RuntimeTypeModel.Default[typeof(GuidancePattern)].AddSubType(103, typeof(CenterPivot));
            RuntimeTypeModel.Default[typeof(GuidancePattern)].AddSubType(104, typeof(APlus));
            RuntimeTypeModel.Default[typeof(GuidancePattern)].AddSubType(105, typeof(AbLine));
            RuntimeTypeModel.Default[typeof(GuidancePattern)].AddSubType(106, typeof(AbCurve));
            RuntimeTypeModel.Default.Add(typeof(Spiral), false).Add("Shape");
            RuntimeTypeModel.Default.Add(typeof(MultiAbLine), false).Add("AbLines");
            RuntimeTypeModel.Default.Add(typeof(CenterPivot), false).Add("StartPoint", "EndPoint", "Center");
            RuntimeTypeModel.Default.Add(typeof(APlus), false).Add("Point", "Heading");
            RuntimeTypeModel.Default.Add(typeof(AbLine), false).Add("A", "B", "Heading", "EastShiftComponent", "NorthShiftComponent");
            RuntimeTypeModel.Default.Add(typeof(AbCurve), false).Add("NumberOfSegments", "Heading", "EastShiftComponent", "NorthShiftComponent", "Shape");

            RuntimeTypeModel.Default.Add(typeof(Equipment), false).Add("Id", "Description", "SerialNumber", "ManufacturerId", "BrandId", "SeriesId", "ContextItems");
            RuntimeTypeModel.Default[typeof(Equipment)].AddSubType(100, typeof(Implement));
            RuntimeTypeModel.Default[typeof(Equipment)].AddSubType(101, typeof(Machine));
            RuntimeTypeModel.Default.Add(typeof(Implement), false).Add("ImplementTypeId", "ImplementModelId");
            RuntimeTypeModel.Default.Add(typeof(ImplementModel), false).Add("Id", "Description", "ImplementTypeId", "SeriesId", "BrandId");
            RuntimeTypeModel.Default.Add(typeof (ImplementType), false).Add("Id", "Description");//, "Type");
            RuntimeTypeModel.Default.Add(typeof(ImplementConfiguration), false).Add("Id", "TimeScope", "ImplementId", "Description", "Width", "TrackSpacing", "PhysicalWidth", "HitchType", "InGroundTurnRadius", "ImplementLength", "YOffset", "VerticalCuttingEdgeZOffset", "ConnectorIds", "ControlPoint", "GpsReceiverOffset");
            RuntimeTypeModel.Default.Add(typeof(Machine), false).Add("MachineTypeId", "MachineModelId");
            RuntimeTypeModel.Default.Add(typeof(MachineModel), false).Add("Id", "Description", "MachineTypeId", "SeriesId", "BrandId");
            RuntimeTypeModel.Default.Add(typeof(MachineSeries), false).Add("Id", "Description", "MachineTypeId", "BrandId");
            RuntimeTypeModel.Default.Add(typeof(MachineType), false).Add("Id", "Description", "MachineTypeEnum");
            RuntimeTypeModel.Default.Add(typeof(MachineConfiguration), false).Add("Id", "TimeScope", "GpsReceiverXOffset", "GpsReceiverYOffset", "GpsReceiverZOffset", "OriginAxleLocation", "ConnectorIds", "MachineId");

            RuntimeTypeModel.Default.Add(typeof(Prescription), false).Add("Id", "Description", "OperationType", "FieldId", "CropZoneId", "ProductIds", "ContextItems");
            RuntimeTypeModel.Default[typeof(Prescription)].AddSubType(101, typeof(ManualPrescription));
            RuntimeTypeModel.Default[typeof(Prescription)].AddSubType(102, typeof(SpatialPrescription));
            RuntimeTypeModel.Default.Add(typeof(ManualPrescription), false).Add("Rate");
            RuntimeTypeModel.Default.Add(typeof(SpatialPrescription), false).Add("BoundingBox", "OutOfFieldRate", "LossOfGpsRate", "RateUnit");
            RuntimeTypeModel.Default[typeof(SpatialPrescription)].AddSubType(103, typeof(VectorPrescription));
            RuntimeTypeModel.Default[typeof(SpatialPrescription)].AddSubType(104, typeof(RasterGridPrescription));
            RuntimeTypeModel.Default.Add(typeof(VectorPrescription), false);
            RuntimeTypeModel.Default.Add(typeof(RasterGridPrescription), false).Add("Origin", "RowCount", "ColumnCount", "CellWidth", "CellHeight", "Rates");

            RuntimeTypeModel.Default.Add(typeof(Product), false).Add("Id", "BrandId", "Category", "ContextItems", "Density", "Description", "Form", "ManufacturerId", "ProductComponents", "ProductType", "Status");
            RuntimeTypeModel.Default.Add(typeof(ProductComponent), false).Add("IngredientId", "Quantity", "IsProduct", "IsCarrier");
            RuntimeTypeModel.Default[typeof(Product)].AddSubType(101, typeof(CropProtectionProduct));
            RuntimeTypeModel.Default[typeof(Product)].AddSubType(102, typeof(CropVariety));
            RuntimeTypeModel.Default[typeof(Product)].AddSubType(103, typeof(FertilizerProduct));
            RuntimeTypeModel.Default[typeof(Product)].AddSubType(104, typeof(ProductMix));
            RuntimeTypeModel.Default.Add(typeof(CropProtectionProduct), false).Add("Biological", "Organophosphate", "Carbamate");
            RuntimeTypeModel.Default.Add(typeof(CropVariety), false).Add("CropId", "TraitIds", "GeneticallyEnhanced");
            RuntimeTypeModel.Default.Add(typeof(FertilizerProduct), false).Add("IsManure");
            RuntimeTypeModel.Default.Add(typeof(ProductMix), false).Add("TotalQuantity", "IsTemporary");

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

            RuntimeTypeModel.Default.Add(typeof(Shape), true).Add("Id", "Type");
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(10, typeof(LinearRing));
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(11, typeof(LineString));
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(12, typeof(MultiLineString));
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(13, typeof(MultiPoint));
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(14, typeof(MultiPolygon));
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(15, typeof(Point));
            RuntimeTypeModel.Default[typeof(Shape)].AddSubType(16, typeof(Polygon));
            RuntimeTypeModel.Default.Add(typeof(LinearRing), false).Add("Points");
            RuntimeTypeModel.Default.Add(typeof(LineString), false).Add("Points");
            RuntimeTypeModel.Default.Add(typeof(MultiLineString), false).Add("LineStrings");
            RuntimeTypeModel.Default.Add(typeof(MultiPoint), false).Add("Points");
            RuntimeTypeModel.Default.Add(typeof(MultiPolygon), false).Add("Polygons");
            RuntimeTypeModel.Default.Add(typeof(Point), false).Add("X", "Y", "Z");
            RuntimeTypeModel.Default.Add(typeof(Polygon), false).Add("ExteriorRing", "InteriorRings");

            RuntimeTypeModel.Default.Add(typeof (Section), false).Add("Id", "OperationDataId", "Depth", "Order", "SectionWidth", "TotalDistanceTravelled", "TotalElapsedTime");
            RuntimeTypeModel.Default.Add(typeof (Meter), false).Add("Id", "SectionId", "Representation", "AppliedLatency", "ReportedLatency", "TriggerId");
            RuntimeTypeModel.Default[typeof(Meter)].AddSubType(114, typeof(EnumeratedMeter));
            RuntimeTypeModel.Default[typeof(Meter)].AddSubType(115, typeof(NumericMeter));
            RuntimeTypeModel.Default.Add(typeof(NumericMeter), false).Add("UnitOfMeasure", "Values");
            RuntimeTypeModel.Default.Add(typeof(EnumeratedMeter), false).Add("ValueCodes");
        }

        private static bool HaveDataContractsBeenAdded()
        {
            var schema = RuntimeTypeModel.Default.GetSchema(typeof(SpatialRecord));

            return schema != "package AgGateway.ADAPT.ApplicationDataModel.LoggedData;\r\n\r\nmessage SpatialRecord {\r\n}\r\n";
        }
    }
}
