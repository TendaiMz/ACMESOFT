using ACMEAPP.ACME_ServiceReference;
using ACMEAPP.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACMEAPP.Utilities
{
    public static class ObjectMapper
    {
        //private Person MapToEntity(PersonDTO personDTO)
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<PersonDTO, Person>();
        //    });

        //    IMapper mapper = config.CreateMapper();
        //    var source = personDTO;
        //    var _person = mapper.Map<PersonDTO, Person>(source);
        //    return _person;
        //}

        public static EmployeeModel MapToModel(EmployeeDTO employeeDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, EmployeeModel>();
                cfg.CreateMap<PersonDTO, PersonModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = employeeDTO;
            var _employee = mapper.Map<EmployeeDTO, EmployeeModel>(source);
            return _employee;
        }
        public static EmployeeDTO MapToDTO(EmployeeModel employee)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeModel, EmployeeDTO>();
                cfg.CreateMap<PersonModel, PersonDTO>();

            });

            IMapper mapper = config.CreateMapper();
            var source = employee;
            var _employeeDTO = mapper.Map<EmployeeModel, EmployeeDTO>(source);
            return _employeeDTO;
        }

        public static IEnumerable<EmployeeModel> MapToModelList(List<EmployeeDTO> employees)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap< EmployeeDTO,EmployeeModel>();
                cfg.CreateMap<PersonDTO,PersonModel>();

            });

            IMapper mapper = config.CreateMapper();
            var source = employees;
            var _employeesModel = mapper.Map<List<EmployeeDTO>, List<EmployeeModel>>(source);
            return _employeesModel;
        }
    }
}