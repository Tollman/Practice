using Practice.Common;
using System.Collections.Generic;
using System.ServiceModel;

namespace Practice.Common
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITrunkService" in both code and config file together.
	[ServiceContract(SessionMode = SessionMode.Allowed)]
	public interface ITrunkService
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
