using Microsoft.AspNetCore.Mvc;
using SimpleRestfulAPIWithAspNetCore.Business;
using SimpleRestfulAPIWithAspNetCore.Data.VO;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SimpleRestfulAPIWithAspNetCore.Controllers
{

    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IPersonBusiness _personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/person/
        // [SwaggerResponse((202), Type = typeof(List<Person>))]
        // determina o objeto de retorno em caso de sucesso List<Person>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<PersonVO>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/person/{id}
        // [SwaggerResponse((202), Type = typeof(Person))]
        // determina o objeto de retorno em caso de sucesso Person
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(PersonVO))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(Person))]
        // determina o objeto de retorno em caso de sucesso Person
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(PersonVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Post([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/person/
        // [SwaggerResponse((202), Type = typeof(Person))]
        // determina o objeto de retorno em caso de sucesso Person
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(PersonVO))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Update(person));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/person/{id}
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public IActionResult Delete(long id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}