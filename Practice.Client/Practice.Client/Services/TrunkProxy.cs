using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Client.Services
{
	internal class TrunkProxy : WcfProxy<ITrunkService>, ITrunkService
	{
		public TrunkProxy(string address)
			: base(address)
		{

		}

		public IEnumerable<Common.Trunk> GetAll()
		{
			return Channel.GetAll();
		}

		public int Add(Common.Trunk data)
		{
			return Channel.Add(data);
		}

		public Common.Trunk GetById(int id)
		{
			return Channel.GetById(id);
		}

		public void Remove(Common.Trunk data)
		{
			Channel.Remove(data);
		}

		public void Update(Common.Trunk data)
		{
			Channel.Update(data);
		}
	}
}
