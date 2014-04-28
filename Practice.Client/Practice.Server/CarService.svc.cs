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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
	public class CarService : ICarService
	{
        readonly ICarRepository repo;

        public CarService() 
        {
            try
            {
                string typeStr1 = ConfigurationManager.AppSettings["carRepository"];
                Type type1 = Type.GetType(typeStr1);
                repo = (ICarRepository)Activator.CreateInstance(type1);

                repo.SourcePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_data/car.xml");
            }
            catch (Exception ex) { }
        }

		public IEnumerable<Car> GetAll()
		{
            return repo.GetAll();
		}

		public int Add(Car data)
		{
            if (data != null)
            {
                repo.Add(data);
                return data.Id;
            }

            throw new ArgumentNullException();
		}

		public Car GetById(int id)
		{
            return repo.GetById(id);
		}

		public void Remove(Car data)
		{
            repo.Remove(data);
		}

		public void Update(Car data)
		{
            repo.Update(data);
		}
	}
}
