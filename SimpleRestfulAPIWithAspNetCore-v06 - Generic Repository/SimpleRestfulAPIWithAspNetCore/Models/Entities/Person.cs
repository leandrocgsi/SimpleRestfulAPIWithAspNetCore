using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    public class Person : BaseEntity
    {
        [Column("FirstName")]
        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [Column("LastName")]
        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [Column("Address")]
        [DataMember(Order = 4)]
        public string Address { get; set; }
    }
}
