using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    public class Extract : BaseEntity
    {
        public Master Master { get; set; }
        public List<Detail> Detail { get; set; } = new List<Detail>();
    }

    public class Master : BaseEntity
    {
        public string CardNumber { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string CardLimit { get; set; }
        public string Balance { get; set; }
        public string ExpirationDate { get; set; }
    }

    public class Detail : BaseEntity
    {
        public string OperationDate { get; set; }
        public string OperationTime { get; set; }
        public string EmporiumName { get; set; }
        public string OperationType { get; set; }
        public string Value { get; set; }
        public string MonthYearRelease { get; set; }
        public string EmporiumCNPJ { get; set; }
        public string TotalValue { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
