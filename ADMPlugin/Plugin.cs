﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
﻿using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Newtonsoft.Json;

namespace ADMPlugin
{
    public class Plugin : IPlugin
    {
        private readonly IProtobufSerializer _protobufSerializer;

        public Plugin() : this(new ProtobufSerializer())
        {
            
        }

        public Plugin(IProtobufSerializer protobufSerializer)
        {
            _protobufSerializer = protobufSerializer;
        }

        private const string PluginFolderAndExtension = "adm";
        private const string DocumentsFolder = "documents";
        private const string SectionFile = "Section{0}." + PluginFolderAndExtension;
        private const string MeterFile = "Meter{0}." + PluginFolderAndExtension;
        private const string OperationDataFile = "OperationData{0}." + PluginFolderAndExtension;
        private const string FileFormat =  "{0}." + PluginFolderAndExtension;

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

        public List<IError> ValidateDataOnCard(string dataPath, Properties properties = null)
        {
            return new List<IError>();
        }

        public ApplicationDataModel Import(string path, Properties properties = null)
        {
            if (!IsDataCardSupported(path, properties))
                return null;
            var documents = ImportData<Documents>(path, DocumentAdm);
            var catalog = _protobufSerializer.Read<Catalog>(Path.Combine(path, PluginFolderAndExtension, CatalogAdm));
            var proprietaryValues = ImportData<List<ProprietaryValue>>(path, ProprietaryValuesAdm);
            var referenceLayers = ImportData<List<ReferenceLayer>>(path, ReferencelayersAdm);

            var applicationDataModel = new ApplicationDataModel
            {
                ProprietaryValues = proprietaryValues,
                Catalog = catalog,
                Documents = documents,
                ReferenceLayers = referenceLayers
            };

            ImportLoggingData(path, applicationDataModel.Documents.LoggedData);
            return applicationDataModel;
        }

        private void ImportLoggingData(string path, IEnumerable<LoggedData> loggedDatas)
        {
            foreach (var loggedData in loggedDatas)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    ImportSpatialRecords(path, operationData);
                    ImportSections(path, operationData);
                    ImportMeters(path, operationData);
                }
            }
        }

        private void ImportMeters(string path, OperationData operationData)
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
        }

        private void ImportSections(string path, OperationData operationData)
        {
            var sectionsFileName = string.Format(SectionFile, operationData.Id.ReferenceId);
            var sectionsFilePath = Path.Combine(path, PluginFolderAndExtension, DocumentsFolder, sectionsFileName);
            var sections = _protobufSerializer.Read<Dictionary<int, IEnumerable<Section>>>(sectionsFilePath);

            if(sections != null)
                operationData.GetSections = x => sections[x] ?? new List<Section>();
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

            ExportData(path, ProprietaryValuesAdm, dataModel.ProprietaryValues);
            //ExportData(path, CatalogAdm, dataModel.Catalog);
            var catalogFilePath = Path.Combine(path, CatalogAdm);
            _protobufSerializer.Write(catalogFilePath, dataModel.Catalog);
            ExportData(path, DocumentAdm, dataModel.Documents);
            ExportData(path, ReferencelayersAdm, dataModel.ReferenceLayers);
            ExportProtobuf(path, dataModel.Documents);
        }

        private void ExportProtobuf(string path, Documents documents)
        {
            if (documents == null || documents.LoggedData == null)
                return;

            foreach (var operationData in documents.LoggedData.SelectMany(x => x.OperationData))
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
            if(operationData == null)
                return null;

            var sections = new Dictionary<int, IEnumerable<Section>>();

            for (var depth = 0; depth <= operationData.MaxDepth; depth++)
            {
                if(operationData.GetSections == null)
                    continue;

                var levelSections = operationData.GetSections(depth);
                sections.Add(depth, levelSections);
            }

            return sections;
        }
    } 
}
