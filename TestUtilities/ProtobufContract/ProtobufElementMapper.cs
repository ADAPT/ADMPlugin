using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestUtilities.ProtobufContract
{
    public class ProtobufElementMapper
    {
        private XDocument _document;
        private string _filepath;

        public ProtobufElementMapper()
        {
            LoadXmlFile(@"..\..\Resources\ProtobufMapping.xml");
        }


        public bool LoadXmlFile(string filename)
        {
            if (!File.Exists(filename))
                return false;

            _filepath = filename;
            _document = XDocument.Load(filename);

            return true;
        }

        public int Map(string elementName)
        {
            var id = _document.Root.Descendants("MappedElement").Where(x => x.Element("Name").Value == elementName).Select(x => x.Element("Id").Value).FirstOrDefault();

            if (id != null)
                return Convert.ToInt16(id);

            int nextId = GetNextId();
            AddMappedElement(elementName, nextId);

            return nextId;
        }

        public List<string> GetListOfMappedNames()
        {
            var listOfNames = _document.Root.Descendants("MappedElement").Select(x => x.Element("Name").Value);
            return listOfNames.ToList();
        }

        public List<string> GetListOfMappedIds()
        {
            var listOfIds = _document.Root.Descendants("MappedElement").Select(x => x.Element("Id").Value);
            return listOfIds.ToList();
        }

        private void AddMappedElement(string elementName, int nextId)
        {
            var element = new XElement("MappedElement", new XElement("Name", elementName), new XElement("Id", nextId));
            _document.Root.Add(element);

            _document.Save(_filepath);
        }

        private int GetNextId()
        {
            var ids = _document.Root.Descendants("MappedElement").Select(x => x.Element("Id").Value);
            var nextId = Convert.ToInt16(ids.Max(x => x)) + 1;

            while (ids.SingleOrDefault(x => Convert.ToInt16(x) == nextId) != null)
            {
                nextId++;
            }

            return nextId;
        }
    }
}
