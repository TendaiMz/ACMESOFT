using System;
using System.ComponentModel.DataAnnotations;

namespace ACMEAPP.Models
{
    public class PersonModel
    {
        public int PersonId { get; set; }
        [Required, StringLength(128)]
        public string LastName { get; set; }
        [Required, StringLength(128)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime BirthDate { get; set; }
    }
}