using System;
using System.IO;
using System.Linq;
using ADMPlugin;
using NUnit.Framework;
using TestUtilities;

namespace AcceptanceTest
{
    [TestFixture]
    public class PluginAcceptanceTest
    {
        private string _cardPath;
        
        [Test]
        public void GivenOlderVersionSetupCardWhenImportedToVersionWithChangedPropertyAndTypeNamesThenImportsToTheNewerModel()
        {
            _cardPath = DatacardUtility.WriteDataCard("adm_setup_v1_0_8");

            var plugin = new Plugin();
            var applicationDataModel = plugin.Import(_cardPath);

            Assert.IsNotNull(applicationDataModel);
        }

        [Test]
        public void GivenOlderVersionDocCardWhenImportedToVersionWithChangedPropertyAndTypeNamesThenImportsToTheNewerModel()
        {
            _cardPath = DatacardUtility.WriteDataCard("adm_doc_v1_0_8");

            var plugin = new Plugin();
            var applicationDataModel = plugin.Import(_cardPath);

            var id = applicationDataModel.First().Catalog.Connectors.First().DeviceElementConfigurationId;

            Assert.AreNotEqual(0, id);
        }

        [TearDown]
        public void Teardown()
        {
            try
            {
                Directory.Delete(Path.GetDirectoryName(_cardPath), true);
            }
            catch { }
        }
    }
}
