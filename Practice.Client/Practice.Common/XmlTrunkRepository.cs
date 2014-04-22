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
		private string fileName = "BD.xml";

		private int prevIndex = -1;

		public XmlTrunkRepository()
		{
			if (!System.IO.File.Exists(fileName))
			{
				xmlTrunks = new XDocument(new XElement("TrunksDB"));
				xmlTrunks.Save(fileName);
			}

			foreach (int item in GetSmth())
			{
				Console.WriteLine(item);
			}
		}

		public IEnumerable<int> GetSmth()
		{
			yield return 1;
			yield return 2;
		}


		public IEnumerable<Trunk> GetAll()
		{
			List<Trunk> trunks = new List<Trunk>();
			xmlTrunks = XDocument.Load(fileName);
			Trunk newTrunk = null;
			foreach (XElement el in xmlTrunks.Root.Elements())
			{
				newTrunk = new Trunk();
				newTrunk.Id = Convert.ToInt32(el.Element("Id").Value);
				newTrunk.Name = el.Element("Name").Value;
				newTrunk.Address = el.Element("Address").Value;
				trunks.Add(newTrunk);
			}
			return trunks;
		}

		public Trunk GetById(int id)
		{
			string sId = id.ToString();
			return (Trunk)xmlTrunks.Root.Descendants("Trunk").Where(t => t.Element("Id").Value == sId);
		}

		public void Add(Trunk entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
			XElement trunk = new XElement("Trunk");
			XElement id = new XElement("Id", entity.Id);
			trunk.Add(id);
			XElement name = new XElement("Name", entity.Name);
			trunk.Add(name);
			XElement address = new XElement("Address", entity.Address);
			trunk.Add(address);
			xmlTrunks.Root.Add(trunk);
			//xmlTrunks = new XDocument(new XElement("Trunk", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
			xmlTrunks.Save(fileName);
		}

		public void Remove(Trunk entity)
		{
			XElement element = xmlTrunks.Root.Descendants().FirstOrDefault(x => int.Parse(x.Element("Id").Value) == entity.Id);
			element.Remove();
			xmlTrunks.Save(fileName);
		}

		public void Update(Trunk entity)
		{
			XElement element= xmlTrunks.Root.Descendants().FirstOrDefault(x => int.Parse(x.Element("Id").Value) == entity.Id);
			element.Element("Name").Value = entity.Name;

			xmlTrunks.Save(fileName);
		}
	}
}
