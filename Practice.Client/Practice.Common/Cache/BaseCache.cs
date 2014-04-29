using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Common.Cache
{
	public class BaseCache<T> : ICache<T> where T : IEntity
	{
		Dictionary<int, T> container;
		int count;

		public BaseCache()
		{
			container = new Dictionary<int, T>();
		}

		public virtual void AddRange(IEnumerable<T> data)
		{
			foreach (var item in data)
			{
				if (container.ContainsKey(item.Id))
					container[item.Id] = item;
				else
				{
					container.Add(item.Id, item);
					System.Threading.Interlocked.Increment(ref count);
				}
			}
		}

		public void Add(T data)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAll()
		{
			return container.Values.AsEnumerable();
		}

		public T Get(int id)
		{
			throw new NotImplementedException();
		}

		public void Remove(T entity)
		{
			//thread safe
			throw new NotImplementedException();
		}

		public void Update(T entity)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return System.Threading.Interlocked.CompareExchange(ref count, 0, 0); }
		}
	}
}
