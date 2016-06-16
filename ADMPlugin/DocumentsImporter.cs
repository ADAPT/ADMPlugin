using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.Guidance;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace ADMPlugin
{
    public class DocumentsImporter
    {
        private readonly IProtobufSerializer _protobufSerializer;

        public DocumentsImporter() : this(new ProtobufSerializer())
        {
        }

        public DocumentsImporter(IProtobufSerializer protobufSerializer)
        {
            _protobufSerializer = protobufSerializer;
        }

        public Documents ImportDocuments(string path, string documentAdm, Catalog catalog)
        {
            var documentsPath = Path.Combine(path, DatacardConstants.PluginFolderAndExtension, DatacardConstants.DocumentsFolder);
            if (!Directory.Exists(documentsPath))
                return null;

            var documents = new Documents();
            documents.LoggedData = ReadLoggedData(documentsPath);
            documents.GuidanceAllocations = ReadGuidanceAllocations(documentsPath);
            documents.Plans = ReadPlans(documentsPath);
            documents.Recommendations = ReadRecommendations(documentsPath);
            documents.Summaries = ReadSummaries(documentsPath);
            documents.WorkItemOperations = ReadWorkItemOperations(documentsPath);
            documents.WorkItems = ReadWorkItems(documentsPath);
            documents.WorkOrders = ReadWorkOrders(documentsPath);

            return documents;
        }

        private IEnumerable<WorkOrder> ReadWorkOrders(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.WorkOrderFile));
            return loggedDataFiles.Select(loggedDataFile => _protobufSerializer.Read<WorkOrder>(loggedDataFile));
        }

        private IEnumerable<WorkItem> ReadWorkItems(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.WorkItemFile));
            return loggedDataFiles.Select(loggedDataFile => _protobufSerializer.Read<WorkItem>(loggedDataFile));
        }

        private IEnumerable<WorkItemOperation> ReadWorkItemOperations(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.WorkItemOperationFile));
            return loggedDataFiles.Select(loggedDataFile => _protobufSerializer.Read<WorkItemOperation>(loggedDataFile));
        }

        private IEnumerable<Summary> ReadSummaries(string documentsPath)
        {
            var summaryFile = Path.Combine(documentsPath, DatacardConstants.SummariesFile);
            if (File.Exists(summaryFile))
                return _protobufSerializer.Read<IEnumerable<Summary>>(summaryFile);
            return Enumerable.Empty<Summary>();
        }

        private IEnumerable<Recommendation> ReadRecommendations(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.RecommendationFile));
            return loggedDataFiles.Select(loggedDataFile => _protobufSerializer.Read<Recommendation>(loggedDataFile));
        }

        private IEnumerable<Plan> ReadPlans(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.PlanFile));
            return loggedDataFiles.Select(loggedDataFile => _protobufSerializer.Read<Plan>(loggedDataFile));
        }

        private IEnumerable<GuidanceAllocation> ReadGuidanceAllocations(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.GuidanceAllocationFile));
            return loggedDataFiles.Select(loggedDataFile => _protobufSerializer.Read<GuidanceAllocation>(loggedDataFile));
        }

        private IEnumerable<LoggedData> ReadLoggedData(string documentsPath)
        {
            var loggedDataFiles = Directory.EnumerateFiles(documentsPath, DatacardConstants.ConvertToSearchPattern(DatacardConstants.LoggedDataFile));
            foreach (var loggedDataFile in loggedDataFiles)
            {
                var loggedData = _protobufSerializer.Read<LoggedData>(loggedDataFile);
                foreach (var operationData in loggedData.OperationData)
                {
                    ImportSpatialRecords(documentsPath, operationData);
                    ImportSections(documentsPath, operationData);
                    ImportMeters(documentsPath, operationData);
                }

                yield return loggedData;
            }
        }

        private void ImportMeters(string documentsPath, OperationData operationData)
        {
            var deviceElementUses = GetAllDeviceElementUses(operationData).Where(x => x.Value != null).SelectMany(x => x.Value);

            var workingDataFileName = string.Format(DatacardConstants.WorkingDataFile, operationData.Id.ReferenceId);
            var workingDataFilePath = Path.Combine(documentsPath, workingDataFileName);
            var allWorkingData = _protobufSerializer.Read<IEnumerable<WorkingData>>(workingDataFilePath);

            foreach (var deviceElementUse in deviceElementUses)
            {
                var deviceElementUseWorkingData = allWorkingData.Where(x => x.DeviceElementUseId == deviceElementUse.Id.ReferenceId);
                deviceElementUse.GetWorkingDatas = () => deviceElementUseWorkingData;
            }
        }

        private static Dictionary<int, IEnumerable<DeviceElementUse>> GetAllDeviceElementUses(OperationData operationData)
        {
            if (operationData == null)
                return null;

            var sections = new Dictionary<int, IEnumerable<DeviceElementUse>>();

            for (var depth = 0; depth <= operationData.MaxDepth; depth++)
            {
                if (operationData.GetDeviceElementUses == null)
                    continue;

                var levelSections = operationData.GetDeviceElementUses(depth);
                sections.Add(depth, levelSections);
            }

            return sections;
        }

        private void ImportSections(string documentsPath, OperationData operationData)
        {
            var sectionsFileName = string.Format(DatacardConstants.SectionFile, operationData.Id.ReferenceId);
            var sectionsFilePath = Path.Combine(documentsPath, sectionsFileName);
            var sections = _protobufSerializer.Read<Dictionary<int, IEnumerable<DeviceElementUse>>>(sectionsFilePath);

            if (sections != null && sections.Any())
                operationData.GetDeviceElementUses = x => sections[x] ?? new List<DeviceElementUse>();
        }

        private void ImportSpatialRecords(string documentsPath, OperationData operationData)
        {
            var spatialRecordFileName = string.Format(DatacardConstants.OperationDataFile, operationData.Id.ReferenceId);
            var spatialRecordFilePath = Path.Combine(documentsPath, spatialRecordFileName);

            operationData.GetSpatialRecords = () => _protobufSerializer.ReadSpatialRecords(spatialRecordFilePath);
        }
    }
}