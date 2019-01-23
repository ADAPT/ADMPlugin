using System;
using System.Collections.Generic;
using System.IO;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ADMPlugin.Serializers;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using Moq;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest.Serializers
{
  [TestFixture]
  public class DocumentsSerializerTest
  {
    private string _path;
    private Documents _documents;
    private Mock<IBaseSerializer> _baseSerializerMock;

    [SetUp]
    public void Setup()
    {
      _documents = new Documents { LoggedData = new List<LoggedData>() };
      _path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
      _baseSerializerMock = new Mock<IBaseSerializer>();
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenLoggedDataAreExported()
    {
      var loggedDatas = new List<LoggedData> { new LoggedData() };
      _documents.LoggedData = loggedDatas;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.LoggedDataFile, loggedDatas[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(loggedDatas[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenGuidanceAllocationsAreExported()
    {
      var guidanceAllocations = new List<GuidanceAllocation> { new GuidanceAllocation() };
      _documents.GuidanceAllocations = guidanceAllocations;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.GuidanceAllocationFile, guidanceAllocations[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(guidanceAllocations[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenPlansAreExported()
    {
      var plans = new List<Plan> { new Plan() };
      _documents.Plans = plans;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.PlanFile, plans[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(plans[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenRecommendationsAreExported()
    {
      var recommendations = new List<Recommendation> { new Recommendation() };
      _documents.Recommendations = recommendations;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.RecommendationFile, recommendations[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(recommendations[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenSummariesAreExported()
    {
      var summaries = new List<Summary> { new Summary() };
      _documents.Summaries = summaries;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.SummaryFile, summaries[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(summaries[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenWorkItemOperationsAreExported()
    {
      var workItemOperations = new List<WorkItemOperation> { new WorkItemOperation() };
      _documents.WorkItemOperations = workItemOperations;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.WorkItemOperationFile, workItemOperations[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(workItemOperations[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenWorkItemsAreExported()
    {
      var workItems = new List<WorkItem> { new WorkItem() };
      _documents.WorkItems = workItems;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.WorkItemFile, workItems[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(workItems[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenPathAndDocumentsWhenExportDocumentsThenWorkOrdersAreExported()
    {
      var workOrders = new List<WorkOrder> { new WorkOrder() };
      _documents.WorkOrders = workOrders;

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.WorkOrderFile, workOrders[0].Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);
      _baseSerializerMock.Verify(x => x.Serialize(workOrders[0], expectedPath), Times.Once);
    }

    [Test]
    public void GivenNullDocumentsWhenExportDocumentsThenDoesNothing()
    {
      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, null, _path);

      _baseSerializerMock.Verify(s => s.Serialize(It.IsAny<object>(), It.IsAny<string>()), Times.Never);
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

      var documentsSerializer = new DocumentsSerializer();
      documentsSerializer.Serialize(_baseSerializerMock.Object, _documents, _path);

      var expectedFileName = String.Format(DatacardConstants.OperationDataFile, operationData.Id.ReferenceId);
      var expectedPath = Path.Combine(_path, DatacardConstants.DocumentsFolder, expectedFileName);

      _baseSerializerMock.Verify(s => s.SerializeWithLengthPrefix(new List<SpatialRecord>(), expectedPath), Times.Once);
    }

    [TearDown]
    public void TearDown()
    {
      if (Directory.Exists(_path))
      {
        Directory.Delete(_path, true);
      }
    }
  }
}
