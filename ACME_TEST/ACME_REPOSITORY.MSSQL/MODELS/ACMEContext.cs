using ACME_REPOSITORY.MSSQL.MODELS;
using System.Data.Entity;

namespace ACME_REPOSITORY.MSSQL
{
    public class ACMEContext : DbContext
    {
        public ACMEContext() : base("name=acmeConnection")
        {

        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
