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
		IEnumerable<Trunk> GetAll();
		[OperationContract]
		int Add(Trunk data);
		[OperationContract]
		Trunk GetById(int id);
		[OperationContract]
		void Remove(Trunk data);
		[OperationContract]
		void Update(Trunk data);
	}
}
