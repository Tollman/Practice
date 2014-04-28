using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Practice.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITypeService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ITypeService
    {
        [OperationContract]
        IEnumerable<CarType> GetAll();
        [OperationContract]
        int Add(CarType data);
        [OperationContract]
        CarType GetById(int id);
        [OperationContract]
        void Remove(CarType data);
        [OperationContract]
        void Update(CarType data);
    }
}
