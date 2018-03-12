using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities.Base
{
    // Contrato entre atributos
    // e colunas da tabela
    [DataContract]
    public class BaseEntity
    {
        // Define o atributo como chave da tabela
        [Key]
        [Column("id")]
        [DataMember(Order = 1)]
        public long Id { get; set; }
    }
}