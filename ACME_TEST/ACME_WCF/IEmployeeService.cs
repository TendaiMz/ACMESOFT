using ACME_DOMAIN.CLASSES;
using System.Collections.Generic;
using System.ServiceModel;

namespace ACME_WCF
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        void Create(EmployeeDTO person);
        [OperationContract]
        void Update(EmployeeDTO person);
        [OperationContract]
        void Delete(EmployeeDTO person);
        [OperationContract]
        IEnumerable<EmployeeDTO> GetAll();
        [OperationContract]
        EmployeeDTO Get(int id);
    }
}

