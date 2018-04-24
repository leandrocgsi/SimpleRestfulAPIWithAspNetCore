using Microsoft.AspNetCore.Mvc;
using SimpleRestfulAPIWithAspNetCore.Business;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using SimpleRestfulAPIWithAspNetCore.Utils;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Controllers
{

    [Route("api/[controller]")]
    public class ExtractController : Controller
    {
        private IExtractBusiness _extractBusiness;

        public ExtractController(IExtractBusiness extractBusiness)
        {
            _extractBusiness = extractBusiness;
        }

        [HttpGet]
        [SwaggerResponse((200), Type = typeof(ExtractVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get([FromQuery]string from, [FromQuery]string to)
        {
            //EXAMPLE REQUEST: http://localhost:53032/api/extract?from=01/01/2018&to=30/04/2018
            var datePattern = "dd/MM/yyyy";
            var startDate = DateUtils.SafeParse(from, datePattern);
            var endDate = DateUtils.SafeParse(to, datePattern);

            var extract = _extractBusiness.GetExtract(startDate, endDate);
            return Ok(extract);
        }
    }
}