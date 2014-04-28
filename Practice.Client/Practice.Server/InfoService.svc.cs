using Practice.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Practice.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InfoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InfoService.svc or InfoService.svc.cs at the Solution Explorer and start debugging.
    public class InfoService : IInfoService
    {
        readonly IInfoRepository repo;

		public InfoService()
		{
			try
			{
				string typeStr1 = ConfigurationManager.AppSettings["infoRepository"];
				Type type1 = Type.GetType(typeStr1);
				repo = (IInfoRepository)Activator.CreateInstance(type1);

				repo.SourcePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_data/info.xml");
			}
			catch (Exception ex) { }
		}

		public IEnumerable<DetailedInfo> GetAll()
		{
			return repo.GetAll();
		}

		public int Add(DetailedInfo data)
		{
			if (data != null)
			{
				repo.Add(data);
				return data.Id;
			}

			throw new ArgumentNullException();
		}

		public DetailedInfo GetById(int id)
		{
			return repo.GetById(id);
		}

		public void Remove(DetailedInfo data)
		{
			repo.Remove(data);
		}

		public void Update(DetailedInfo data)
		{
			repo.Update(data);
		}
    }
}
