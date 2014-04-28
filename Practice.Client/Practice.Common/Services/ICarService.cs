using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace Practice.Common
{
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface ICarService
	{
		[OperationContract]
		IEnumerable<Car> GetAll();
		[OperationContract]
		int Add(Car data);
		[OperationContract]
		Car GetById(int id);
		[OperationContract]
		void Remove(Car data);
		[OperationContract]
		void Update(Car data);
	}
}
