using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Data.Converters;
using SimpleRestfulAPIWithAspNetCore.Repository;
using System;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using SimpleRestfulAPIWithAspNetCore.Utils;

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

        public ExtractVO GetExtract(DateTime? startDate, DateTime? endDate)
        {
            var extract = _repository.GetExtract();

            if (startDate != null && endDate != null)
            {
                List<Detail> details = ApplingFilterByDates(startDate, endDate, extract.Detail);
                extract.Detail = details;
            }
            else if (startDate != null && endDate == null)
            {
                List<Detail> details = ApplingFilterByDates(startDate, DateTime.Now, extract.Detail);
                extract.Detail = details;
            }

            return _converter.Parse(extract);
        }

        private List<Detail> ApplingFilterByDates(DateTime? startDate, DateTime? endDate, List<Detail> detail)
        {
            var from = ((DateTime)startDate).AddDays(-1);
            var to = ((DateTime)endDate).AddDays(1);

            return (
                from d in detail
                where startDate < GetDate(d.OperationDate)
                where endDate > GetDate(d.OperationDate)
                select d
            ).ToList();
        }

        private DateTime GetDate(string input)
        {
            return (DateTime)DateUtils.SafeParse(input.Trim(), "ddMMyyyy");
        }
    }
}
