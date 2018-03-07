using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AgGateway.ADAPT.ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using AgGateway.ADAPT.TestUtilities;

namespace AgGateway.ADAPT.PluginTest
{
    [TestFixture]
    public class PluginTest
    {
        private Plugin _plugin;
        private string _cardPath;
        private Mock<IProtobufSerializer> _protobufSerializerMock;
        private Mock<IProtobufReferenceLayerSerializer> _protobufReferenceSerializerMock;
        private Mock<IAdmVersionInfoWriter> _admVersionInfoWriterMock;
        private Mock<IAdmVersionInfoReader> _admVersionInfoReaderMock;
        private Mock<InternalJsonSerializer> _internalJsonSerializerMock;
        private string _tempPath;

        private const string AdmVersionFilename = "AdmVersion.info";

        [SetUp]
        public void Setup()
        {
            _protobufSerializerMock = new Mock<IProtobufSerializer>();
            _protobufReferenceSerializerMock = new Mock<IProtobufReferenceLayerSerializer>();
            _admVersionInfoWriterMock = new Mock<IAdmVersionInfoWriter>();
            _admVersionInfoReaderMock = new Mock<IAdmVersionInfoReader>();
            _internalJsonSerializerMock = new Mock<InternalJsonSerializer>();


            _cardPath = DatacardUtility.WriteDatacard("TestDatacard");
            _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            SetupVersionInfoMock();

            _plugin = new Plugin(_protobufSerializerMock.Object,
                _protobufReferenceSerializerMock.Object,
                _admVersionInfoWriterMock.Object,
                _admVersionInfoReaderMock.Object,
                _internalJsonSerializerMock.Object);
        }

        private void SetupVersionInfoMock()
        {
            var currentVersion = typeof(Plugin).Assembly.GetName().Version;

            var versionInfoModel = new AdmVersionInfoModel { AdmVersion = currentVersion.ToString() };
            var expectedFilename = Path.Combine(_cardPath, DatacardConstants.PluginFolderAndExtension, AdmVersionFilename);
            _admVersionInfoReaderMock.Setup(x => x.ReadVersionInfoModel(expectedFilename)).Returns(versionInfoModel);
        }

        [Test]
        public void GivenPluginWhenGetNameThenAdmIsReturned()
        {
            var result = _plugin.Name;
            Assert.AreEqual("ADM", result);
        }

        [Test]
        public void GivenPluginWhenGetVersionThenOnePopIntOIsReturned()
        {
            var currentVersion = typeof(Plugin).Assembly.GetName().Version;

            var result = _plugin.Version;
            Assert.AreEqual(currentVersion.ToString(), result);
        }

        [Test]
        public void GivenPluginWhenGetOwnerThenAgGatewayIsReturned()
        {
            var result = _plugin.Owner;
            Assert.AreEqual("AgGateway", result);
        }

        [Test]
        public void GivenPluginAndDataCardWhenIsDataCardSupportedThenTrueIsReturned()
        {
            var sourcePath = Path.Combine(_cardPath, "adm");
            Directory.CreateDirectory(sourcePath);

            using (File.Create(Path.Combine(sourcePath, "ILikeTurtles.adm")))
            {
                var result = _plugin.IsDataCardSupported(_cardPath);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void GivenPluginWithInvalidStructureWhenIsDataCardSupportedThenFalseIsReturned()
        {
            Directory.Delete(_cardPath, true);
            _cardPath = DatacardUtility.WriteDatacard("IncorrectHierarchy");

            var result = _plugin.IsDataCardSupported(_cardPath);
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenPluginWithInvalidFileWhenIsDataCardSupportedThenFalseIsReturned()
        {
            Directory.Delete(_cardPath, true);
            _cardPath = DatacardUtility.WriteDatacard("IncorrectFiles");

            var result = _plugin.IsDataCardSupported(_cardPath);
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenPluginWhenValidateDataOnCardThenNewListReturned()
        {
            var result = _plugin.ValidateDataOnCard(_cardPath);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GivenPluginWhenGetPropertiesThenNewPropertiesIsReturned()
        {
            var sourcePath = Path.Combine(_cardPath, "adm");
            Directory.CreateDirectory(sourcePath);

            var result = _plugin.GetProperties(sourcePath);
            Assert.IsInstanceOf<Properties>(result);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenProprietaryValuesAreImported()
        {
            var result = _plugin.Import(_cardPath).First();
            Assert.IsNotEmpty(result.ProprietaryValues);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenCatalogIsImported()
        {
            var result = _plugin.Import(_cardPath).First();
            Assert.NotNull(result.Catalog);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenSpatialRecordsAreImported()
        {
            CreateDocuments();

            var path = Path.Combine(_cardPath, "adm", "documents", "OperationData-367.adm");
            var spatialRecords = new List<SpatialRecord>();
            _protobufSerializerMock.Setup(x => x.ReadSpatialRecords(path)).Returns(spatialRecords);

            var result = _plugin.Import(_cardPath).First();
            foreach (var loggedData in result.Documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    Assert.NotNull(operationData.GetSpatialRecords());
                }
            }
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenOperationdDataSectionsAreImported()
        {
            var path = Path.Combine(_cardPath, "adm", "documents", "Section-367.adm");
            var pretendSections = new Dictionary<int, IEnumerable<DeviceElementUse>> { { 0, new List<DeviceElementUse>() } };
            _protobufSerializerMock.Setup(x => x.Read<Dictionary<int, IEnumerable<DeviceElementUse>>>(path)).Returns(pretendSections);

            CreateDocuments();

            var result = _plugin.Import(_cardPath).First();
            foreach (var loggedData in result.Documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    var sections = operationData.GetDeviceElementUses(0);
                    Assert.NotNull(sections);
                }
            }
        }

        private void CreateDocuments()
        {
            var operationData1 = new OperationData();
            operationData1.Id.ReferenceId = -367;
            var documents = new Documents
            {
                LoggedData = new List<LoggedData>
                {
                    new LoggedData
                    {
                        OperationData = new List<OperationData>
                        {
                            operationData1
                        }
                    }
                }
            };
            var documentFilePath = Path.Combine(_cardPath, "adm", "Document.adm");
            _protobufSerializerMock.Setup(x => x.Read<Documents>(documentFilePath)).Returns(documents);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenMetersAreImported()
        {
            var sectionPath = Path.Combine(_cardPath, "adm", "documents", "Section-367.adm");
            var pretendSections = new Dictionary<int, IEnumerable<DeviceElementUse>> { { 0, new List<DeviceElementUse>() } };
            _protobufSerializerMock.Setup(x => x.Read<Dictionary<int, IEnumerable<DeviceElementUse>>>(sectionPath)).Returns(pretendSections);

            var meterPath = Path.Combine(_cardPath, "adm", "documents", "Meter-367.adm");
            var pretendMeters = new List<WorkingData>();
            _protobufSerializerMock.Setup(x => x.Read<IEnumerable<WorkingData>>(meterPath)).Returns(pretendMeters);

            CreateDocuments();

            var result = _plugin.Import(_cardPath).First();
            foreach (var loggedData in result.Documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    var sections = operationData.GetDeviceElementUses(0);
                    var meters = sections.SelectMany(x => x.GetWorkingDatas());
                    Assert.NotNull(meters);
                }
            }
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenProprietaryValuesFileIsWritten()
        {
            var dataModel = new ApplicationDataModel.ADM.ApplicationDataModel
            {
                ProprietaryValues = new List<ProprietaryValue>
                {
                    new ProprietaryValue(),
                    new ProprietaryValue(),
                    new ProprietaryValue()
                }
            };

            _plugin.Export(dataModel, _tempPath);

            var fileExists = File.Exists(Path.Combine(_tempPath, "adm", "ProprietaryValues.adm"));
            Assert.IsTrue(fileExists);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenCatalogFileIsWritten()
        {
            var dataModel = new ApplicationDataModel.ADM.ApplicationDataModel
            {
                Catalog = new Catalog()
            };

            _plugin.Export(dataModel, _tempPath);

            var fileExists = File.Exists(Path.Combine(_tempPath, "adm", "Catalog.adm"));
            Assert.IsTrue(fileExists);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenReferenceLayersFileIsWritten()
        {
            var dataModel = new ApplicationDataModel.ADM.ApplicationDataModel
            {
                ReferenceLayers = new List<ReferenceLayer>
                {
                    new RasterReferenceLayer(),
                    new ShapeReferenceLayer()
                }
            };

            _plugin.Export(dataModel, _tempPath);
            var filepath = Path.Combine(_tempPath, "adm");
            var filename = "ReferenceLayers.adm";
            _protobufReferenceSerializerMock.Verify(x => x.Export(filepath, filename, dataModel.ReferenceLayers));
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenVersionFileIsWritten()
        {
            var dataModel = new ApplicationDataModel.ADM.ApplicationDataModel
            {
                ReferenceLayers = new List<ReferenceLayer>
                {
                    new RasterReferenceLayer(),
                    new ShapeReferenceLayer()
                }
            };

            _plugin.Export(dataModel, _tempPath);

            var expectedFilename = Path.Combine(_tempPath, DatacardConstants.PluginFolderAndExtension, AdmVersionFilename);
            _admVersionInfoWriterMock.Verify(x => x.WriteVersionInfoFile(expectedFilename), Times.Once);
        }

        [Test]
        public void GivenDatapathWhenIsSupportedThenTrueIfMajorVersionsMatch()
        {
            var currentVersion = typeof (Plugin).Assembly.GetName().Version;
            var version = new Version(currentVersion.Major, currentVersion.Minor);

            var versionInfoModel = new AdmVersionInfoModel { AdmVersion = version.ToString() };
            var expectedFilename = Path.Combine(_cardPath, DatacardConstants.PluginFolderAndExtension, AdmVersionFilename);
            _admVersionInfoReaderMock.Setup(x => x.ReadVersionInfoModel(expectedFilename)).Returns(versionInfoModel);

            var result =_plugin.IsDataCardSupported(_cardPath);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenDatapathWhenIsSupportedThenFalseIfMajorVersionsDoNotMatch()
        {
            var currentVersion = typeof(Plugin).Assembly.GetName().Version;
            var version = new Version(currentVersion.Major + 1, currentVersion.Minor);

            var versionInfoModel = new AdmVersionInfoModel { AdmVersion = version.ToString() };
            var expectedFilename = Path.Combine(_cardPath, DatacardConstants.PluginFolderAndExtension, AdmVersionFilename);
            _admVersionInfoReaderMock.Setup(x => x.ReadVersionInfoModel(expectedFilename)).Returns(versionInfoModel);

            var result = _plugin.IsDataCardSupported(_cardPath);

            Assert.That(result, Is.False);
        }

        [Test]
        public void GivenDatapathWhenIsSupportedThenTrueIfMinorVersionsMatch()
        {
            var currentVersion = typeof(Plugin).Assembly.GetName().Version;
            var version = new Version(currentVersion.Major, currentVersion.Minor);

            var versionInfoModel = new AdmVersionInfoModel { AdmVersion = version.ToString() };
            var expectedFilename = Path.Combine(_cardPath, DatacardConstants.PluginFolderAndExtension, AdmVersionFilename);
            _admVersionInfoReaderMock.Setup(x => x.ReadVersionInfoModel(expectedFilename)).Returns(versionInfoModel);

            var result = _plugin.IsDataCardSupported(_cardPath);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenDatapathWhenIsSupportedThenTrueIfMinorVersionsDoNotMatch()
        {
            var currentVersion = typeof(Plugin).Assembly.GetName().Version;
            var version = new Version(currentVersion.Major, currentVersion.Minor + 1);

            var versionInfoModel = new AdmVersionInfoModel { AdmVersion = version.ToString() };
            var expectedFilename = Path.Combine(_cardPath, DatacardConstants.PluginFolderAndExtension, AdmVersionFilename);
            _admVersionInfoReaderMock.Setup(x => x.ReadVersionInfoModel(expectedFilename)).Returns(versionInfoModel);

            var result = _plugin.IsDataCardSupported(_cardPath);

            Assert.That(result, Is.True);
        }

        [Test]
        public void GivenDatapathWithoutVersionFileWhenIsSupportedThenFalse()
        {
            _admVersionInfoReaderMock.Setup(x => x.ReadVersionInfoModel(It.IsAny<string>())).Returns(null as AdmVersionInfoModel);
            var result = _plugin.IsDataCardSupported(_cardPath);

            Assert.That(result, Is.True);
        }

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(_cardPath, true);
            if(Directory.Exists(_tempPath))
                Directory.Delete(_tempPath, true);
        }
    }
}
