using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Practice.Server
{
	public class CarService : ICarService
	{

		public IEnumerable<Trunk> GetAll()
		{
			throw new NotImplementedException();
		}

		public int Add(Trunk data)
		{
			throw new NotImplementedException();
		}

		public Trunk GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Remove(Trunk data)
		{
			throw new NotImplementedException();
		}

		public void Update(Trunk data)
		{
			throw new NotImplementedException();
		}
	}
}
