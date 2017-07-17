namespace ACME_REPOSITORY.MSSQL.Migrations
{
    using MODELS;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ACME_REPOSITORY.MSSQL.ACMEContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ACME_REPOSITORY.MSSQL.ACMEContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            Employee employee1 = new Employee();
            Employee employee2 = new Employee();
            Employee employee3 = new Employee();
            Employee employee4 = new Employee();
            Employee employee5 = new Employee();

            employee1.Person = new Person()
            {
                BirthDate = DateTime.Parse("01/01/2000"),
                FirstName = "Tapiwa",
                LastName = "Mzondo",
            };
            employee1.EmployedDate = DateTime.Parse("01/01/17");
            employee1.EmployeeNumber = "AX100";
            employee1.EmployeeId = 1;

            employee2.Person = new Person()
            {
                BirthDate = DateTime.Parse("01/10/2004"),
                FirstName = "Lynne",
                LastName = "Bungu",
            };
            employee2.EmployedDate = DateTime.Parse("01/01/17");
            employee2.EmployeeNumber = "AX101";

            employee3.Person = new Person()
            {
                BirthDate = DateTime.Parse("01/04/2003"),
                FirstName = "Ethan",
                LastName = "Takosha",
            };
            employee3.EmployedDate = DateTime.Parse("01/01/17");
            employee3.EmployeeNumber = "AX102";

            employee4.Person = new Person()
            {
                BirthDate = DateTime.Parse("01/04/2003"),
                FirstName = "Kira",
                LastName = "Taps",
            };
            employee4.EmployedDate = DateTime.Parse("01/01/16");
            employee4.EmployeeNumber = "AX103";

            employee5.Person = new Person()
            {
                BirthDate = DateTime.Parse("01/04/2001"),
                FirstName = "Tapona",
                LastName = "Mzondo",
            };
            employee5.EmployedDate = DateTime.Parse("01/01/17");
            employee5.EmployeeNumber = "AX104";

            List<Employee> employees = new List<Employee>();
            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);
            employees.Add(employee4);
            employees.Add(employee5);

            foreach (var employee in employees)
            {
                context.Employee.AddOrUpdate(employee);               
            }
         
        }
    }
}
