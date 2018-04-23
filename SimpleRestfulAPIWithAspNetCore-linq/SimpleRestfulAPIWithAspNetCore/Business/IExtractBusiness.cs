using System;
using SimpleRestfulAPIWithAspNetCore.Data.VO;

namespace SimpleRestfulAPIWithAspNetCore.Business
{
    public interface IExtractBusiness
    {
        ExtractVO GetExtract(DateTime? startDate, DateTime? endDate);
    }
}
