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
        private string fileName = "CarDB.xml";

		private int prevIndex = -1;

		public XmlCarRepository()
		{
            if (!System.IO.File.Exists(fileName))
            {
                xmlCars = new XDocument(new XElement("CarsDB"));
                xmlCars.Save(fileName);
            }
            else
            {
                xmlCars = XDocument.Load(fileName);
                if (!xmlCars.Root.IsEmpty) prevIndex = int.Parse(xmlCars.Root.Descendants("Car").Last().Element("Id").Value);
            }
  		}

		public IEnumerable<Car> GetAll()
		{
            List<Car> cars = new List<Car>();
            xmlCars = XDocument.Load(fileName);
            Car newCar = null;
            foreach (XElement el in xmlCars.Root.Elements())
            {
                newCar = new Car();
                newCar.Id = Convert.ToInt32(el.Element("Id").Value);
                newCar.Cost = float.Parse(el.Element("Cost").Value);
                newCar.Color = el.Element("Color").Value;
                newCar.Mark = el.Element("Mark").Value;
                newCar.TrunkId = int.Parse(el.Element("TrunkId").Value);
                cars.Add(newCar);
            }
            return cars;
		}

		public Car GetById(int id)
		{
            Car getCar = new Car();
            XElement element = xmlCars.Root.Descendants("Car").ElementAt<XElement>(id);
            getCar.Cost = float.Parse(element.Element("Cost").Value);
            getCar.Color = element.Element("Color").Value;
            getCar.Mark = element.Element("Mark").Value;
            getCar.TrunkId = int.Parse(element.Element("TrunkId").Value);
            return getCar;
		}

		public void Add(Car entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
            XElement car = new XElement("Car");
            XElement id = new XElement("Id",entity.Id);
            car.Add(id);
            XElement cost = new XElement("Cost", entity.Cost);
            car.Add(cost);
            XElement color = new XElement("Color", entity.Color);
            car.Add(color);
            XElement mark = new XElement("Mark", entity.Mark);
            car.Add(mark);
            XElement trunkId = new XElement("TrunkId", entity.TrunkId);
            car.Add(trunkId);
            xmlCars.Root.Add(car);
            //xmlCars = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
            xmlCars.Save(fileName);
		}

		public void Remove(Car entity)
		{
            xmlCars.Root.Descendants("Car").ElementAt<XElement>(entity.Id).Remove();
            xmlCars.Save(fileName);
		}

		public void Update(Car entity)
		{
            XElement element = xmlCars.Root.Descendants("Car").ElementAt<XElement>(entity.Id);
            element.Element("Cost").Value = entity.Cost.ToString();
            element.Element("Color").Value = entity.Color;
            element.Element("Mark").Value = entity.Mark;
            element.Element("TrunkId").Value = entity.TrunkId.ToString();
            xmlCars.Save(fileName);
		}
    }
}
