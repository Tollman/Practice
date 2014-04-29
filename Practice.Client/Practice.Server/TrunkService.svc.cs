using Practice.Common;
using Practice.Common.Cache;
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
		readonly ICache<Trunk> _cahce;

		public TrunkService()
		{
			try
			{
				_cahce = new TrunkCache();

				string typeStr1 = ConfigurationManager.AppSettings["trunkRepository"];
				Type type1 = Type.GetType(typeStr1);
				repo = (ITrunkRepository)Activator.CreateInstance(type1);

				repo.SourcePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_data/trunk.xml");
			}
			catch (Exception ex) { }
		}

		public IEnumerable<Trunk> GetAll()
		{
			if (_cahce.Count == 0)
				_cahce.AddRange(repo.GetAll());

			return _cahce.GetAll();
		}

		public int Add(Trunk data)
		{
			if (data != null)
			{
				repo.Add(data);
				// add to cache
				return data.Id;
			}

			throw new ArgumentNullException();
		}

		public Trunk GetById(int id)
		{
			//check cache 
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
