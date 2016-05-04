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
        private readonly DocumentsExporter _documentsExporter;
        private readonly DocumentsImporter _documentsImporter;

        public Plugin()
            : this(new ProtobufSerializer(), new ProtobufReferenceLayerSerializer())
        {
        }

        public Plugin(IProtobufSerializer protobufSerializer, IProtobufReferenceLayerSerializer protobufReferenceLayerSerializer)
        {
            _documentsImporter = new DocumentsImporter(protobufSerializer);
            _documentsExporter = new DocumentsExporter(protobufSerializer);
            _protobufSerializer = protobufSerializer;
            _protobufReferenceLayerSerializer = protobufReferenceLayerSerializer;
        }

        public string Name
        {
            get { return DatacardConstants.PluginFolderAndExtension.ToUpper(); }
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
            get { return String.Format(DatacardConstants.FileFormat, "ProprietaryValues"); }
        }

        private static string CatalogAdm
        {
            get { return String.Format(DatacardConstants.FileFormat, "Catalog"); }
        }

        private static string DocumentAdm
        {
            get { return String.Format(DatacardConstants.FileFormat, "Document"); }
        }

        private static string ReferencelayersAdm
        {
            get { return String.Format(DatacardConstants.FileFormat, "ReferenceLayers"); }
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
            var path = Path.Combine(dataPath, DatacardConstants.PluginFolderAndExtension);

            return Directory.Exists(path)
                && Directory.GetFiles(path, String.Format(DatacardConstants.FileFormat, "*"), SearchOption.AllDirectories)
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
            var catalog = ImportData<Catalog>(path, CatalogAdm);
            var documents = _documentsImporter.ImportDocuments(path, DocumentAdm, catalog);
            var proprietaryValues = ImportData<List<ProprietaryValue>>(path, ProprietaryValuesAdm);
            var referenceLayers = ImportReferenceLayers(path, ReferencelayersAdm); 

            var applicationDataModel = new ApplicationDataModel
            {
                ProprietaryValues = proprietaryValues,
                Catalog = catalog,
                Documents = documents,
                ReferenceLayers = referenceLayers
            };

            return new[] { applicationDataModel };
        }

        private IEnumerable<ReferenceLayer> ImportReferenceLayers(string path, string filename)
        {
            var filepath = Path.Combine(path, DatacardConstants.PluginFolderAndExtension);
            return _protobufReferenceLayerSerializer.Import(filepath, filename);
        }

        public void Export(ApplicationDataModel dataModel, string exportPath, Properties properties = null)
        {
            var path = Path.Combine(exportPath, DatacardConstants.PluginFolderAndExtension);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            _documentsExporter.ExportDocuments(path, dataModel.Documents);
            ExportReferenceLayers(path, ReferencelayersAdm, dataModel.ReferenceLayers);
            ExportData(path, ProprietaryValuesAdm, dataModel.ProprietaryValues);
            ExportData(path, CatalogAdm, dataModel.Catalog);
        }

        private void ExportReferenceLayers(string filePath, string fileName, IEnumerable<ReferenceLayer> referenceLayers)
        {
            _protobufReferenceLayerSerializer.Export(filePath, fileName, referenceLayers);
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
