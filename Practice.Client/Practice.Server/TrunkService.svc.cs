using Practice.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;

namespace Practice.Server
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
	public class TrunkService : ITrunkService
	{
		readonly ITrunkRepository repo;

		public TrunkService()
		{
			try
			{
				string typeStr1 = ConfigurationManager.AppSettings["trunkRepository"];
				Type type1 = Type.GetType(typeStr1);
				repo = (ITrunkRepository)Activator.CreateInstance(type1);

				repo.SourcePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_data/trunk.xml");
			}
			catch (Exception ex) { }
		}

		public IEnumerable<Trunk> GetAll()
		{
			return repo.GetAll();
		}

		public int Add(Trunk data)
		{
			if (data != null)
			{
				repo.Add(data);
				return data.Id;
			}

			throw new ArgumentNullException();
		}

		public Trunk GetById(int id)
		{
			return repo.GetById(id);
		}

		public void Remove(Trunk data)
		{
			repo.Remove(data);
		}

		public void Update(Trunk data)
		{
			repo.Update(data);
		}
	}
}
