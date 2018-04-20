using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    public class Master : BaseEntity
    {
        public string CardNumber { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string CardLimit { get; set; }
        public string Balance { get; set; }
        public string ExpirationDate { get; set; }
    }
}
