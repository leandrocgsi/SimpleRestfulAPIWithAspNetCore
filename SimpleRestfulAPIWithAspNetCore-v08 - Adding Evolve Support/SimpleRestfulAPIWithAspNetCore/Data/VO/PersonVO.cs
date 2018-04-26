using System.Runtime.Serialization;

namespace SimpleRestfulAPIWithAspNetCore.Data.VO
{
    public class PersonVO
    {
        // Ordem em que o atributo
        // será serializado no JSON
        [DataMember(Order = 1)]
        public long Id { get; set; }

        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [DataMember(Order = 4)]
        public string Address { get; set; }
    }
}
