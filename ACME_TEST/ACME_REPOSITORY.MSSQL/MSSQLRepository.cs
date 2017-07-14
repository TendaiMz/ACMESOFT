using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ACME_DOMAIN.CLASSES;
using AutoMapper;
using ACME_REPOSITORY.MSSQL.MODELS;

namespace ACME_REPOSITORY.MSSQL
{
    /// <summary>
    /// Perfoms Create,Read,Update and Delete operations based on the specified entity using the Entityframework
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MSSQLRepository : IEmployeeRepository
    {
       
        private ACMEContext _context;

        public MSSQLRepository(ACMEContext context)
        {
            _context = context;           
        }
        public IEnumerable<EmployeeDTO> All()
        {

            return MapToDTOList(_context.Employee.Include(x => x.Person).ToList());
        }

        public void Delete(EmployeeDTO employee)
        {
            var empl = _context.Employee.Include(x => x.Person).First(y => y.EmployeeId == employee.EmployeeId);
            _context.Employee.Remove(empl);
            _context.SaveChanges();
        }


        public EmployeeDTO Find(int id)
        {
            return MapToDTO(_context.Employee.Include(x => x.Person).First(y => y.EmployeeId == id));
        }

        public void Insert(EmployeeDTO employee)
        {
            _context.Employee.Add(MapToEntity(employee));           
            _context.SaveChanges();
        }

        public void Update(EmployeeDTO employee)
        {
            _context.Employee.Attach(MapToEntity(employee));
            _context.Entry(MapToEntity(employee)).State = EntityState.Modified;
            //_context.Person.Attach(MapToEntity(employee.Person));
            //_context.Entry(MapToEntity(employee.Person)).State = EntityState.Modified;
            _context.SaveChanges();
        }

        private Person MapToEntity(PersonDTO personDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, Person>();
            });

            IMapper mapper = config.CreateMapper();
            var source = personDTO;
            var _person = mapper.Map<PersonDTO, Person>(source);
            return _person;
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
