using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice.Common
{
    class XmlTypeRepository : ITypeRepository
    {
        private XDocument xmlTypes;
        private string fileName = "TypeDB.xml";

		private int prevIndex = -1;

		public string SourcePath { get; set; }

		public XmlTypeRepository()
		{
            CheckSource();
		}

        private void CheckSource()
        {
            if (!System.IO.File.Exists(fileName))
            {
                xmlTypes = new XDocument(new XElement("TypesDB"));
                xmlTypes.Save(fileName);
            }
            else
            {
                xmlTypes = XDocument.Load(fileName);
                if (!xmlTypes.Root.IsEmpty) prevIndex = int.Parse(xmlTypes.Root.Descendants("CarType").Last().Element("Id").Value);
            }
        }

		public IEnumerable<CarType> GetAll()
		{
            CheckSource();
            List<CarType> types = new List<CarType>();
            xmlTypes = XDocument.Load(fileName);
            CarType newType = null;
            foreach (XElement el in xmlTypes.Root.Elements())
            {
                newType = new CarType();
                newType.Id = Convert.ToInt32(el.Element("Id").Value);
                newType.Type = el.Element("Type").Value;
                types.Add(newType);
            }
            return types;
		}

		public CarType GetById(int id)
		{
            CheckSource();
            CarType getType = new CarType();
            getType.Type = xmlTypes.Root.Descendants("Type").ElementAt<XElement>(id).Element("Type").Value;
            return getType;
		}

		public void Add(CarType entity)
		{
            CheckSource();
			prevIndex++;
			entity.Id = prevIndex;
            XElement carType = new XElement("CarType");
            XElement id = new XElement("Id",entity.Id);
            carType.Add(id);
            XElement type = new XElement("Type", entity.Type);
            carType.Add(type);
            xmlTypes.Root.Add(carType);
            //xmlTypes = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
            xmlTypes.Save(fileName);
		}

		public void Remove(CarType entity)
		{
            CheckSource();
            xmlTypes.Root.Descendants("Type").ElementAt<XElement>(entity.Id).Remove();
            xmlTypes.Save(fileName);
		}

		public void Update(CarType entity)
		{
            CheckSource();
            xmlTypes.Root.Descendants("CarType").ElementAt<XElement>(entity.Id).Element("Type").Value = entity.Type;
            xmlTypes.Save(fileName);
		}
    }
}
