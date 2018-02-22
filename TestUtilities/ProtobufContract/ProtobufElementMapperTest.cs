using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
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
            var resourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProtobufTestFiles");
            
            var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);
            _tempFile = Path.Combine(tempDirectory, "text.xml");
            File.WriteAllText(_tempFile, File.ReadAllText(Path.Combine(resourceDirectory, "ProtobufMappingTest.xml")));

            _mapper = new ProtobufElementMapper(_tempFile);
            if (!_mapper.IsMappingDocumentLoaded)
                _mapper = null;
        }

        [Test]
        public void GivenXmlFileThatDoesNotExistWhenNewThenDocumentNotLoaded()
        {
            _mapper = new ProtobufElementMapper(@"..\..\NotAFile.xml");

            Assert.AreEqual(false, _mapper.IsMappingDocumentLoaded);
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

            _mapper = new ProtobufElementMapper(_tempFile);
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
