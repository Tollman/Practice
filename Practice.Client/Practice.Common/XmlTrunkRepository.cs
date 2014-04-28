using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Practice.Common
{
	class XmlTrunkRepository : ITrunkRepository
	{
		private XDocument xmlTrunks;

		private int prevIndex = -1;

		public string SourcePath { get; set; }

		public XmlTrunkRepository()
		{
            CheckSource();
		}

		private void CheckSource()
		{
			if (!string.IsNullOrEmpty(SourcePath))
			{
				if (!System.IO.File.Exists(SourcePath))
				{
					xmlTrunks = new XDocument(new XElement("TrunksDB"));
					xmlTrunks.Save(SourcePath);
				}
				else
				{
					xmlTrunks = XDocument.Load(SourcePath);
					if (!xmlTrunks.Root.IsEmpty) prevIndex = int.Parse(xmlTrunks.Root.Descendants("Trunk").Last().Element("Id").Value);
				}
			}
		}

		public IEnumerable<Trunk> GetAll()
		{
			CheckSource();
			List<Trunk> trunks = new List<Trunk>();
			xmlTrunks = XDocument.Load(SourcePath);
			Trunk newTrunk = null;
			foreach (XElement el in xmlTrunks.Root.Elements())
			{
				newTrunk = new Trunk();
				newTrunk.Id = Convert.ToInt32(el.Element("Id").Value);
				newTrunk.Name = el.Element("Name").Value;
				newTrunk.Address = el.Element("Address").Value;
				newTrunk.CarCount = int.Parse(el.Element("CarCount").Value);
				newTrunk.Cars = new List<Car>();
				trunks.Add(newTrunk);
			}
			return trunks;
		}

		public Trunk GetById(int id)
		{
			CheckSource();
			Trunk getTrunk = new Trunk();
			XElement element = xmlTrunks.Root.Descendants("Trunk").ElementAt<XElement>(id);
			getTrunk.Name = element.Element("Name").Value;
			getTrunk.Address = element.Element("Address").Value;
			getTrunk.CarCount = int.Parse(element.Element("CarCount").Value);
			return getTrunk;
		}

		public void Add(Trunk entity)
		{
			CheckSource();
			prevIndex++;
			entity.Id = prevIndex;
			XElement trunk = new XElement("Trunk");
			XElement id = new XElement("Id", entity.Id);
			trunk.Add(id);
			XElement name = new XElement("Name", entity.Name);
			trunk.Add(name);
			XElement address = new XElement("Address", entity.Address);
			trunk.Add(address);
			XElement carCount = new XElement("CarCount", entity.CarCount);
			trunk.Add(carCount);
			xmlTrunks.Root.Add(trunk);
			//xmlTrunks = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
			xmlTrunks.Save(SourcePath);
		}

		public void Remove(Trunk entity)
		{
			CheckSource();
			xmlTrunks.Root.Descendants("Trunk").ElementAt<XElement>(entity.Id).Remove();
			xmlTrunks.Save(SourcePath);
		}

		public void Update(Trunk entity)
		{
			CheckSource();
			XElement element = xmlTrunks.Root.Descendants("Trunk").ElementAt<XElement>(entity.Id);
			element.Element("Name").Value = entity.Name;
			element.Element("Address").Value = entity.Address;
			element.Element("CarCount").Value = entity.CarCount.ToString();
			xmlTrunks.Save(SourcePath);
		}
	}
}
