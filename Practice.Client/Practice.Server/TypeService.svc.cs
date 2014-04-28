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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TypeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TypeService.svc or TypeService.svc.cs at the Solution Explorer and start debugging.
    public class TypeService : ITypeService
    {
        readonly ITypeRepository repo;

        public TypeService()
        {
            try
            {
                string typeStr1 = ConfigurationManager.AppSettings["typeRepository"];
                Type type1 = Type.GetType(typeStr1);
                repo = (ITypeRepository)Activator.CreateInstance(type1);

                repo.SourcePath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_data/type.xml");
            }
            catch (Exception ex) { }
        }

        public IEnumerable<CarType> GetAll()
        {
            return repo.GetAll();
        }

        public int Add(CarType data)
        {
            if (data != null)
            {
                repo.Add(data);
                return data.Id;
            }

            throw new ArgumentNullException();
        }

        public CarType GetById(int id)
        {
            return repo.GetById(id);
        }

        public void Remove(CarType data)
        {
            repo.Remove(data);
        }

        public void Update(CarType data)
        {
            repo.Update(data);
        }
    }
}
