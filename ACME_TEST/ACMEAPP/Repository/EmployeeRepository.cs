using ACMEAPP.Models;
using ACMEAPP.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACMEAPP.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void CreateEmployee(EmployeeModel employee)
        {
            ACME_ServiceReference.EmployeeServiceClient client = new ACME_ServiceReference.EmployeeServiceClient();
            client.Create(ObjectMapper.MapToDTO(employee));
            client.Close();
        }

        public void DeleteEmployee(int id)
        {
            ACME_ServiceReference.EmployeeServiceClient client = new ACME_ServiceReference.EmployeeServiceClient();
            client.Delete(id);
            client.Close();
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            ACME_ServiceReference.EmployeeServiceClient client = new ACME_ServiceReference.EmployeeServiceClient();
            var employees = ObjectMapper.MapToModelList(client.GetAll().ToList());
            client.Close();
            return employees;            
        }

        public EmployeeModel GetEmployee(int id)
        {
            ACME_ServiceReference.EmployeeServiceClient client = new ACME_ServiceReference.EmployeeServiceClient();
            var employee =ObjectMapper.MapToModel(client.Get(id));           
            client.Close();
            return employee;
        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            ACME_ServiceReference.EmployeeServiceClient client = new ACME_ServiceReference.EmployeeServiceClient();
            client.Update(ObjectMapper.MapToDTO(employee));
            client.Close();
        }
    }
}




