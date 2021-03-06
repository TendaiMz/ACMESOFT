﻿using ACME_DOMAIN.CLASSES;
using ACME_WCF.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACME_REPOSITORY.Tests
{
    [TestClass]
    public class EmployeeServiceTest
    {

        EmployeeDTO SetUpEmployeeDTO()
        {
            EmployeeDTO employeeDto = new EmployeeDTO();
            employeeDto.EmployedDate = DateTime.Parse("01/01/17");
            employeeDto.EmployeeNumber = "AX100";
            employeeDto.EmployeeId = 1;
            return employeeDto;
        }


        [TestMethod]
        public void Create_Employee_Should_Verify_EmployeeNumber()
        {



            Mock<IEmployeeRepository> mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.Insert(SetUpEmployeeDTO()));
            EmployeeService employeeService = new EmployeeService(mockRepo.Object);
            employeeService.Create(SetUpEmployeeDTO());
            mockRepo.Verify(x => x.Insert(It.Is<EmployeeDTO>(t => t.EmployeeNumber == "AX100")));
        }

        [TestMethod]
        public void Update_Person_Should_Verify_EmployeeId()
        {

            Mock<IEmployeeRepository> mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.Update(SetUpEmployeeDTO()));
            EmployeeService employeeService = new EmployeeService(mockRepo.Object);
            employeeService.Update(SetUpEmployeeDTO());
            mockRepo.Verify(x => x.Update(It.Is<EmployeeDTO>(t => t.EmployeeId == 1)));

        }
        [TestMethod]
        public void Delete_Should_Verify_That_It_Called()
        {
            Mock<IEmployeeRepository> mockRepo = new Mock<IEmployeeRepository>();
            EmployeeService employeeService = new EmployeeService(mockRepo.Object);
            employeeService.Delete(SetUpEmployeeDTO().EmployeeId);
            mockRepo.Verify(x => x.Delete(SetUpEmployeeDTO().EmployeeId));

        }

        [TestMethod]
        public void GetAll_Should_Return_Total_Number_Of_Items()
        {
            EmployeeDTO employee1 = new EmployeeDTO();
            EmployeeDTO employee2 = new EmployeeDTO();
            EmployeeDTO employee3 = new EmployeeDTO();

            employee1.Person = new PersonDTO()
            {
                BirthDate = DateTime.Parse("01/01/2000"),
                FirstName = "Tendai",
                LastName = "Mzondo",
            };
            employee1.EmployedDate = DateTime.Parse("01/01/17");
            employee1.EmployeeNumber = "AX100";
            employee1.EmployeeId = 1;

            employee2.Person = new PersonDTO()
            {
                BirthDate = DateTime.Parse("01/10/2004"),
                FirstName = "Meme",
                LastName = "Bungu",
            };
            employee2.EmployedDate = DateTime.Parse("01/01/17");
            employee2.EmployeeNumber = "AX102";

            employee3.Person = new PersonDTO()
            {
                BirthDate = DateTime.Parse("01/04/2003"),
                FirstName = "Ethan",
                LastName = "Takosha",
            };
            employee3.EmployedDate = DateTime.Parse("01/01/17");
            employee3.EmployeeNumber = "AX102";

            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);

            Mock<IEmployeeRepository> mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.All()).Returns(employees);
            EmployeeService employeeService = new EmployeeService(mockRepo.Object);
            employeeService.GetAll().Count().Should().Be(3);
        }

        [TestMethod]
        public void Get_Should_Not_Return_The_Correct_EmployeeId()
        {
            Mock<IEmployeeRepository> mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(x => x.Find(1)).Returns(SetUpEmployeeDTO());
            EmployeeService employeeService = new EmployeeService(mockRepo.Object);
            employeeService.Get(1).EmployeeId.Should().Be(1);
        }
    }
}
