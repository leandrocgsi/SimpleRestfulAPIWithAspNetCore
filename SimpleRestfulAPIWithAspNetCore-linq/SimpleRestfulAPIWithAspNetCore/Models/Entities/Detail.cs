using SimpleRestfulAPIWithAspNetCore.Models.Entities.Base;

namespace SimpleRestfulAPIWithAspNetCore.Models.Entities
{
    public class Detail : BaseEntity
    {
        public string OperationDate { get; set; }
        public string OperationTime { get; set; }
        public string EmporiumName { get; set; }
        public string OperationType { get; set; }
        public string Value { get; set; }
        public string EmporiumCNPJ { get; set; }
        public string TotalValue { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
