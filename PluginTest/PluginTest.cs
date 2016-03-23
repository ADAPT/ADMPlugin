using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ADMPlugin;
using AgGateway.ADAPT.ApplicationDataModel;
using AgGateway.ADAPT.ApplicationDataModel.ADM;
using AgGateway.ADAPT.ApplicationDataModel.Documents;
using AgGateway.ADAPT.ApplicationDataModel.Equipment;
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;
using AgGateway.ADAPT.ApplicationDataModel.Logistics;
using AgGateway.ADAPT.ApplicationDataModel.ReferenceLayers;
using Moq;
using NUnit.Framework;
using TestUtilities;

namespace PluginTest
{
    [TestFixture]
    public class PluginTest
    {
        private Plugin _plugin;
        private string _testCardPath;
        private Mock<IProtobufSerializer> _protobufSerializerMock;

        [SetUp]
        public void Setup()
        {
            _protobufSerializerMock = new Mock<IProtobufSerializer>();

            _testCardPath = DatacardUtility.WriteDataCard("TestDatacard");
            _plugin = new Plugin(_protobufSerializerMock.Object);
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
            var result = _plugin.Version;
            Assert.AreEqual("1.0", result);
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
            var sourcePath = Path.Combine(_testCardPath, "adm");
            Directory.CreateDirectory(sourcePath);

            using(File.Create(Path.Combine(sourcePath, "ILikeTurtles.adm")))
            {
                var result = _plugin.IsDataCardSupported(_testCardPath);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public void GivenPluginWithInvalidStructureWhenIsDataCardSupportedThenFalseIsReturned()
        {
            _testCardPath = DatacardUtility.WriteDataCard("IncorrectHierarchy");

            var result = _plugin.IsDataCardSupported(_testCardPath);
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenPluginWithInvalidFileWhenIsDataCardSupportedThenFalseIsReturned()
        {
            _testCardPath = DatacardUtility.WriteDataCard("IncorrectFiles");

            var result = _plugin.IsDataCardSupported(_testCardPath);
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenPluginWhenValidateDataOnCardThenNewListReturned()
        {
            var result = _plugin.ValidateDataOnCard(_testCardPath);
            Assert.IsEmpty(result);
        }

        [Test]
        public void GivenPluginWhenGetPropertiesThenNewPropertiesIsReturned()
        {
            var sourcePath = Path.Combine(_testCardPath, "adm");
            Directory.CreateDirectory(sourcePath);

            var result = _plugin.GetProperties(sourcePath);
            Assert.IsInstanceOf<Properties>(result);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenProprietaryValuesAreImported()
        {
            var result = _plugin.Import(_testCardPath);
            Assert.IsNotEmpty(result.ProprietaryValues);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenCatalogIsImported()
        {
            var path = Path.Combine(_testCardPath, "adm", "Catalog.adm");
            _protobufSerializerMock.Setup(x => x.Read<Catalog>(path)).Returns(new Catalog());

            var result = _plugin.Import(_testCardPath);
            Assert.NotNull(result.Catalog);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenDocumentsIsImported()
        {
            var result = _plugin.Import(_testCardPath);
            Assert.NotNull(result.Documents);
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenSpatialRecordsAreImported()
        {
            var path = Path.Combine(_testCardPath, "adm", "documents", "OperationData-367.adm");
            var spatialRecords = new List<SpatialRecord>();
            _protobufSerializerMock.Setup(x => x.ReadSpatialRecords(path)).Returns(spatialRecords);

            var result = _plugin.Import(_testCardPath);
            foreach (var loggedData in result.Documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    Assert.NotNull(operationData.GetSpatialRecords());
                }
            }
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenSectionsAreImported()
        {
            var path = Path.Combine(_testCardPath, "adm", "documents", "Section-367.adm");
            var pretendSections = new Dictionary<int, IEnumerable<Section>> {{0, new List<Section>()}};
            _protobufSerializerMock.Setup(x => x.Read<Dictionary<int, IEnumerable<Section>>>(path)).Returns(pretendSections);

            var result = _plugin.Import(_testCardPath);
            foreach (var loggedData in result.Documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    var sections = operationData.GetSections(0);
                    Assert.NotNull(sections);
                }
            }
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenMetersAreImported()
        {
            var sectionPath = Path.Combine(_testCardPath, "adm", "documents", "Section-367.adm");
            var pretendSections = new Dictionary<int, IEnumerable<Section>> { { 0, new List<Section>() } };
            _protobufSerializerMock.Setup(x => x.Read<Dictionary<int, IEnumerable<Section>>>(sectionPath)).Returns(pretendSections);

            var meterPath = Path.Combine(_testCardPath, "adm", "documents", "Meter-367.adm");
            var pretendMeters = new List<Meter>();
            _protobufSerializerMock.Setup(x => x.Read<IEnumerable<Meter>>(meterPath)).Returns(pretendMeters);

            var result = _plugin.Import(_testCardPath);
            foreach (var loggedData in result.Documents.LoggedData)
            {
                foreach (var operationData in loggedData.OperationData)
                {
                    var sections = operationData.GetSections(0);
                    var meters = sections.SelectMany(x => x.GetMeters());
                    Assert.NotNull(meters);
                }
            }
        }

        [Test]
        public void GivenPluginAndCardPathWhenImportThenReferenceLayersAreImported()
        {
            var result = _plugin.Import(_testCardPath);
            Assert.IsNotEmpty(result.ReferenceLayers);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenProprietaryValuesFileIsWritten()
        {
            _testCardPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var dataModel = new ApplicationDataModel
            {
                ProprietaryValues = new List<ProprietaryValue>
                {
                    new ProprietaryValue(),
                    new ProprietaryValue(),
                    new ProprietaryValue()
                }
            };

            _plugin.Export(dataModel, _testCardPath);

            var fileExists = File.Exists(Path.Combine(_testCardPath, "adm", "ProprietaryValues.adm"));
            Assert.IsTrue(fileExists);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenCatalogFileIsWritten()
        {
            _testCardPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var dataModel = new ApplicationDataModel
            {
                Catalog = new Catalog
                {
                    Containers = new List<Container>(),
                    Farms = new List<Farm>(),
                    Machines = new List<Machine>()
                }
            };

            _plugin.Export(dataModel, _testCardPath);

            var fileExists = Path.Combine(_testCardPath, "adm", "Catalog.adm");
            _protobufSerializerMock.Verify(x => x.Write(fileExists, dataModel.Catalog), Times.Once);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenDocumentsFileIsWritten()
        {
            _testCardPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var dataModel = new ApplicationDataModel
            {
                Documents = new Documents
                {
                    LoggedData = new List<LoggedData>(),
                    //OperationData = new List<OperationData>(),
                    WorkItems = new List<WorkItem>()
                }
            };

            _plugin.Export(dataModel, _testCardPath);

            var fileExists = File.Exists(Path.Combine(_testCardPath, "adm", "Document.adm"));
            Assert.IsTrue(fileExists);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenOperationDataFileIsWritten()
        {
            var spatialRecords = new List<SpatialRecord>
            {
                new SpatialRecord(),
                new SpatialRecord(),
                new SpatialRecord()
            };

            var operationData = new OperationData
            {
                GetSpatialRecords = () => spatialRecords,
            };
            var dataModel = new ApplicationDataModel
            {
                Documents = new Documents
                {
                    LoggedData = new List<LoggedData>{ new LoggedData{ OperationData = new List<OperationData>{operationData}}},
                    WorkItems = new List<WorkItem>()
                }
            };

            _plugin.Export(dataModel, _testCardPath);
            var expectedPath = Path.Combine(_testCardPath,string.Format(@"adm\documents\OperationData{0}.adm", operationData.Id.ReferenceId));
            _protobufSerializerMock.Verify(x => x.WriteSpatialRecords(expectedPath, operationData.GetSpatialRecords()), Times.Once);
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenSectionFileIsWritten()
        {
            _testCardPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            var sections = new Dictionary<int, IEnumerable<Section>> {{0, new List<Section>()}};

            var operationData = new OperationData
            {
                GetSpatialRecords = () => new List<SpatialRecord>(),
                GetSections = x => sections[x]
            };
            var dataModel = new ApplicationDataModel
            {
                Documents = new Documents
                {
                    LoggedData = new List<LoggedData>{ new LoggedData{ OperationData = new List<OperationData>{operationData}}},
                    WorkItems = new List<WorkItem>()
                }
            };

            _plugin.Export(dataModel, _testCardPath);

            var fileName = String.Format("Section{0}.adm", operationData.Id.ReferenceId);
            var filePath = Path.Combine(_testCardPath, "adm", "documents", fileName);

            _protobufSerializerMock.Verify(x => x.Write(filePath, sections));
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenMeterFileIsWritten()
        {
            _testCardPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            var meters = new List<Meter>
            {
                new NumericMeter(),
                new NumericMeter()
            };
            var sections = new List<Section>
            {
                new Section
                {
                    GetMeters = () => meters
                }
            };

            var operationData = new OperationData
            {
                GetSpatialRecords = () => new List<SpatialRecord>(),
                GetSections = x => sections
            };

            var dataModel = new ApplicationDataModel
            {
                Documents = new Documents
                {
                    LoggedData = new List<LoggedData> { new LoggedData { OperationData = new List<OperationData> { operationData } } },
                    WorkItems = new List<WorkItem>()
                }
            };
            var fileName = String.Format("Meter{0}.adm", operationData.Id.ReferenceId);
            var filePath = Path.Combine(_testCardPath, "adm", "documents", fileName);


            _plugin.Export(dataModel, _testCardPath);

            _protobufSerializerMock.Verify(x => x.Write(filePath, sections.First().GetMeters()));
        }

        [Test]
        public void GivenPluginAndDataModelWhenExportThenReferenceLayersFileIsWritten()
        {
            _testCardPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            var dataModel = new ApplicationDataModel
            {
                ReferenceLayers = new List<ReferenceLayer>
                {
                    new RasterReferenceLayer(),
                    new ShapeReferenceLayer()
                }
            };

            _plugin.Export(dataModel, _testCardPath);

            var fileExists = File.Exists(Path.Combine(_testCardPath, "adm", "ReferenceLayers.adm"));
            Assert.IsTrue(fileExists);
        }

        [TearDown]
        public void Teardown()
        {
            Directory.Delete(_testCardPath, true);
        }
    }
}
