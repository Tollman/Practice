using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common
{
    class InMemoryTypeRepository : ITypeRepository
    {
        private List<CarType> types;

		private int prevIndex = -1;

		public InMemoryTypeRepository()
		{
			types = new List<CarType>();
		}

		public IEnumerable<CarType> GetAll()
		{
			return types;
		}

		public CarType GetById(int id)
		{
			return types.FirstOrDefault(x => x.Id == id);
		}

		public void Add(CarType entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
			types.Add(entity);
		}

		public void Remove(CarType entity)
		{
			if (types.Contains(entity))
				types.Remove(entity);
		}

		public void Update(CarType entity)
		{
			CarType found = null;
			if (types.Contains(entity))
				found = types.FirstOrDefault(x => x.Id == entity.Id);

			if (found != null)
				found = entity;
		}
    }
}
