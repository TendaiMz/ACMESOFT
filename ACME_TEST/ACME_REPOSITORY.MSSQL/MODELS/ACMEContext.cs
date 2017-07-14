using ACME_REPOSITORY.MSSQL.MODELS;
using System.Data.Entity;

namespace ACME_REPOSITORY.MSSQL
{
    public class ACMEContext : DbContext
    {
        public ACMEContext() : base("name=acmeConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Map entity to table 
            //modelBuilder.Entity<Employee>().Map(sd => { sd.Properties(p => new { p.ID, p.FirstMidName, p.LastName });
            //    sd.ToTable("Person"); })
            //    .Map(si => { si.Properties(p => new { p.ID, p.EnrollmentDate });
            //        si.ToTable("Employee"); });
        }


        public DbSet<Employee> Employee { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}
