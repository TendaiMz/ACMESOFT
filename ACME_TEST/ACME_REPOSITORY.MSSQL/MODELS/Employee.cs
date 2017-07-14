using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACME_REPOSITORY.MSSQL.MODELS
{
    [Table("Employee")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        [StringLength(16), Required]
        public string EmployeeNumber { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? TerminatedDate { get; set; }
        public Person Person { get; set; }
    }
}
