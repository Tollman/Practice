using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common
{
    class InMemoryInfoRepository : IInfoRepository
    {
        private List<DetailedInfo> infos;

		private int prevIndex = -1;

		public string SourcePath { get; set; }

		public InMemoryInfoRepository()
		{
			infos = new List<DetailedInfo>();
		}

		public IEnumerable<DetailedInfo> GetAll()
		{
			return infos;
		}

		public DetailedInfo GetById(int id)
		{
			return infos.FirstOrDefault(x => x.Id == id);
		}

		public void Add(DetailedInfo entity)
		{
			prevIndex++;
			entity.Id = prevIndex;
			infos.Add(entity);
		}

		public void Remove(DetailedInfo entity)
		{
			if (infos.Contains(entity))
				infos.Remove(entity);
		}

		public void Update(DetailedInfo entity)
		{
			DetailedInfo found = null;
			if (infos.Contains(entity))
				found = infos.FirstOrDefault(x => x.Id == entity.Id);

			if (found != null)
				found = entity;
		}
    }
}
