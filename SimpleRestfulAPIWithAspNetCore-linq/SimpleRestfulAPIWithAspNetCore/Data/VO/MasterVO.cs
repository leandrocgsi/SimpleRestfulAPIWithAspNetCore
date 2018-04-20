namespace SimpleRestfulAPIWithAspNetCore.Data.VO
{
    public class MasterVO
    {
        public long Id { get; set; }
        public string CardNumber { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public decimal CardLimit { get; set; }
        public decimal Balance { get; set; }
        public string ExpirationDate { get; set; }
    }
}