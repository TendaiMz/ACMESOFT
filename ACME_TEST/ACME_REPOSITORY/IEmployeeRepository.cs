using ACME_DOMAIN.CLASSES;
using System.Collections.Generic;

namespace ACME_REPOSITORY
{
    public interface IEmployeeRepository
    {
        void Update(EmployeeDTO entity);

        void Insert(EmployeeDTO entity);

        EmployeeDTO Find(int id);

        void Delete(int id);

        IEnumerable<EmployeeDTO> All();

    }
}



