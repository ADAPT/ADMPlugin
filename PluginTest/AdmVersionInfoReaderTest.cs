using System;
using System.IO;
using AgGateway.ADAPT.ADMPlugin;
using Newtonsoft.Json;
using NUnit.Framework;

namespace AgGateway.ADAPT.PluginTest
{
    [TestFixture]
    public class AdmVersionInfoReaderTest
    {
        private AdmVersionInfoReader _reader;
        private string _tempPath;

        private const string AdmVersionFilename = "AdmVersion.info";

        [SetUp]
        public void Setup()
        {
            _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempPath);

            _reader = new AdmVersionInfoReader();
        }

        [Test]
        public void GivenFilenameWhenReadThenModel()
        {
            var versionInfoModel = new AdmVersionInfoModel {AdmVersion = "1.2.3.4"};
            var versionInfoModelString = JsonConvert.SerializeObject(versionInfoModel);

            var filename = Path.Combine(_tempPath, AdmVersionFilename);
            File.WriteAllText(filename, versionInfoModelString);

            var model = _reader.ReadVersionInfoModel(filename);

            Assert.That(model.AdmVersion, Is.EqualTo("1.2.3.4"));
        }

        [Test]
        public void GivenFilenameThatDoesNotExistWhenReadThenNull()
        {
            var filename = Path.Combine(_tempPath, AdmVersionFilename);

            var model = _reader.ReadVersionInfoModel(filename);

            Assert.That(model, Is.Null);
        }

        [TearDown]
        public void Teardown()
        {
            if (Directory.Exists(_tempPath))
            {
                Directory.Delete(_tempPath, true);
            }
        }
    }
}
