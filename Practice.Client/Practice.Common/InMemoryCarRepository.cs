using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common
{
    class InMemoryCarRepository : ICarRepository
    {
        private List<Car> cars;

		private int prevIndex = -1;

		public string SourcePath { get; set; }

		public InMemoryCarRepository()
		{
			cars = new List<Car>();
		}

		public IEnumerable<Car> GetAll()
		{
			return cars;
		}

		public Car GetById(int id)
		{
			return cars.FirstOrDefault(x => x.Id == id);
		}

		public void Add(Car entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
			cars.Add(entity);
		}

		public void Remove(Car entity)
		{
			if (cars.Contains(entity))
				cars.Remove(entity);
		}

		public void Update(Car entity)
		{
			Car found = null;
			if (cars.Contains(entity))
				found = cars.FirstOrDefault(x => x.Id == entity.Id);

			if (found != null)
				found = entity;
		}
    }
}
