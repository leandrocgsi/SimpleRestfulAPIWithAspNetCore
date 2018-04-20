﻿using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    public class Extract : BaseEntity
    {
        // Anotações de mapeamento ORM
        // são opcionais se o nome do atributo
        // e da coluna na tabela forem iguais
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Address")]
        public string Address { get; set; }
    }
}
