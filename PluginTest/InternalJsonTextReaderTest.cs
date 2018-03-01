using System.IO;
using System.Text;
using ADMPlugin;
using NUnit.Framework;

namespace PluginTest
{
    [TestFixture]
    public class InternalJsonTextReaderTest
    {
        [Test]
        public void GivenChangedPropertyNameWhenResolvedGivesNewName()
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"DeviceConfigurationId\": 1245}")))
            {
                using (var streamReader = new StreamReader(memoryStream))
                {
                    using (var textReader = new InternalJsonTextReader(streamReader))
                    {
                        textReader.Read(); //the first value is null
                        textReader.Read(); 
                        var value = textReader.Value.ToString();

                        Assert.AreEqual("DeviceElementConfigurationId", value);
                    }
                }
            }
        }

        [Test]
        public void GivenUnChangedPropertyNameWhenResolvedGivesGivenName()
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("{\"ConfigurationId\": 1245}")))
            {
                using (var streamReader = new StreamReader(memoryStream))
                {
                    using (var textReader = new InternalJsonTextReader(streamReader))
                    {
                        textReader.Read(); //the first value is null
                        textReader.Read();
                        var value = textReader.Value.ToString();

                        Assert.AreEqual("ConfigurationId", value);
                    }
                }
            }
        }
    }
}