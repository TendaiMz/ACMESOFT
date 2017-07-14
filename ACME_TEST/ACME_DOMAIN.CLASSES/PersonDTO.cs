using System;
using System.Runtime.Serialization;

namespace ACME_DOMAIN.CLASSES
{
    [DataContract]
    public class PersonDTO
    {
        [DataMember]
        public int PersonId { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
    }
}
