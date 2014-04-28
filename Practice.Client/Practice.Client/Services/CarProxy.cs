using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Client.Services
{
    internal class CarProxy : WcfProxy<ICarService>, ICarService
    {
        public CarProxy(string address)
            : base(address)
        {

        }

        public IEnumerable<Common.Car> GetAll()
        {
            return Channel.GetAll();
        }

        public int Add(Common.Car data)
        {
            return Channel.Add(data);
        }

        public Common.Car GetById(int id)
        {
            return Channel.GetById(id);
        }

        public void Remove(Common.Car data)
        {
            Channel.Remove(data);
        }

        public void Update(Common.Car data)
        {
            Channel.Update(data);
        }
    }
}
