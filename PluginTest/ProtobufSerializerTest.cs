using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using AgGateway.ADAPT.Representation.RepresentationSystem;
using AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods;
using AgGateway.ADAPT.Representation.UnitSystem;
using NUnit.Framework;
using TestUtilities;
using NumericRepresentation = AgGateway.ADAPT.ApplicationDataModel.Representations.NumericRepresentation;
using UnitOfMeasure = AgGateway.ADAPT.ApplicationDataModel.Common.UnitOfMeasure;

namespace PluginTest
{
    [TestFixture]
    public class ProtobufSerializerTest
    {
        private readonly ProtobufSerializer _protobufSerializer = new ProtobufSerializer();
        private string _testCardPath;
        private List<SpatialRecord> _spatialRecords;
        private List<Meter> _meters;

        [SetUp]
        public void Setup()
        {
            _testCardPath = DatacardUtility.WriteDataCard("TestDatacard");
            _spatialRecords = new List<SpatialRecord>();
            _meters = new List<Meter>();
        }

        [Test]
        public void GivenSpatialRecordsWhenWriteSpatialRecordsThenOperationDataFileIsWritten()
        {
            var meter1 = new NumericMeter();
            _meters.Add(meter1);

            var spatialRecord1 = new SpatialRecord { Timestamp = DateTime.Now, Geometry = new Point { X = 45.123456, Y = -65.456789 } };
            spatialRecord1.SetMeterValue(meter1, new NumericRepresentationValue(new NumericRepresentation(), new NumericValue(new UnitOfMeasure(), 21.2)));
            _spatialRecords.Add(spatialRecord1);

            var filePath = Path.Combine(_testCardPath, "OperationData-1.adm");
            _protobufSerializer.Write(filePath, _spatialRecords);

            var fileExists = File.Exists(filePath);
            Assert.IsTrue(fileExists);
        }

        [Test]
        public void GivenOperationDataFileWhenReadSpatialRecordsThenSpatialRecordsAreReturned()
        {
            var meter = new NumericMeter();
            _meters.Add(meter);

            var numericRepValue = new NumericRepresentationValue(RepresentationInstanceList.vrABLineHeading.ToModelRepresentation(), new NumericValue(UnitSystemManager.GetUnitOfMeasure("m"), 21.2));

            var spatialRecord1 = new SpatialRecord { Timestamp = DateTime.Now, Geometry = new Point { X = 45.123456, Y = -65.456789 } };
            spatialRecord1.SetMeterValue(meter, numericRepValue);
            spatialRecord1.SetAppliedLatency(meter, 2);
            _spatialRecords.Add(spatialRecord1);

            var spatialRecord2 = new SpatialRecord { Timestamp = DateTime.Now, Geometry = new Point { X = 85.654875, Y = -65.3456212 } };
            spatialRecord2.SetMeterValue(meter, numericRepValue);
            spatialRecord2.SetAppliedLatency(meter, 2);
            _spatialRecords.Add(spatialRecord2);

            var filePath = Path.Combine(_testCardPath, "OperationData-1.adm");
            _protobufSerializer.WriteSpatialRecords(filePath, _spatialRecords);

             var spatialRecords = _protobufSerializer.ReadSpatialRecords(filePath).ToList();
            
            Assert.AreEqual(spatialRecord1.Timestamp, spatialRecords[0].Timestamp);
            Assert.AreEqual(spatialRecord1.Geometry.Id, spatialRecords[0].Geometry.Id);
            Assert.AreEqual(numericRepValue.Value.Value, ((NumericRepresentationValue)spatialRecords[0].GetMeterValue(meter)).Value.Value);
            Assert.AreEqual(numericRepValue.Representation.Code, ((NumericRepresentationValue)spatialRecords[0].GetMeterValue(meter)).Representation.Code);
            Assert.AreEqual(numericRepValue.Value.UnitOfMeasure.Code, ((NumericRepresentationValue)spatialRecords[0].GetMeterValue(meter)).Value.UnitOfMeasure.Code);

            Assert.AreEqual(spatialRecord2.Timestamp, spatialRecords[1].Timestamp);
            Assert.AreEqual(spatialRecord2.Geometry.Id, spatialRecords[1].Geometry.Id);
            Assert.AreEqual(numericRepValue.Value.Value, ((NumericRepresentationValue)spatialRecords[1].GetMeterValue(meter)).Value.Value);
            Assert.AreEqual(numericRepValue.Representation.Code, ((NumericRepresentationValue)spatialRecords[1].GetMeterValue(meter)).Representation.Code);
            Assert.AreEqual(numericRepValue.Value.UnitOfMeasure.Code, ((NumericRepresentationValue)spatialRecords[1].GetMeterValue(meter)).Value.UnitOfMeasure.Code);
        }

        [Test]
        public void GivenMeterDataFileWhenReadThenMetersAreReturned()
        {
            var filePath = Path.Combine(_testCardPath, "adm", "documents", "Meter-1.adm");

            var meters = _protobufSerializer.Read<IEnumerable<Meter>>(filePath).ToList();

            Assert.IsNotNull(meters);
        }

        [Test]
        public void GivenSectionDataFileWhenReadThensectionsAreReturned()
        {
            var filePath = Path.Combine(_testCardPath, "adm", "documents", "Section-1.adm");

            var sections = _protobufSerializer.Read<Dictionary<int, IEnumerable<Section>>>(filePath);

            Assert.IsNotNull(sections);
        }

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(_testCardPath, true);
        }

    }
}
