using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    // Estende BaseEntity por causa
    // do repositório genérico
    public class Person : BaseEntity
    {
        // Anotações de mapeamento ORM
        // são opcionais se o nome do atributo
        // e da coluna na tabela forem iguais
        [Column("FirstName")]
        [DataMember(Order = 2)]
        public string FirstName { get; set; }

        [Column("LastName")]
        // Ordem em que o atributo
        // será serializado no JSON
        [DataMember(Order = 3)]
        public string LastName { get; set; }

        [Column("Address")]
        [DataMember(Order = 4)]
        public string Address { get; set; }
    }
}
