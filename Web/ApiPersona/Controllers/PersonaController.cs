using Microsoft.AspNetCore.Mvc;
using Persona.Application.Interfaces.AppServices;
using Persona.Application.ViewModels;
using System;

namespace ApiPersona.Controllers
{
    [Route("api/persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaAppService _personaAppService;

        public PersonaController(IPersonaAppService personaAppService)
        {
            this._personaAppService = personaAppService;
        }

        [HttpGet("active")]
        [ProducesResponseType(200, Type = typeof(PersonaViewModel))]
        public ActionResult GetActive()
        {
            var activePersona = this._personaAppService.GetActive();

            return Ok(activePersona);
        }

        [HttpGet("active-name")]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult GetActiveName()
        {
            var activePersona = this._personaAppService.GetActiveName();

            return Ok(activePersona);
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(PersonaViewModel))]
        public ActionResult GetActivePersona()
        {
            var activePersona = this._personaAppService.GetActive();

            return Ok(activePersona);
        }

        [HttpGet("active-photo")]
        [ProducesResponseType(200, Type = typeof(string))]
        public ActionResult GetActivePhoto()
        {
            var activePersona = this._personaAppService.GetActivePhoto();

            return Ok(activePersona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public ActionResult GetActivePhoto(Guid id)
        {
            this._personaAppService.SetPersonaActive(id);

            return Ok();
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(Guid))]
        public ActionResult SavePersona([FromBody] PersonaViewModel personaViewModel)
        {
            var id = this._personaAppService.SavePersona(personaViewModel);

            return Ok(id);
        }
    }
}