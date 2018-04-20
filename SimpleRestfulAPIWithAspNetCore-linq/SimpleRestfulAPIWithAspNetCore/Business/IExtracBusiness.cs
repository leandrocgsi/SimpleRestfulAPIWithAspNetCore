using SimpleRestfulAPIWithAspNetCore.Data.VO;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Business
{
    public interface IExtractBusiness
    {
        List<ExtractVO> FindAll();
    }
}
