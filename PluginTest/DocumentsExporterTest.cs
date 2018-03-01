using System;
using System.Collections.Generic;
using System.IO;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using Moq;
using NUnit.Framework;

namespace PluginTest
{
    [TestFixture]
    public class DocumentsExporterTest
    {
        private string _path;
        private Documents _documents;
        private Mock<IProtobufSerializer> _protobufSerialierMock;
        private DocumentsExporter _documentsExport;

        [SetUp]
        public void Setup()
        {
            _documents = new Documents{ LoggedData = new List<LoggedData>()};
            _path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            _protobufSerialierMock = new Mock<IProtobufSerializer>();

            _documentsExport = new DocumentsExporter(_protobufSerialierMock.Object);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenLoggedDataAreExported()
        {
            var loggedDatas = new List<LoggedData> { new LoggedData() };
            _documents.LoggedData = loggedDatas;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.LoggedDataFile, loggedDatas[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, loggedDatas[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenGuidanceAllocationsAreExported()
        {
            var guidanceAllocations = new List<GuidanceAllocation>{ new GuidanceAllocation() };
            _documents.GuidanceAllocations = guidanceAllocations ;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.GuidanceAllocationFile, guidanceAllocations[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, guidanceAllocations[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenPlansAreExported()
        {
            var plans = new List<Plan>{ new Plan() };
            _documents.Plans = plans ;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.PlanFile, plans[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, plans[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenRecommendationsAreExported()
        {
            var recommendations = new List<Recommendation> { new Recommendation() };
            _documents.Recommendations = recommendations;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.RecommendationFile, recommendations[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, recommendations[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenSummariesAreExported()
        {
            var summaries = new List<Summary> { new Summary() };
            _documents.Summaries = summaries;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.SummaryFile, summaries[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, summaries[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenWorkItemOperationsAreExported()
        {
            var workItemOperations = new List<WorkItemOperation> { new WorkItemOperation() };
            _documents.WorkItemOperations = workItemOperations;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.WorkItemOperationFile, workItemOperations[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, workItemOperations[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenWorkItemsAreExported()
        {
            var workItems = new List<WorkItem> { new WorkItem() };
            _documents.WorkItems = workItems;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.WorkItemFile, workItems[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, workItems[0]), Times.Once);
        }

        [Test]
        public void GivenPathAndDocumentsWhenExportDocumentsThenWorkOrdersAreExported()
        {
            var workOrders = new List<WorkOrder> { new WorkOrder() };
            _documents.WorkOrders = workOrders;

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.WorkOrderFile, workOrders[0].Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
            _protobufSerialierMock.Verify(x => x.Write(expectedPath, workOrders[0]), Times.Once);
        }

        [Test]
        public void GivenNullDocumentsWhenExportDocumentsThenDoesNothing()
        {
            _documentsExport.ExportDocuments(_path, null);

            _protobufSerialierMock.Verify(s => s.Write(It.IsAny<string>(), It.IsAny<object>()), Times.Never);
        }

        [Test]
        public void GivenNullGetSpatialRecordsWhenMapThenWritesEmptySpatialRecords()
        {
            var operationData = new OperationData
            {
                GetSpatialRecords = null
            };
            _documents.LoggedData = new List<LoggedData>
            {
                new LoggedData
                {
                    OperationData = new List<OperationData>
                    {
                        operationData
                    }
                }
            };

            _documentsExport.ExportDocuments(_path, _documents);

            var expectedFileName = String.Format(DatacardConstants.OperationDataFile, operationData.Id.ReferenceId);
            var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);

            _protobufSerialierMock.Verify(s => s.WriteSpatialRecords(expectedPath, new List<SpatialRecord>()), Times.Once);
        }

        [TearDown]
        public void TearDown()
        {
            if(Directory.Exists(_path))
                Directory.Delete(_path, true);
        }
    }
}
