using System;
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
        private readonly IBinaryWriter _binaryWriter;

        public Plugin() : this(new BinaryWriter())
        {
            
        }

        public Plugin(IBinaryWriter binaryWriter)
        {
            _binaryWriter = binaryWriter;
        }

        private const string PluginFolderAndExtension = "adm";
        private const string DocumentsFolder = "documents";
        private const string SectionFile = "Section{0}." + PluginFolderAndExtension;
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

            return new ApplicationDataModel
            {
                ProprietaryValues = ImportData<List<ProprietaryValue>>(path, ProprietaryValuesAdm),
                Catalog = ImportData<Catalog>(path, CatalogAdm),
                Documents = ImportData<Documents>(path, DocumentAdm),
                ReferenceLayers = ImportData<List<ReferenceLayer>>(path, ReferencelayersAdm)
            };
        }

        public void Export(ApplicationDataModel dataModel, string exportPath, Properties properties = null)
        {
            var path = Path.Combine(exportPath, PluginFolderAndExtension);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            ExportData(path, ProprietaryValuesAdm, dataModel.ProprietaryValues);
            ExportData(path, CatalogAdm, dataModel.Catalog);
            ExportData(path, DocumentAdm, dataModel.Documents);
            ExportData(path, ReferencelayersAdm, dataModel.ReferenceLayers);
            ExportBinary(path, dataModel.Documents);
        }

        public Properties GetProperties(string dataPath)
        {
            return new Properties();
        }

        private void ExportBinary(string path, Documents documents)
        {
            if (documents == null || documents.LoggedData == null)
                return;

            foreach (var loggedData in documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    ProcessOperationData(path, operationData);
                }
            }
        }

        private void ProcessOperationData(string path, OperationData operationData)
        {
            var documentsPath = Path.Combine(path, DocumentsFolder);
            if (!Directory.Exists(documentsPath))
                Directory.CreateDirectory(documentsPath);

            ProcessSections(documentsPath, operationData);

            ProcessSpatialRecords(documentsPath, operationData);
        }

        private void ProcessSpatialRecords(string documentsPath, OperationData operationData)
        {
            var spatialRecords = operationData.GetSpatialRecords().GetEnumerator();

            while (spatialRecords.MoveNext())
            {
                var spatialRecord = spatialRecords.Current;
                _binaryWriter.Write(spatialRecord, documentsPath);
            }
        }

        private void ProcessSections(string documentsPath, OperationData operationData)
        {
            var sections = new List<Section>();
            for (var depth = 0; depth < operationData.MaxDepth; depth++)
            {
                sections.AddRange(operationData.GetSections(depth));
            }

            ExportData(documentsPath, string.Format(SectionFile, operationData.Id.ReferenceId), sections);
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
    } 
}
