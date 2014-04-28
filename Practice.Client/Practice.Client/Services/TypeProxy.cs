using Practice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Client.Services
{
    internal class TypeProxy : WcfProxy<ITypeService>, ITypeService
    {
        public TypeProxy(string address) : base(address)
        {
        
        }

        public IEnumerable<Common.CarType> GetAll()
        {
            return Channel.GetAll();
        }

        public int Add(Common.CarType data)
        {
            return Channel.Add(data);
        }

        public Common.CarType GetById(int id)
        {
            return Channel.GetById(id);
        }

        public void Remove(Common.CarType data)
        {
            Channel.Remove(data);
        }

        public void Update(Common.CarType data)
        {
            Channel.Update(data);
        }
    }
}
