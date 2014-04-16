﻿using System.Collections.Generic;

namespace Practice.Common
{
	public interface IRepository<T> where T : IEntity
	{
		IEnumerable<T> GetAll();

		T GetById(int id);

		void Add(T entity);
		void Remove(T entity);

		void Update(T entity);
	}

	public interface ITrunkRepository : IRepository<Trunk> { }
}
