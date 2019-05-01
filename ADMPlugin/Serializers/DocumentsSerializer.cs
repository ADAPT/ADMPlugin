using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.ADMPlugin.Serializers
{
  public class DocumentsSerializer : ISerializer<Documents>
  {
    public void Serialize(IBaseSerializer baseSerializer, Documents documents, string dataPath)
    {
      if (documents == null)
      {
        return;
      }

      var documentsPath = Path.Combine(dataPath, DatacardConstants.DocumentsFolder);
      if (!Directory.Exists(documentsPath))
      {
        Directory.CreateDirectory(documentsPath);
      }

      WriteLoggedData(baseSerializer, documents, documentsPath);
      WriteGuidanceAllocations(baseSerializer, documents, documentsPath);
      WritePlans(baseSerializer, documents, documentsPath);
      WriteRecommendations(baseSerializer, documents, documentsPath);
      WriteSummaries(baseSerializer, documents, documentsPath);
      WriteWorkRecords(baseSerializer, documents, documentsPath);
      WriteWorkItemOperations(baseSerializer, documents, documentsPath);
      WriteWorkItems(baseSerializer, documents, documentsPath);
      WriteWorkOrders(baseSerializer, documents, documentsPath);
      WriteLoads(baseSerializer, documents, documentsPath);
    }

    public Documents Deserialize(IBaseSerializer baseSerializer, string dataPath)
    {
      var documentsPath = Path.Combine(dataPath, DatacardConstants.DocumentsFolder);
      if (!Directory.Exists(documentsPath))
      {
        return null;
      }

      var documents = new Documents();
      documents.LoggedData = ReadLoggedData(baseSerializer, documentsPath);
      documents.GuidanceAllocations = ReadGuidanceAllocations(baseSerializer, documentsPath);
      documents.Plans = ReadPlans(baseSerializer, documentsPath);
      documents.Recommendations = ReadRecommendations(baseSerializer, documentsPath);
      documents.Summaries = ReadSummaries(baseSerializer, documentsPath);
      documents.WorkRecords = ReadWorkRecords(baseSerializer, documentsPath);
      documents.WorkItemOperations = ReadWorkItemOperations(baseSerializer, documentsPath);
      documents.WorkItems = ReadWorkItems(baseSerializer, documentsPath);
      documents.WorkOrders = ReadWorkOrders(baseSerializer, documentsPath);
      documents.Loads = ReadLoads(baseSerializer, documentsPath);

      return documents;
    }

    private void WriteWorkRecords(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.WorkRecords == null)
      {
        return;
      }

      foreach (var workRecord in documents.WorkRecords)
      {
        if (workRecord != null)
        {
          WriteObject(baseSerializer, documentsPath, workRecord, workRecord.Id.ReferenceId, DatacardConstants.WorkRecordFile);
        }
      }
    }

    private void WriteWorkOrders(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.WorkOrders == null)
      {
        return;
      }

      foreach (var workOrder in documents.WorkOrders)
      {
        if (workOrder != null)
        {
          WriteObject(baseSerializer, documentsPath, workOrder, workOrder.Id.ReferenceId, DatacardConstants.WorkOrderFile);
        }
      }
    }

    private void WriteWorkItems(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.WorkItems == null)
      {
        return;
      }

      foreach (var workItem in documents.WorkItems)
      {
        if (workItem != null)
        {
          WriteObject(baseSerializer, documentsPath, workItem, workItem.Id.ReferenceId, DatacardConstants.WorkItemFile);
        }
      }
    }

    private void WriteWorkItemOperations(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.WorkItemOperations == null)
      {
        return;
      }

      foreach (var workItemOperation in documents.WorkItemOperations)
      {
        if (workItemOperation != null)
        {
          WriteObject(baseSerializer, documentsPath, workItemOperation, workItemOperation.Id.ReferenceId, DatacardConstants.WorkItemOperationFile);
        }
      }
    }

    private void WriteSummaries(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.Summaries == null)
      {
        return;
      }

      foreach (var summary in documents.Summaries)
      {
        if (summary != null)
        {
          WriteObject(baseSerializer, documentsPath, summary, summary.Id.ReferenceId, DatacardConstants.SummaryFile);
        }
      }
    }

    private void WriteRecommendations(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.Recommendations == null)
      {
        return;
      }

      foreach (var recommendation in documents.Recommendations)
      {
        if (recommendation != null)
        {
          WriteObject(baseSerializer, documentsPath, recommendation, recommendation.Id.ReferenceId, DatacardConstants.RecommendationFile);
        }
      }
    }

    private void WriteLoads(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.Loads == null)
      {
        return;
      }

      foreach (var load in documents.Loads)
      {
        if (load != null)
        {
          WriteObject(baseSerializer, documentsPath, load, load.Id.ReferenceId, DatacardConstants.LoadFile);
        }
      }
    }

    private void WritePlans(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.Plans == null)
      {
        return;
      }

      foreach (var plan in documents.Plans)
      {
        if (plan != null)
        {
          WriteObject(baseSerializer, documentsPath, plan, plan.Id.ReferenceId, DatacardConstants.PlanFile);
        }
      }
    }

    private void WriteGuidanceAllocations(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.GuidanceAllocations == null)
      {
        return;
      }

      foreach (var guidanceAllocation in documents.GuidanceAllocations)
      {
        if (guidanceAllocation != null)
        {
          WriteObject(baseSerializer, documentsPath, guidanceAllocation, guidanceAllocation.Id.ReferenceId, DatacardConstants.GuidanceAllocationFile);
        }
      }
    }

    private void WriteLoggedData(IBaseSerializer baseSerializer, Documents documents, string documentsPath)
    {
      if (documents.LoggedData == null)
      {
        return;
      }

      foreach (var loggedData in documents.LoggedData)
      {
        if (loggedData != null)
        {
          if (loggedData.OperationData != null)
          {
            loggedData.OperationData = loggedData.OperationData.ToList();
            foreach (var operationData in loggedData.OperationData)
            {
              ExportSpatialRecords(baseSerializer, documentsPath, operationData);
              ExportSectionsAndMeters(baseSerializer, documentsPath, operationData);
            }
          }
          WriteObject(baseSerializer, documentsPath, loggedData, loggedData.Id.ReferenceId, DatacardConstants.LoggedDataFile);
        }
      }
    }

    private void WriteObject<T>(IBaseSerializer baseSerializer, string documentsPath, T obj, int referenceId, string fileNameFormat)
    {
      var fileName = String.Format(fileNameFormat, referenceId);
      var filePath = Path.Combine(documentsPath, fileName);
      baseSerializer.Serialize(obj, filePath);
    }

    private void ExportSpatialRecords(IBaseSerializer baseSerializer, string documentsPath, OperationData operationData)
    {
      var fileName = string.Format(DatacardConstants.OperationDataFile, operationData.Id.ReferenceId);
      var filePath = Path.Combine(documentsPath, fileName);

      if (operationData.GetSpatialRecords == null)
      {
        baseSerializer.SerializeWithLengthPrefix(new List<SpatialRecord>(), filePath);
        return;
      }

      var spatialRecords = operationData.GetSpatialRecords();

      baseSerializer.SerializeWithLengthPrefix(spatialRecords, filePath);
    }

    private void ExportSectionsAndMeters(IBaseSerializer baseSerializer, string documentsPath, OperationData operationData)
    {
      var deviceElementUses = GetAllDeviceElementUses(operationData);
      var deviceElementUseFileName = string.Format(DatacardConstants.SectionFile, operationData.Id.ReferenceId);
      var deviceElementUseFilePath = Path.Combine(documentsPath, deviceElementUseFileName);

      var workingData = deviceElementUses.SelectMany(deviceElementUse => deviceElementUse.Value.SelectMany(x => x.GetWorkingDatas()));
      var workingDataFileName = string.Format(DatacardConstants.WorkingDataFile, operationData.Id.ReferenceId);
      var workingDataFilePath = Path.Combine(documentsPath, workingDataFileName);

      baseSerializer.Serialize(deviceElementUses, deviceElementUseFilePath);
      baseSerializer.Serialize(workingData, workingDataFilePath);
    }

    private Dictionary<int, IEnumerable<DeviceElementUse>> GetAllDeviceElementUses(OperationData operationData)
    {
      if (operationData == null)
      {
        return null;
      }

      var sections = new Dictionary<int, IEnumerable<DeviceElementUse>>();

      for (var depth = 0; depth <= operationData.MaxDepth; depth++)
      {
        if (operationData.GetDeviceElementUses == null)
        {
          continue;
        }

        var levelSections = operationData.GetDeviceElementUses(depth);
        sections.Add(depth, levelSections);
      }

      return sections;
    }

    private IEnumerable<WorkRecord> ReadWorkRecords(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.WorkRecordFile));
      return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<WorkRecord>(loggedDataFile));
    }

    private IEnumerable<WorkOrder> ReadWorkOrders(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.WorkOrderFile));
      return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<WorkOrder>(loggedDataFile));
    }

    private IEnumerable<WorkItem> ReadWorkItems(IBaseSerializer baseSerializer, string documentsPath)
    {
        var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.WorkItemFileOnly));
        return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<WorkItem>(loggedDataFile));
    }

    private IEnumerable<WorkItemOperation> ReadWorkItemOperations(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.WorkItemOperationFile));
      return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<WorkItemOperation>(loggedDataFile));
    }

    private IEnumerable<Summary> ReadSummaries(IBaseSerializer baseSerializer, string documentsPath)
    {
      var summaryFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.SummaryFile));
      return summaryFiles.Select(summaryFile => baseSerializer.Deserialize<Summary>(summaryFile));
    }

    private IEnumerable<Recommendation> ReadRecommendations(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.RecommendationFile));
      return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<Recommendation>(loggedDataFile));
    }

    private IEnumerable<Plan> ReadPlans(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.PlanFile));
      return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<Plan>(loggedDataFile));
    }

    private IEnumerable<GuidanceAllocation> ReadGuidanceAllocations(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.GuidanceAllocationFile));
      return loggedDataFiles.Select(loggedDataFile => baseSerializer.Deserialize<GuidanceAllocation>(loggedDataFile));
    }

    private IEnumerable<Load> ReadLoads(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loadFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.LoadFile));
      return loadFiles.Select(loadFile => baseSerializer.Deserialize<Load>(loadFile));
    }

    private IEnumerable<LoggedData> ReadLoggedData(IBaseSerializer baseSerializer, string documentsPath)
    {
      var loggedDataCol = new List<LoggedData>();

      var loggedDataFiles = Directory.EnumerateFiles(documentsPath, ConvertToSearchPattern(DatacardConstants.LoggedDataFile));
      foreach (var loggedDataFile in loggedDataFiles)
      {
        var loggedData = baseSerializer.Deserialize<LoggedData>(loggedDataFile);
        foreach (var operationData in loggedData.OperationData)
        {
          ImportSpatialRecords(baseSerializer, documentsPath, operationData);
          ImportSections(baseSerializer, documentsPath, operationData);
          ImportMeters(baseSerializer, documentsPath, operationData);
        }

        loggedDataCol.Add(loggedData);
      }

      return loggedDataCol;
    }

    private void ImportMeters(IBaseSerializer baseSerializer, string documentsPath, OperationData operationData)
    {
      var deviceElementUses = GetAllDeviceElementUses(operationData).Where(x => x.Value != null).SelectMany(x => x.Value);

      var workingDataFileName = string.Format(DatacardConstants.WorkingDataFile, operationData.Id.ReferenceId);
      var workingDataFilePath = Path.Combine(documentsPath, workingDataFileName);
      var allWorkingData = baseSerializer.Deserialize<IEnumerable<WorkingData>>(workingDataFilePath);

      foreach (var deviceElementUse in deviceElementUses)
      {
        var deviceElementUseWorkingData = allWorkingData.Where(x => x.DeviceElementUseId == deviceElementUse.Id.ReferenceId);
        deviceElementUse.GetWorkingDatas = () => deviceElementUseWorkingData;
      }
    }

    private void ImportSections(IBaseSerializer baseSerializer, string documentsPath, OperationData operationData)
    {
      var sectionsFileName = string.Format(DatacardConstants.SectionFile, operationData.Id.ReferenceId);
      var sectionsFilePath = Path.Combine(documentsPath, sectionsFileName);
      var sections = baseSerializer.Deserialize<Dictionary<int, IEnumerable<DeviceElementUse>>>(sectionsFilePath);

      if (sections != null && sections.Any())
        operationData.GetDeviceElementUses = x => sections[x] ?? new List<DeviceElementUse>();
    }

    private void ImportSpatialRecords(IBaseSerializer baseSerializer, string documentsPath, OperationData operationData)
    {
      var spatialRecordFileName = string.Format(DatacardConstants.OperationDataFile, operationData.Id.ReferenceId);
      var spatialRecordFilePath = Path.Combine(documentsPath, spatialRecordFileName);

      var spatialRecords = baseSerializer.DeserializeWithLengthPrefix<SpatialRecord>(spatialRecordFilePath);
      operationData.GetSpatialRecords = () => spatialRecords;
    }

    private string ConvertToSearchPattern(string filePattern)
    {
      return string.Format(filePattern, "*");
    }
  }
}
