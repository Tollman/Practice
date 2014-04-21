using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice.Common
{
    class XmlCarRepository : ICarRepository
    {
        private XDocument xmlTrunks;
        private string fileName = "BD.xml";

		private int prevIndex = -1;

		public XmlCarRepository()
		{
            xmlTrunks = new XDocument();
		}

		public IEnumerable<Car> GetAll()
		{
			return (IEnumerable<Car>) xmlTrunks;
		}

		public Car GetById(int id)
		{
            string sId = id.ToString();
            return (Car) xmlTrunks.Root.Descendants("Trunk").Where(t => t.Element("Id").Value == sId);
		}

		public void Add(Car entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
            XElement trunk = new XElement("Trunk");
            XElement id = new XElement("Id",entity.Id);
            trunk.Add(id);
            XElement name = new XElement("Name", entity.Cost);
            trunk.Add(name);
            XElement address = new XElement("Address", entity.Color);
            trunk.Add(address);
            xmlTrunks.Add(trunk);
            //xmlTrunks = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
            xmlTrunks.Save(fileName);
		}

		public void Remove(Car entity)
		{
            xmlTrunks.Remove();
		}

		public void Update(Car entity)
		{
            Console.WriteLine("))):)");
		}
    }
}
