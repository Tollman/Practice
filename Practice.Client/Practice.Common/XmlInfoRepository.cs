using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice.Common
{
    class XmlInfoRepository : IInfoRepository
    {
                private XDocument xmlTrunks;
        private string fileName = "BD.xml";

		private int prevIndex = -1;

		public XmlInfoRepository()
		{
            xmlTrunks = new XDocument();
		}

		public IEnumerable<DetailedInfo> GetAll()
		{
			return (IEnumerable<DetailedInfo>) xmlTrunks;
		}

		public DetailedInfo GetById(int id)
		{
            string sId = id.ToString();
            return (DetailedInfo) xmlTrunks.Root.Descendants("Trunk").Where(t => t.Element("Id").Value == sId);
		}

		public void Add(DetailedInfo entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
            XElement trunk = new XElement("Trunk");
            XElement id = new XElement("Id",entity.Id);
            trunk.Add(id);
            XElement name = new XElement("Name", entity.GearType);
            trunk.Add(name);
            XElement address = new XElement("Address", entity.Motor);
            trunk.Add(address);
            xmlTrunks.Add(trunk);
            //xmlTrunks = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
            xmlTrunks.Save(fileName);
		}

		public void Remove(DetailedInfo entity)
		{
            xmlTrunks.Remove();
		}

		public void Update(DetailedInfo entity)
		{
            Console.WriteLine("))):)");
		}
    }
}
