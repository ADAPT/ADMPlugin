using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Newtonsoft.Json;

namespace ADMPlugin
{
    public class Plugin : IPlugin
    {
        private readonly IProtobufReferenceLayerSerializer _protobufReferenceLayerSerializer;
        private readonly IAdmVersionInfoWriter _admVersionInfoWriter;
        private readonly IAdmVersionInfoReader _admVersionInfoReader;
        private readonly DocumentsExporter _documentsExporter;
        private readonly DocumentsImporter _documentsImporter;

        private const string AdmVersionFilename = "AdmVersion.info";

        public Plugin()
            : this(new ProtobufSerializer(), new ProtobufReferenceLayerSerializer(), new AdmVersionInfoWriter(), new AdmVersionInfoReader())
        {
        }

        public Plugin(IProtobufSerializer protobufSerializer, IProtobufReferenceLayerSerializer protobufReferenceLayerSerializer, IAdmVersionInfoWriter admVersionInfoWriter, IAdmVersionInfoReader admVersionInfoReader)
        {
            _documentsImporter = new DocumentsImporter(protobufSerializer);
            _documentsExporter = new DocumentsExporter(protobufSerializer);
            _protobufReferenceLayerSerializer = protobufReferenceLayerSerializer;
            _admVersionInfoWriter = admVersionInfoWriter;
            _admVersionInfoReader = admVersionInfoReader;
        }

        public string Name
        {
            get { return DatacardConstants.PluginFolderAndExtension.ToUpper(); }
        }

        public string Version
        {
            get
            {
                var version = Assembly.GetExecutingAssembly().GetName().Version;
                return version.ToString();
            }
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

            if (! (Directory.Exists(path) && Directory.GetFiles(path, String.Format(DatacardConstants.FileFormat, "*"), SearchOption.AllDirectories).Any()))
                return false;

            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var currentMajorVersion = currentVersion.Substring(0, currentVersion.IndexOf('.'));

            var filename = Path.Combine(dataPath, AdmVersionFilename);
            var dataVersionModel = _admVersionInfoReader.ReadVersionInfoModel(filename);

            if (dataVersionModel == null)
                return true;
            
            var dataVersion = dataVersionModel.AdmVersion;
            var dataMajorVersion = dataVersion.Substring(0, currentVersion.IndexOf('.'));

            if (currentMajorVersion == dataMajorVersion)
                return true;

            return false;
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

            var versionFile = Path.Combine(path, AdmVersionFilename);
            _admVersionInfoWriter.WriteVersionInfoFile(versionFile);

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
