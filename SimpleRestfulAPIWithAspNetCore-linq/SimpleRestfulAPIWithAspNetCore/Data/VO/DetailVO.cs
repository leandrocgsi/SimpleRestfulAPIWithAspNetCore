using System;

namespace SimpleRestfulAPIWithAspNetCore.Data.VO
{
    public class DetailVO
    {
        public long Id { get; set; }
        public DateTime OperationDate { get; set; }
        public string EmporiumName { get; set; }
        public string OperationType { get; set; }
        public decimal Value { get; set; }
        public string EmporiumCNPJ { get; set; }
        public decimal TotalValue { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}