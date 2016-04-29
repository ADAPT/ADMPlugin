using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using NUnit.Framework;

namespace TestUtilities.ProtobufContract
{
    [TestFixture]
    public class ProtobufElementMapperTest
    {
        private ProtobufElementMapper _mapper;
        private string _tempFile;

        [SetUp]
        public void Setup()
        {
            _mapper = new ProtobufElementMapper();
            var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);
            _tempFile = Path.Combine(tempDirectory, "text.xml");
            File.WriteAllText(_tempFile, Resources.Resources.ProtobufMappingTest);
            _mapper.LoadXmlFile(_tempFile);
        }

        [Test]
        public void GivenXmlFileThatDoesNotExistWhenNewThenDocumentNotLoaded()
        {
            _mapper = new ProtobufElementMapper();
            var result=  _mapper.LoadXmlFile(@"..\..\NotAFile.xml");

            Assert.AreEqual(false, result);
        }

        [Test]
        public void GivenElementNameWhenMapThenIdIsCorrect()
        {
            var result = _mapper.Map("NumericRepresentation");
            Assert.AreEqual(108, result);
        }

        [Test]
        public void GivenElementThatIsNotMappedWhenMappedThenIdIsCreated()
        {
            var mappedIds = _mapper.GetListOfMappedIds();
            const string elementName = "NumericRepresentation100";
            var result = _mapper.Map(elementName);

            Assert.IsTrue(!mappedIds.Contains(result.ToString(CultureInfo.InvariantCulture)));
        }

        [Test]
        public void GivenElementThatIsNotMappedWhenMappedThenIsAddedToFile()
        {
            const string elementName = "NumericRepresentation100";
            var result = _mapper.Map(elementName);

            _mapper = new ProtobufElementMapper();
            _mapper.LoadXmlFile(_tempFile);
            var mappedNames = _mapper.GetListOfMappedNames();
            List<string> mappedIds = _mapper.GetListOfMappedIds();

            Assert.Contains(elementName, mappedNames);
            Assert.Contains(result.ToString(CultureInfo.InvariantCulture), mappedIds);
        }

        [TearDown]
        public void Teardown()
        {
            var tempfilepath = Path.GetDirectoryName(_tempFile);
            if(Directory.Exists(tempfilepath))
                Directory.Delete(tempfilepath, true);
        }
    }
}
