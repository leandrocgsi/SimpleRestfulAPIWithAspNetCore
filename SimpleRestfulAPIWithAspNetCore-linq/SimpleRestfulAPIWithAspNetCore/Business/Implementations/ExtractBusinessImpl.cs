using System.Collections.Generic;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using SimpleRestfulAPIWithAspNetCore.Repository.Generic;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Data.Converters;

namespace SimpleRestfulAPIWithAspNetCore.Business.Implementations
{
    public class ExtractBusinessImpl : IExtractBusiness
    {

        private IRepository<Extract> _repository;
        
        private readonly ExtractConverter _converter;

        public ExtractBusinessImpl(IRepository<Extract> repository)
        {
            _repository = repository;
            _converter = new ExtractConverter();
        }

        public List<ExtractVO> FindAll()
        {
            var extracts = _repository.FindAll();
            return _converter.ParseList(extracts);
        }
    }
}
