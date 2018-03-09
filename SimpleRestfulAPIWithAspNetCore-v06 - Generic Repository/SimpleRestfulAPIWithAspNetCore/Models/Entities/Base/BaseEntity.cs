using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities.Base
{
    [DataContract]
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        [DataMember(Order = 1)]
        public long Id { get; set; }
    }
}