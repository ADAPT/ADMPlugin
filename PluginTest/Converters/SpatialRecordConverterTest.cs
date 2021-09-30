using System;
using System.Collections.Generic;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin.Converters;
using AgGateway.ADAPT.ADMPlugin.Models;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;
using EnumeratedRepresentation = AgGateway.ADAPT.ApplicationDataModel.Representations.EnumeratedRepresentation;
using NumericRepresentation = AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation;

namespace AgGateway.ADAPT.PluginTest.Converters
{
    [TestFixture]
    public class SpatialRecordConverterTest
    {
        private SpatialRecordConverter _spatialRecordConverter;

        [SetUp]
        public void Setup()
        {
            _spatialRecordConverter = new SpatialRecordConverter();
        }

        [Test]
        public void GivenNullWhenConvertToSerialThenEmptyList()
        {
            Assert.IsEmpty(_spatialRecordConverter.ConvertToSerializableSpatialRecords(null, new List<WorkingData>()));
            Assert.IsEmpty(_spatialRecordConverter.ConvertToSerializableSpatialRecords(new List<SpatialRecord>(), null));
        }

        [Test]
        public void GivenNullWhenConvertToModelThenEmptyList()
        {
            Assert.IsEmpty(_spatialRecordConverter.ConvertToSpatialRecords(null, new List<WorkingData>()));
            Assert.IsEmpty(_spatialRecordConverter.ConvertToSpatialRecords(new List<SerializableSpatialRecord>(), null));
        }

        [Test]
        public void GivenSpatialRecordsWhenConvertToSerialThenShapeAndTimeAreCopied()
        {
            var spatialRecord = new SpatialRecord
            {
                Geometry = new Point { X = 1.23, Y = 4.56 },
                Timestamp = DateTime.Now
            };
            var result = MapSingle(spatialRecord, new List<WorkingData>());

            Assert.AreSame(spatialRecord.Geometry, result.Geometry);
            Assert.AreEqual(spatialRecord.Timestamp, result.Timestamp);
        }

        [Test]
        public void GivenSpatialRecordsWhenConvertToSerialThenEnumeratedValuesAreConverted()
        {
            var workingData = new EnumeratedWorkingData
            {
                Representation = RepresentationInstanceList.dtHeaderStatus.ToModelRepresentation()
            };
            var value = new EnumeratedValue
            {
                Representation = (EnumeratedRepresentation)workingData.Representation,
                Value = DefinedTypeEnumerationInstanceList.dtiHeaderStatusOff.ToModelEnumMember()
            };
            var spatialRecord = new SpatialRecord();
            spatialRecord.SetMeterValue(workingData, value);

            var result = MapSingle(spatialRecord, new List<WorkingData> {workingData});

            Assert.AreEqual(value.Value.Code, result.EnumeratedMeterValues[workingData.Id.ReferenceId]);
        }

        [Test]
        public void GivenSpatialRecordsWhenConvertToSerialThenNumericValuesAreConvertedWithSameUnit()
        {
            var workingData = new NumericWorkingData
            {
                Representation = RepresentationInstanceList.vrFuelAmount.ToModelRepresentation(),
                UnitOfMeasure = UnitSystemManager.GetUnitOfMeasure("l")
            };
            var value = new NumericRepresentationValue((NumericRepresentation) workingData.Representation,
                new NumericValue(UnitSystemManager.GetUnitOfMeasure("m3"), 1));
            var spatialRecord = new SpatialRecord();
            spatialRecord.SetMeterValue(workingData, value);

            var result = MapSingle(spatialRecord, new List<WorkingData> { workingData });

            // 1 cubic meter is 1000 liters. We expect the value was converted to the unit of measure that is on the WorkingData.
            Assert.AreEqual(1000, result.NumericMeterValues[workingData.Id.ReferenceId], Double.Epsilon);
        }

        [Test]
        public void GivenWorkingDataWithNoUnitWhenConvertToSerialThenUnitIsCopiedFromSpatialRecord()
        {
            var workingData = new NumericWorkingData
            {
                Representation = RepresentationInstanceList.vrFuelAmount.ToModelRepresentation(),
                UnitOfMeasure = null
            };
            var value = new NumericRepresentationValue((NumericRepresentation) workingData.Representation,
                new NumericValue(UnitSystemManager.GetUnitOfMeasure("l"), 1));
            var spatialRecord = new SpatialRecord();
            spatialRecord.SetMeterValue(workingData, value);

            MapSingle(spatialRecord, new List<WorkingData> { workingData });

            Assert.AreEqual("l", workingData.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenSpatialRecordsWhenConvertToSerialThenStringValuesAreCopied()
        {
            var workingData = new EnumeratedWorkingData();
            var value = new StringValue { Value = "some value" };
            var spatialRecord = new SpatialRecord();
            spatialRecord.SetMeterValue(workingData, value);

            var result = MapSingle(spatialRecord, new List<WorkingData> { workingData });

            Assert.AreEqual(value.Value, result.StringMeterValues[workingData.Id.ReferenceId]);
        }

        [Test]
        public void GivenSpatialRecordsWhenConvertToSerialThenAppliedLatencyIsCopied()
        {
            var workingData = new NumericWorkingData();
            var latency = 14;
            var spatialRecord = new SpatialRecord();
            spatialRecord.SetAppliedLatency(workingData, latency);

            var result = MapSingle(spatialRecord, new List<WorkingData> { workingData });

            Assert.AreEqual(latency, result.AppliedLatencyValues[workingData.Id.ReferenceId]);
        }

        private SerializableSpatialRecord MapSingle(SpatialRecord spatialRecord, List<WorkingData> workingData)
        {
            var spatialRecords = new[] { spatialRecord };
            return _spatialRecordConverter.ConvertToSerializableSpatialRecords(spatialRecords, workingData).Single();
        }
    }
}
