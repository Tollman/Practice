using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Practice.Common
{
	class XmlInfoRepository : IInfoRepository
	{
		private XDocument xmlInfos;
		private string fileName = "DetailedInfoDB.xml";

		private int prevIndex = -1;
		public string SourcePath { get; set; }

		public XmlInfoRepository()
		{
			if (!System.IO.File.Exists(fileName))
			{
				xmlInfos = new XDocument(new XElement("InfosDB"));
				xmlInfos.Save(fileName);
			}
			else
			{
				xmlInfos = XDocument.Load(fileName);
				if (!xmlInfos.Root.IsEmpty) 
					prevIndex = int.Parse(xmlInfos.Root.Descendants("Info").Last().Element("Id").Value);
			}
		}

		public IEnumerable<DetailedInfo> GetAll()
		{
			List<DetailedInfo> infos = new List<DetailedInfo>();
			xmlInfos = XDocument.Load(fileName);
			DetailedInfo newInfo = null;
			foreach (XElement el in xmlInfos.Root.Elements())
			{
				newInfo = new DetailedInfo();
				newInfo.Id = Convert.ToInt32(el.Element("Id").Value);
				newInfo.GearType = el.Element("GearType").Value;
				newInfo.Motor = int.Parse(el.Element("Motor").Value);
				infos.Add(newInfo);
			}
			return infos;
		}

		public DetailedInfo GetById(int id)
		{
			DetailedInfo getInfo = new DetailedInfo();
			XElement element = xmlInfos.Root.Descendants("Info").ElementAt<XElement>(id);
			getInfo.GearType = element.Element("GearType").Value;
			getInfo.Motor = int.Parse(element.Element("Motor").Value);
			return getInfo;
		}

		public void Add(DetailedInfo entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
			XElement info = new XElement("Info");
			XElement id = new XElement("Id", entity.Id);
			info.Add(id);
			XElement gearType = new XElement("GearType", entity.GearType);
			info.Add(gearType);
			XElement Motor = new XElement("Motor", entity.Motor);
			info.Add(Motor);
			xmlInfos.Root.Add(info);
			//xmlInfos = new XDocument(new XElement("Info", new XElement("Id", entity.Id), new XElement("Name", entity.Name), new XElement("Address", entity.Address)));
			xmlInfos.Save(fileName);
		}

		public void Remove(DetailedInfo entity)
		{
			xmlInfos.Root.Descendants("Info").ElementAt<XElement>(entity.Id).Remove();
			xmlInfos.Save(fileName);
		}

		public void Update(DetailedInfo entity)
		{
			XElement element = xmlInfos.Root.Descendants("Info").ElementAt<XElement>(entity.Id);
			element.Element("GearType").Value = entity.GearType;
			element.Element("Motor").Value = entity.Motor.ToString();
			xmlInfos.Save(fileName);
		}
	}
}
