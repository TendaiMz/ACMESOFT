using ACMEAPP.Models;
using System.Collections.Generic;

namespace ACMEAPP.Repository
{
    public interface IEmployeeRepository
    {
        void CreateEmployee(EmployeeModel employee);
        EmployeeModel GetEmployee(int id);
        IEnumerable<EmployeeModel> GetAllEmployees();
        void UpdateEmployee(EmployeeModel employee);
        void DeleteEmployee(EmployeeModel employee);
    }
}
