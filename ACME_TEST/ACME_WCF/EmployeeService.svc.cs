using ACME_DOMAIN.CLASSES;
using ACME_REPOSITORY;
using ACME_REPOSITORY.MSSQL.MODELS;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace ACME_WCF.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmployeeService.svc or EmployeeService.svc.cs at the Solution Explorer and start debugging.
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public void Create(EmployeeDTO employeeDTO)
        {
            _repo.Insert(employeeDTO);
        }

        public void Delete(EmployeeDTO employeeDTO)
        {
            _repo.Delete(employeeDTO);
        }

        public void Update(EmployeeDTO employeeDTO)
        {
            _repo.Update(employeeDTO);
        }

        public EmployeeDTO Get(int id)
        {
            return _repo.Find(id);

        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
          return _repo.All();
        }


        private Employee MapToEntity(EmployeeDTO employeeDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<PersonDTO, Person>();
            });

            IMapper mapper = config.CreateMapper();
            var source = employeeDTO;
            var _employee = mapper.Map<EmployeeDTO, Employee>(source);
            return _employee;
        }
        public EmployeeDTO MapToDTO(Employee employee)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<Person, PersonDTO>();

            });

            IMapper mapper = config.CreateMapper();
            var source = employee;
            var _employeeDTO = mapper.Map<Employee, EmployeeDTO>(source);
            return _employeeDTO;
        }

        private IEnumerable<EmployeeDTO> MapToDTOList(List<Employee> employees)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<Person, PersonDTO>();               

            });

            IMapper mapper = config.CreateMapper();
            var source = employees;
            var _employeesDTO = mapper.Map<List<Employee>, List<EmployeeDTO>>(source);
            return _employeesDTO;
        }

    }
}
