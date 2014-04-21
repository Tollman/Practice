﻿using System;
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
            xmlTrunks = new XDocument(new XElement("TrunksDB"));
            xmlTrunks.Save(fileName);
		}

		public IEnumerable<Trunk> GetAll()
		{
            Trunk newTrunk = new Trunk();
            List<Trunk> trunks = new List<Trunk>();
            XDocument doc = XDocument.Load(fileName);
            foreach (XElement el in doc.Root.Elements())
            {
                if (el.Name == "Name" || el.Name == "Address")
                {
                    newTrunk.Name = el.Value;
                    newTrunk.Address = el.Value;
                    trunks.Add(newTrunk);
                }
            }
			return trunks;
		}

		public Trunk GetById(int id)
		{
            string sId = id.ToString();
            return (Trunk) xmlTrunks.Root.Descendants("Trunk").Where(t => t.Element("Id").Value == sId);
		}

		public void Add(Trunk entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
            XElement trunk = new XElement("Trunk");
            XElement id = new XElement("Id",entity.Id);
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
            xmlTrunks.Remove();
		}

		public void Update(Trunk entity)
		{
            Console.WriteLine("))):)");
		}
    }
}
