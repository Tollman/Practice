using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice.Common
{
    class XmlTypeRepository : ITypeRepository
    {
                private XDocument xmlTrunks;
        private string fileName = "BD.xml";

		private int prevIndex = -1;

		public XmlTypeRepository()
		{
            xmlTrunks = new XDocument();
		}

		public IEnumerable<CarType> GetAll()
		{
			return (IEnumerable<CarType>) xmlTrunks;
		}

		public CarType GetById(int id)
		{
            string sId = id.ToString();
            return (CarType) xmlTrunks.Root.Descendants("Trunk").Where(t => t.Element("Id").Value == sId);
		}

		public void Add(CarType entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
            XElement trunk = new XElement("Trunk");
            XElement id = new XElement("Id",entity.Id);
            trunk.Add(id);
            XElement name = new XElement("Name", entity.Type);
            trunk.Add(name);
            //XElement address = new XElement("Address", entity.Address);
            //trunk.Add(address);
            xmlTrunks.Add(trunk);
            //xmlTrunks = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
            xmlTrunks.Save(fileName);
		}

		public void Remove(CarType entity)
		{
            xmlTrunks.Remove();
		}

		public void Update(CarType entity)
		{
            Console.WriteLine("))):)");
		}
    }
}
