using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace ADMPlugin
{
    public class DocumentsExporter
    {
        private readonly IProtobufSerializer _protobufSerializer;

        public DocumentsExporter() : this(new ProtobufSerializer())
        {
        }

        public DocumentsExporter(IProtobufSerializer protobufSerializer)
        {
            _protobufSerializer = protobufSerializer;
        }

        public void ExportDocuments(string path, Documents documents)
        {
            if (documents == null)
                return;

            var documentsPath = Path.Combine(path, DatacardConstants.DocumentsFolder);
            if (!Directory.Exists(documentsPath))
                Directory.CreateDirectory(documentsPath);

            WriteLoggedData(documents, documentsPath);
            WriteGuidanceAllocations(documents, documentsPath);
            WritePlans(documents, documentsPath);
            WriteRecommendations(documents, documentsPath);
            WriteSummaries(documents, documentsPath);
            WriteWorkItemOperations(documents, documentsPath);
            WriteWorkItems(documents, documentsPath);
            WriteWorkOrders(documents, documentsPath);
        }

        private void WriteWorkOrders(Documents documents, string documentsPath)
        {
            if(documents.WorkOrders == null)
                return;

            foreach (var workOrder in documents.WorkOrders)
            {
                if (workOrder != null)
                {
                    WriteObject(documentsPath, workOrder, workOrder.Id.ReferenceId, DatacardConstants.WorkOrderFile);
                }
            }
        }

        private void WriteWorkItems(Documents documents, string documentsPath)
        {
            if(documents.WorkItems == null)
                return;

            foreach (var workItem in documents.WorkItems)
            {
                if (workItem != null)
                {
                    WriteObject(documentsPath, workItem, workItem.Id.ReferenceId, DatacardConstants.WorkItemFile);
                }
            }
        }

        private void WriteWorkItemOperations(Documents documents, string documentsPath)
        {
            if(documents.WorkItemOperations == null)
                return;

            foreach (var workItemOperation in documents.WorkItemOperations)
            {
                if (workItemOperation != null)
                {
                    WriteObject(documentsPath, workItemOperation, workItemOperation.Id.ReferenceId, DatacardConstants.WorkItemOperationFile);
                }
            }
        }

        private void WriteSummaries(Documents documents, string documentsPath)
        {
            if(documents.Summaries == null)
                return;

            var filePath = Path.Combine(documentsPath, DatacardConstants.SummariesFile);
            _protobufSerializer.Write(filePath, documents.Summaries);
        }

        private void WriteRecommendations(Documents documents, string documentsPath)
        {
            if(documents.Recommendations == null)
                return;

            foreach (var recommendation in documents.Recommendations)
            {
                if (recommendation != null)
                {
                    WriteObject(documentsPath, recommendation, recommendation.Id.ReferenceId, DatacardConstants.RecommendationFile);
                }
            }
        }

        private void WritePlans(Documents documents, string documentsPath)
        {
            if(documents.Plans == null)
                return;

            foreach (var plan in documents.Plans)
            {
                if (plan != null)
                {
                    WriteObject(documentsPath, plan, plan.Id.ReferenceId, DatacardConstants.PlanFile);
                }
            }
        }

        private void WriteGuidanceAllocations(Documents documents, string documentsPath)
        {
            if (documents.GuidanceAllocations == null)
                return;

            foreach (var guidanceAllocation in documents.GuidanceAllocations)
            {
                if (guidanceAllocation != null)
                {
                    WriteObject(documentsPath, guidanceAllocation, guidanceAllocation.Id.ReferenceId, DatacardConstants.GuidanceAllocationFile);
                }
            }
        }

        private void WriteLoggedData(Documents documents, string documentsPath)
        {
            if(documents.LoggedData == null)
                return;

            foreach (var loggedData in documents.LoggedData)
            {
                if (loggedData != null)
                {
                    if (loggedData.OperationData != null)
                    {
                        loggedData.OperationData = loggedData.OperationData.ToList();
                        foreach (var operationData in loggedData.OperationData)
                        {
                            ExportSpatialRecords(documentsPath, operationData);
                            ExportSectionsAndMeters(documentsPath, operationData);
                        }
                    }
                    WriteObject(documentsPath, loggedData, loggedData.Id.ReferenceId, DatacardConstants.LoggedDataFile);
                }
            }
        }

        private void WriteObject<T>(string documentsPath, T @object, int referenceId, string fileNameFormat)
        {
            var fileName = String.Format(fileNameFormat, referenceId);
            var filePath = Path.Combine(documentsPath, fileName);
            _protobufSerializer.Write(filePath, @object);
        }

        private void ExportSpatialRecords(string documentsPath, OperationData operationData)
        {
            var fileName = string.Format(DatacardConstants.OperationDataFile, operationData.Id.ReferenceId);
            var filePath = Path.Combine(documentsPath, fileName);

            if (operationData.GetSpatialRecords == null)
            {
                _protobufSerializer.WriteSpatialRecords(filePath, new List<SpatialRecord>());
                return;
            }

            var spatialRecords = operationData.GetSpatialRecords();
            
            _protobufSerializer.WriteSpatialRecords(filePath, spatialRecords);
        }

        private void ExportSectionsAndMeters(string documentsPath, OperationData operationData)
        {
            var deviceElementUses = GetAllDeviceElementUses(operationData);
            var deviceElementUseFileName = string.Format(DatacardConstants.SectionFile, operationData.Id.ReferenceId);
            var deviceElementUseFilePath = Path.Combine(documentsPath, deviceElementUseFileName);

            var workingData = deviceElementUses.SelectMany(deviceElementUse => deviceElementUse.Value.SelectMany(x => x.GetWorkingDatas()));
            var workingDataFileName = string.Format(DatacardConstants.WorkingDataFile, operationData.Id.ReferenceId);
            var workingDataFilePath = Path.Combine(documentsPath, workingDataFileName);

            _protobufSerializer.Write(deviceElementUseFilePath, deviceElementUses);
            _protobufSerializer.Write(workingDataFilePath, workingData);
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
    }
}