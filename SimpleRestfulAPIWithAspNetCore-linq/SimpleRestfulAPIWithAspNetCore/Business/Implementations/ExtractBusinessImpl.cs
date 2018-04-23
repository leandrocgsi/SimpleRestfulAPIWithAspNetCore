using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Data.Converters;
using SimpleRestfulAPIWithAspNetCore.Repository;

namespace SimpleRestfulAPIWithAspNetCore.Business.Implementations
{
    public class ExtractBusinessImpl : IExtractBusiness
    {

        private ExtractRepository _repository;
        
        private readonly ExtractConverter _converter;

        public ExtractBusinessImpl(ExtractRepository repository)
        {
            _repository = repository;
            _converter = new ExtractConverter();
        }

        public ExtractVO GetExtract()
        {
            var extract = _repository.GetExtract();
            return _converter.Parse(extract);
        }
    }
}
