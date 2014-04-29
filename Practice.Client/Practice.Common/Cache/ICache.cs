using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common.Cache
{
	public interface ICache<T> where T : IEntity
	{
		int Count { get; }

		IEnumerable<T> GetAll();

		void AddRange(IEnumerable<T> data);
		void Add(T data);

		T Get(int id);

		void Remove(T entity);

		void Update(T entity);
	}
}
