using System;
using System.IO;
using ADMPlugin;
using Newtonsoft.Json;
using NUnit.Framework;

namespace PluginTest
{
    [TestFixture]
    public class AdmVersionInfoWriterTest
    {
        private AdmVersionInfoWriter _admVersionInfoWriter;
        private string _tempPath;

        [SetUp]
        public void Setup()
        {
            _admVersionInfoWriter = new AdmVersionInfoWriter();

            _tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        }

        [Test]
        public void GivenFilenameWhenWriteFileThenFileExists()
        {
            var filename = Path.Combine(_tempPath, "AdmVersion.info");

            _admVersionInfoWriter.WriteVersionInfoFile(filename);

            Assert.That(File.Exists(filename), Is.True);
        }

        [Test]
        public void GivenFilenameWhenWriteThenFileContainsJsonAdmVersionInfo()
        {
            var filename = Path.Combine(_tempPath, "AdmVersion.info");
            
            _admVersionInfoWriter.WriteVersionInfoFile(filename);

            var stringVersionFile = File.ReadAllText(filename);
            var model = JsonConvert.DeserializeObject<AdmVersionInfoModel>(stringVersionFile);

            var expectedVersion = typeof (Plugin).Assembly.GetName().Version.ToString();

            Assert.That(model.AdmVersion, Is.EqualTo(expectedVersion));
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_tempPath))
            {
                Directory.Delete(_tempPath, true);
            }
        }
    }
}
