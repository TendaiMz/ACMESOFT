using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_REPOSITORY.MSSQL.MODELS
{
    [Table ("Person")]
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }
        [Required,StringLength(128)]
        public string LastName { get; set; }
        [Required, StringLength(128)]
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
