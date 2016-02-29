using System;
using System.Collections.Generic;
using System.IO;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Representations;
using AgGateway.ADAPT.ApplicationDataModel.Shapes;
using NUnit.Framework;
using TestUtilities;

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
            _protobufSerializer.WriteSpatialRecords(filePath, _spatialRecords, _meters);

            var fileExists = File.Exists(filePath);
            Assert.IsTrue(fileExists);
        }

        [Test]
        public void GivenOperationDataFileWhenReadSpatialRecordsThenSpatialRecordsAreReturned()
        {
            var filePath = Path.Combine(_testCardPath, "adm", "documents", "OperationData-1.adm");

            var spatialRecords = _protobufSerializer.ReadSpatialRecords(filePath);
            
            Assert.IsNotNull(spatialRecords);
        }

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(_testCardPath, true);
        }

    }
}
