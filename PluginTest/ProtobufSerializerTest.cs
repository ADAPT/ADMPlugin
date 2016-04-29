using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Notes;
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

            var meter1 = new NumericMeter { SectionId = 1, Representation = RepresentationInstanceList.vrABRowSpacing.ToModelRepresentation() };
            var meter2 = new NumericMeter { SectionId = 2, Representation = RepresentationInstanceList.vrABShiftTrack.ToModelRepresentation() };
            var meter3 = new EnumeratedMeter { SectionId = 3, Representation = RepresentationInstanceList.dtDrainType.ToModelRepresentation() };

            var meters = new List<Meter> { meter1, meter3, meter2 };


            var filePath = Path.Combine(_testCardPath, "adm", "documents", "Meter-1.adm");
            _protobufSerializer.Write(filePath, meters);

            var metersIn = _protobufSerializer.Read<IEnumerable<Meter>>(filePath).ToList();

            Assert.AreEqual(3, metersIn.Count());
            Assert.AreEqual(meter1.SectionId, metersIn[0].SectionId);
            Assert.AreEqual(meter1.Representation.Code, metersIn[0].Representation.Code);
            Assert.AreEqual(meter1.Id.ReferenceId, metersIn[0].Id.ReferenceId);
            Assert.AreEqual(meter2.SectionId, metersIn[2].SectionId);
            Assert.AreEqual(meter2.Representation.Code, metersIn[2].Representation.Code);
            Assert.AreEqual(meter2.Id.ReferenceId, metersIn[2].Id.ReferenceId);
            Assert.AreEqual(meter3.SectionId, metersIn[1].SectionId);
            Assert.AreEqual(meter3.Representation.Code, metersIn[1].Representation.Code);
            Assert.AreEqual(meter3.Id.ReferenceId, metersIn[1].Id.ReferenceId);
        }

        [Test]
        public void GivenSectionDataFileWhenReadThensectionsAreReturned()
        {
            var section1 = new Section { Depth = 0, OperationDataId = 100, Order = 3 };
            var section2 = new Section { Depth = 1, OperationDataId = 200, Order = 3 };

            var sections = new List<Section> { section1, section2 };

            var sectionDictionary = new Dictionary<int, List<Section>>();
            sectionDictionary.Add(1, sections);

            var filePath = Path.Combine(_testCardPath, "adm", "documents", "Section-1.adm");
            _protobufSerializer.Write(filePath, sectionDictionary);

            var sectionsDictionaryIn = _protobufSerializer.Read<Dictionary<int, List<Section>>>(filePath);

            Assert.AreEqual(1, sectionsDictionaryIn.Keys.Count());
            Assert.AreEqual(sections[0].Depth, sectionsDictionaryIn[1][0].Depth);
            Assert.AreEqual(sections[0].OperationDataId, sectionsDictionaryIn[1][0].OperationDataId);
            Assert.AreEqual(sections[0].Order, sectionsDictionaryIn[1][0].Order);
        }

        [Test]
        public void GivenDocumentsWhenWrittenAndReadThenDocumentsIsReturned()
        {
            var documents = new Documents
            {
                WorkItems = new List<WorkItem> { new WorkItem { BoundaryId = 5 } },
                WorkItemOperations = new List<WorkItemOperation> { new WorkItemOperation { Description = "Hello" } },
                LoggedData = new List<LoggedData>
                {
                    new LoggedData
                    {
                        CropIds = new List<int> { 1,2,3},
                        OperationData = new List<OperationData>{ new OperationData() }
                    },
                },

            };

            var filePath = Path.Combine(_testCardPath, "adm", "document.adm");
            _protobufSerializer.Write(filePath, documents);

            var documentsIn = _protobufSerializer.Read<Documents>(filePath);

            Assert.AreEqual(documents.WorkItems.First().BoundaryId, documentsIn.WorkItems.First().BoundaryId);
            Assert.AreEqual(documents.WorkItemOperations.First().Description, documentsIn.WorkItemOperations.First().Description);
            Assert.AreEqual(documents.LoggedData.First().CropIds[0], documentsIn.LoggedData.First().CropIds[0]);
            Assert.AreEqual(documents.LoggedData.First().CropIds[1], documentsIn.LoggedData.First().CropIds[1]);
            Assert.AreEqual(documents.LoggedData.First().CropIds[2], documentsIn.LoggedData.First().CropIds[2]);
            Assert.AreEqual(documents.LoggedData.First().Id.ReferenceId, documentsIn.LoggedData.First().Id.ReferenceId);
            Assert.AreEqual(documents.LoggedData.First().OperationData.First().Id.ReferenceId, documentsIn.LoggedData.First().OperationData.First().Id.ReferenceId);
        }

        [Test]
        public void GivenContextItemWhenWrittenAndReadThenReturned()
        {
            var contextItem = new ContextItem
            {
                ContextItemType = 5,
                Value = new EnumeratedValue { Color = 3 }
            };

            var filePath = Path.Combine(_testCardPath, "adm", "document.adm");
            _protobufSerializer.Write(filePath, contextItem);

            var contextItemIn = _protobufSerializer.Read<ContextItem>(filePath);

            Assert.AreEqual(contextItem.ContextItemType, contextItemIn.ContextItemType);
            Assert.AreEqual(contextItem.Value.Color, contextItemIn.Value.Color);
        }

        [Test]
        public void GivenDocumentWhenWrittenAndReadThenDocumentIsReturned()
        {
            var document = new Plan
            {
                CropIds = new List<int> { 1, 2, 3 },
                Description = "I am a docment"
            };

            var filePath = Path.Combine(_testCardPath, "adm", "document.adm");
            _protobufSerializer.Write(filePath, document);
        }

        [Test]
        public void GivenNoteWhenWrittenAndReadThenReturned()
        {
            var note = new Note
            {
                Description = "Description",
            };

            var filePath = Path.Combine(_testCardPath, "adm", "document.adm");
            _protobufSerializer.Write(filePath, note);

            var noteIn = _protobufSerializer.Read<Note>(filePath);

            Assert.AreEqual(note.Description, noteIn.Description);
        }

        [Test]
        public void GivenCompoundIdentifierWhenWrittenAndReadThenReturned()
        {
            var ci = new CompoundIdentifier(5);

            var filePath = Path.Combine(_testCardPath, "adm", "document.adm");
            _protobufSerializer.Write(filePath, ci);

            var ciIn = _protobufSerializer.Read<CompoundIdentifier>(filePath);

            Assert.AreEqual(ci.ReferenceId, ciIn.ReferenceId);
        }


        [TearDown]
        public void Teardown()
        {
            Directory.Delete(_testCardPath, true);
        }

    }
}
