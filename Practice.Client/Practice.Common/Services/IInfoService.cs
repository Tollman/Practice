using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Practice.Common
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInfoService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IInfoService
    {
        [OperationContract]
        IEnumerable<DetailedInfo> GetAll();
        [OperationContract]
        int Add(DetailedInfo data);
        [OperationContract]
        DetailedInfo GetById(int id);
        [OperationContract]
        void Remove(DetailedInfo data);
        [OperationContract]
        void Update(DetailedInfo data);
    }
}
