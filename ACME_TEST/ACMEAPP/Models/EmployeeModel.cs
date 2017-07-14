using System;
using System.ComponentModel.DataAnnotations;

namespace ACMEAPP.Models
{
    public class EmployeeModel
    {

        public int EmployeeId { get; set; }

        public int PersonId { get; set; }
        [Required, StringLength(16)]
        public string EmployeeNumber { get; set; }
        [Required]
        [Display(Name = "Date Of Employment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime EmployedDate { get; set; }

        [Display(Name = "Employment Termination Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime? TerminatedDate { get; set; }

        public PersonModel Person { get; set; }

    }
}