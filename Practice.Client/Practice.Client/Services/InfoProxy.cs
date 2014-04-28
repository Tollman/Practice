using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Client.Services
{
    internal class InfoProxy : WcfProxy<IInfoService>, IInfoService
    {
        public InfoProxy(string address)
            : base(address)
        {

        }

        public IEnumerable<Common.DetailedInfo> GetAll()
        {
            return Channel.GetAll();
        }

        public int Add(Common.DetailedInfo data)
        {
            return Channel.Add(data);
        }

        public Common.DetailedInfo GetById(int id)
        {
            return Channel.GetById(id);
        }

        public void Remove(Common.DetailedInfo data)
        {
            Channel.Remove(data);
        }

        public void Update(Common.DetailedInfo data)
        {
            Channel.Update(data);
        }
    }
}
