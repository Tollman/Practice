using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common
{
	public class InMemoryTrunkRepository : ITrunkRepository
	{
		private List<Trunk> trunks;

		private int prevIndex = -1;

		public string SourcePath { get; set; }

		public InMemoryTrunkRepository()
		{
			trunks = new List<Trunk>();
		}

		public IEnumerable<Trunk> GetAll()
		{
			return trunks;
		}

		public Trunk GetById(int id)
		{
			return trunks.FirstOrDefault(x => x.Id == id);
		}

		public void Add(Trunk entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
			trunks.Add(entity);
		}

		public void Remove(Trunk entity)
		{
			if (trunks.Contains(entity))
				trunks.Remove(entity);
		}

		public void Update(Trunk entity)
		{
			Trunk found = null;
			if (trunks.Contains(entity))
				found = trunks.FirstOrDefault(x => x.Id == entity.Id);

			if (found != null)
				found = entity;
		}
	}
}
