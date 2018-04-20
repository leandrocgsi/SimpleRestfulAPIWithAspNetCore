using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Data.VO
{
    public class ExtractVO
    {
        public long Id { get; set; }
        public MasterVO Master { get; set; }
        public List<DetailVO> Detail { get; set; } = new List<DetailVO>();
    }
}
