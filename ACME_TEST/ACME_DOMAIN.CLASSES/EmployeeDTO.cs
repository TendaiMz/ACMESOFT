using System;
using System.Runtime.Serialization;

namespace ACME_DOMAIN.CLASSES
{
    [DataContract]
    public class EmployeeDTO
    {
        [DataMember]
        public int EmployeeId { get; set; }
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string EmployeeNumber { get; set; }
        [DataMember]
        public DateTime EmployedDate { get; set; }
        [DataMember]
        public DateTime? TerminatedDate { get; set; }
        [DataMember]
        public PersonDTO Person { get; set; }
    }
}
