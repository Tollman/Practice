using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice.Common
{
    class XmlCarRepository : ICarRepository
    {
        private XDocument xmlCars;
        private string fileName = "BDCar.xml";

		private int prevIndex = -1;

		public XmlCarRepository()
		{
            xmlCars = new XDocument(new XElement("CarsDB"));
  		}

		public IEnumerable<Car> GetAll()
		{
			return (IEnumerable<Car>) xmlCars;
		}

		public Car GetById(int id)
		{
            string sId = id.ToString();
            return (Car) xmlCars.Root.Descendants("Trunk").Where(t => t.Element("Id").Value == sId);
		}

		public void Add(Car entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
            XElement trunk = new XElement("Car");
            XElement id = new XElement("Id",entity.Id);
            trunk.Add(id);
            XElement name = new XElement("Name", entity.Cost);
            trunk.Add(name);
            XElement address = new XElement("Address", entity.Color);
            trunk.Add(address);
            xmlCars.Add(trunk);
            //xmlCars = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
            xmlCars.Save(fileName);
		}

		public void Remove(Car entity)
		{
            xmlCars.Remove();
		}

		public void Update(Car entity)
		{
            Console.WriteLine("))):)");
		}
    }
}
