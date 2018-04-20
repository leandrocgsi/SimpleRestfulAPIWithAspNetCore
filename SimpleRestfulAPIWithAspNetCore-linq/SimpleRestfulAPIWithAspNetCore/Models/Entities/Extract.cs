using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    public class Extract : BaseEntity
    {
        public Master Master { get; set; }
        public List<Detail> Detail { get; set; } = new List<Detail>();
    }
}
