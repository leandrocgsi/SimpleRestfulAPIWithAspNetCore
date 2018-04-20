using System;
using System.Collections.Generic;
using System.Linq;
using SimpleRestfulAPIWithAspNetCore.Data.Converter;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Models.Entities;
using SimpleRestfulAPIWithAspNetCore.Utils;

namespace SimpleRestfulAPIWithAspNetCore.Data.Converters
{
    public class ExtractConverter : IParser<ExtractVO, Extract>, IParser<Extract, ExtractVO>
    {
        public Extract Parse(ExtractVO origin)
        {
            if (origin == null) return new Extract();
            return new Extract
            {
                Id = origin.Id,
            };
        }

        public ExtractVO Parse(Extract origin)
        {
            if (origin == null) return new ExtractVO();
            return new ExtractVO
            {
                Id = origin.Id,
                Master = Parse(origin.Master),
                Detail = Parse(origin.Detail),
            };
        }

        private List<List<DetailVO>> Parse(List<Detail> detail)
        {
            var details = ParseList(detail);

            List<List<DetailVO>> months = details
                .GroupBy(det => det.OperationDate)
                .Select(group => group.ToList())
                .ToList();

            return months;
        }

        private MasterVO Parse(Master origin)
        {
            if (origin == null) return new MasterVO();
            return new MasterVO
            {
                Address = origin.Address,
                Balance = (decimal.Parse(origin.Balance.Trim())) / 100,
                CardLimit = (decimal.Parse(origin.CardLimit.Trim())) / 100,
                CardNumber = origin.CardNumber,
                ClientName = origin.ClientName,
                ExpirationDate = origin.ExpirationDate
            };
        }

        private DetailVO Parse(Detail origin)
        {
            if (origin == null) return new DetailVO();
            return new DetailVO
            {
                Id = origin.Id,
                EmporiumName = origin.EmporiumName,
                EmporiumCNPJ = origin.EmporiumCNPJ,
                Latitude = origin.Latitude,
                Longitude = origin.Longitude,
                OperationDate = (DateTime)DateUtils.SafeParse(origin.OperationDate.Trim() + origin.OperationTime.Trim(), "ddMMyyyyhhmm"),
                OperationType = origin.OperationType,
                Value = decimal.Parse(origin.Value.Trim()) / 100,
                TotalValue = decimal.Parse(origin.TotalValue.Trim()) / 100,
            };
        }

        public List<DetailVO> ParseList(List<Detail> Extracts)
        {
            if (Extracts == null) return new List<DetailVO>();
            return Extracts.Select(detail => Parse(detail)).ToList();
        }

        public List<Extract> ParseList(List<ExtractVO> Extracts)
        {
            if (Extracts == null) return new List<Extract>();
            return Extracts.Select(item => Parse(item)).ToList();
        }

        public List<ExtractVO> ParseList(List<Extract> Extracts)
        {
            if (Extracts == null) return new List<ExtractVO>();
            return Extracts.Select(item => Parse(item)).ToList();
        }

    }
}
