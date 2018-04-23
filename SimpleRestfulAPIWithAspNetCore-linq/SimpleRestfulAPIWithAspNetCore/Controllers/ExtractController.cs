using Microsoft.AspNetCore.Mvc;
using SimpleRestfulAPIWithAspNetCore.Business;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
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
        [SwaggerResponse((200), Type = typeof(List<ExtractVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get()
        {
            var extract = _extractBusiness.GetExtract();
            return Ok(extract);
        }
    }
}