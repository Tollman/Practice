using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common
{
	public interface IEntity
	{
		int Id { get; set; }
	}

	public class Trunk:IEntity
	{

		public int Id
		{
			get;
			set;
		}

		public string Name { get; set; }

		public string Address { get; set; }

		public int CarCount { get; set; }

		public List<Car> Cars { get; set; }
	}


	public class Car : IEntity
	{
		
	}
}
