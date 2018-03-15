using SimpleRestfulAPIWithAspNetCore.Data.VO;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Business
{
    //Substituição das entidades pelo VO
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
