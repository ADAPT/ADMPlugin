using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
﻿using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Newtonsoft.Json;

namespace ADMPlugin
{
    public class Plugin : IPlugin
    {
        private readonly IProtobufSerializer _protobufSerializer;
        private readonly IProtobufReferenceLayerSerializer _protobufReferenceLayerSerializer;

        public Plugin()
            : this(new ProtobufSerializer(), new ProtobufReferenceLayerSerializer())
        {

        }

        public Plugin(IProtobufSerializer protobufSerializer, IProtobufReferenceLayerSerializer protobufReferenceLayerSerializer)
        {
            _protobufSerializer = protobufSerializer;
            _protobufReferenceLayerSerializer = protobufReferenceLayerSerializer;
        }

        private const string PluginFolderAndExtension = "adm";
        private const string DocumentsFolder = "documents";
        private const string SectionFile = "Section{0}." + PluginFolderAndExtension;
        private const string MeterFile = "Meter{0}." + PluginFolderAndExtension;
        private const string OperationDataFile = "OperationData{0}." + PluginFolderAndExtension;
        private const string FileFormat = "{0}." + PluginFolderAndExtension;

        public string Name
        {
            get { return PluginFolderAndExtension.ToUpper(); }
        }

        public string Version
        {
            get { return "1.0"; }
        }

        public string Owner
        {
            get { return "AgGateway"; }
        }

        private static string ProprietaryValuesAdm
        {
            get { return String.Format(FileFormat, "ProprietaryValues"); }
        }

        private static string CatalogAdm
        {
            get { return String.Format(FileFormat, "Catalog"); }
        }

        private static string DocumentAdm
        {
            get { return String.Format(FileFormat, "Document"); }
        }

        private static string ReferencelayersAdm
        {
            get { return String.Format(FileFormat, "ReferenceLayers"); }
        }

        private JsonSerializer Serializer
        {
            get
            {
                return new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.All,
                    ContractResolver = new AdaptContractResolver()

                };
            }
        }

        public void Initialize(string args = null)
        {
        }

        public Properties GetProperties(string dataPath)
        {
            return new Properties();
        }

        public bool IsDataCardSupported(string dataPath, Properties properties = null)
        {
            var path = Path.Combine(dataPath, PluginFolderAndExtension);

            return Directory.Exists(path)
                && Directory.GetFiles(path, String.Format(FileFormat, "*"), SearchOption.AllDirectories)
                .Any();
        }

        public IList<IError> ValidateDataOnCard(string dataPath, Properties properties = null)
        {
            return new List<IError>();
        }

        public IList<ApplicationDataModel> Import(string path, Properties properties = null)
        {
            if (!IsDataCardSupported(path, properties))
                return null;
            var documents = ImportDocuments(path, DocumentAdm);
            var catalog = ImportData<Catalog>(path, CatalogAdm);
            var proprietaryValues = ImportData<List<ProprietaryValue>>(path, ProprietaryValuesAdm);
            var referenceLayers = ImportReferenceLayers(path, ReferencelayersAdm); 

            var applicationDataModel = new ApplicationDataModel
            {
                ProprietaryValues = proprietaryValues,
                Catalog = catalog,
                Documents = documents,
                ReferenceLayers = referenceLayers
            };

            var loggedData = null as IEnumerable<LoggedData>;

            if (applicationDataModel.Documents != null)
                loggedData = applicationDataModel.Documents.LoggedData;

            ImportLoggingData(path, loggedData, applicationDataModel.Catalog);
            return new[] { applicationDataModel };
        }

        private IEnumerable<ReferenceLayer> ImportReferenceLayers(string path, string filename)
        {
            var filepath = Path.Combine(path, PluginFolderAndExtension);
            return _protobufReferenceLayerSerializer.Import(filepath, filename);
        }

        private Documents ImportDocuments(string path, string documentAdm)
        {
            var filename = Path.Combine(path, PluginFolderAndExtension, documentAdm);
            var documents = _protobufSerializer.Read<Documents>(filename);
            return documents;
        }

        private void ImportLoggingData(string path, IEnumerable<LoggedData> loggedDatas, Catalog catalog)
        {
            if (loggedDatas == null)
                return;

            foreach (var loggedData in loggedDatas)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    ImportSpatialRecords(path, operationData);
                    ImportSections(path, operationData, catalog);
                    ImportMeters(path, operationData, catalog);
                }
            }
        }

        private void ImportMeters(string path, OperationData operationData, Catalog catalog)
        {
            var sections = GetAllSections(operationData).Where(x => x.Value != null).SelectMany(x => x.Value);

            var metersFileName = string.Format(MeterFile, operationData.Id.ReferenceId);
            var metersFilePath = Path.Combine(path, PluginFolderAndExtension, DocumentsFolder, metersFileName);
            var allMeters = _protobufSerializer.Read<IEnumerable<Meter>>(metersFilePath);

            foreach (var section in sections)
            {
                var sectionMeters = allMeters.Where(x => x.SectionId == section.Id.ReferenceId);
                section.GetMeters = () => sectionMeters;
            }

            var equipmentConfig = catalog.EquipmentConfigs.SingleOrDefault(x => x.Id.ReferenceId == operationData.EquipmentConfigId);
            if (equipmentConfig != null)
                equipmentConfig.Meters = allMeters;
        }

        private void ImportSections(string path, OperationData operationData, Catalog catalog)
        {
            var sectionsFileName = string.Format(SectionFile, operationData.Id.ReferenceId);
            var sectionsFilePath = Path.Combine(path, PluginFolderAndExtension, DocumentsFolder, sectionsFileName);
            var sections = _protobufSerializer.Read<Dictionary<int, IEnumerable<Section>>>(sectionsFilePath);

            if (sections != null)
            {
                operationData.GetSections = x => sections[x] ?? new List<Section>();
                var equipmentConfig = catalog.EquipmentConfigs.SingleOrDefault(x => x.Id.ReferenceId == operationData.EquipmentConfigId);
                if (equipmentConfig != null)
                    equipmentConfig.Sections = sections.Where(x => x.Value != null).SelectMany(x => x.Value);
            }
        }

        private void ImportSpatialRecords(string path, OperationData operationData)
        {
            var spatialRecordFileName = string.Format(OperationDataFile, operationData.Id.ReferenceId);
            var spatialRecordFilePath = Path.Combine(path, PluginFolderAndExtension, DocumentsFolder, spatialRecordFileName);

            operationData.GetSpatialRecords = () => _protobufSerializer.ReadSpatialRecords(spatialRecordFilePath);
        }

        public void Export(ApplicationDataModel dataModel, string exportPath, Properties properties = null)
        {
            var path = Path.Combine(exportPath, PluginFolderAndExtension);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            ExportProtobuf(path, dataModel.Documents);
            ExportReferenceLayers(path, ReferencelayersAdm, dataModel.ReferenceLayers);
            ExportData(path, ProprietaryValuesAdm, dataModel.ProprietaryValues);
            ExportData(path, CatalogAdm, dataModel.Catalog);
        }

        private void ExportReferenceLayers(string filePath, string fileName, IEnumerable<ReferenceLayer> referenceLayers)
        {
            _protobufReferenceLayerSerializer.Export(filePath, fileName, referenceLayers);
        }

        private void ExportProtobuf(string path, Documents documents)
        {
            if (documents == null || documents.LoggedData == null)
                return;

            var fileName = String.Format(FileFormat, "Document");
            var filePath = Path.Combine(path, fileName);

            var operationDatas = documents.LoggedData.SelectMany(x => x.OperationData).ToList();
            ExportDocuments(filePath, documents);

            foreach (var operationData in operationDatas)
            {
                if (operationData == null)
                    continue;

                var documentsPath = Path.Combine(path, DocumentsFolder);
                if (!Directory.Exists(documentsPath))
                    Directory.CreateDirectory(documentsPath);

                ExportSpatialRecords(documentsPath, operationData);
                ExportSectionsAndMeters(documentsPath, operationData);
            }
        }

        private void ExportDocuments(string filePath, Documents documents)
        {
            _protobufSerializer.Write(filePath, documents);
        }

        private void ExportSpatialRecords(string documentsPath, OperationData operationData)
        {
            var spatialRecords = operationData.GetSpatialRecords();

            var fileName = string.Format(OperationDataFile, operationData.Id.ReferenceId);
            var filePath = Path.Combine(documentsPath, fileName);

            _protobufSerializer.WriteSpatialRecords(filePath, spatialRecords);
        }

        private void ExportSectionsAndMeters(string documentsPath, OperationData operationData)
        {
            var sections = GetAllSections(operationData);
            var sectionsFileName = string.Format(SectionFile, operationData.Id.ReferenceId);
            var sectionsFilePath = Path.Combine(documentsPath, sectionsFileName);

            var meters = sections.SelectMany(section => section.Value.SelectMany(x => x.GetMeters()));
            var metersFileName = string.Format(MeterFile, operationData.Id.ReferenceId);
            var metersFilePath = Path.Combine(documentsPath, metersFileName);

            _protobufSerializer.Write(sectionsFilePath, sections);
            _protobufSerializer.Write(metersFilePath, meters);
        }

        private T ImportData<T>(string path, string searchPattern)
        {
            var files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
            if (files.Length == 0)
                return default(T);

            var jsonFormat = Path.GetTempFileName();
            try
            {
                ZipUtil.Unzip(files.First(), jsonFormat);
                return Deserialize<T>(jsonFormat);
            }
            finally
            {
                try
                {
                    File.Delete(jsonFormat);
                }
                catch { }
            }
        }

        private void ExportData<T>(string path, string fileName, T dataModel)
        {
            if (Equals(dataModel, default(T)))
            {
                return;
            }

            var jsonFormat = Path.GetTempFileName();
            try
            {
                Serialize(dataModel, jsonFormat);
                ZipUtil.Zip(Path.Combine(path, fileName), jsonFormat);
            }
            finally
            {
                try
                {
                    File.Delete(jsonFormat);
                }
                catch { }
            }
        }

        private void Serialize<T>(T dataModel, string file)
        {
            using (var fileStream = File.Open(file, FileMode.Create, FileAccess.ReadWrite))
            using (var streamWriter = new StreamWriter(fileStream))
            using (var textWriter = new JsonTextWriter(streamWriter) { Formatting = Formatting.Indented })
            {
                Serializer.Serialize(textWriter, dataModel);
            }
        }

        private T Deserialize<T>(string file)
        {
            using (var fileStream = File.Open(file, FileMode.Open))
            using (var streamReader = new StreamReader(fileStream))
            using (var textReader = new JsonTextReader(streamReader))
            {
                return Serializer.Deserialize<T>(textReader);
            }
        }

        private static Dictionary<int, IEnumerable<Section>> GetAllSections(OperationData operationData)
        {
            if (operationData == null)
                return null;

            var sections = new Dictionary<int, IEnumerable<Section>>();

            for (var depth = 0; depth <= operationData.MaxDepth; depth++)
            {
                if (operationData.GetSections == null)
                    continue;

                var levelSections = operationData.GetSections(depth);
                sections.Add(depth, levelSections);
            }

            return sections;
        }
    }
}
