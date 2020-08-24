using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Webmotors.Challenge.Domain.Dto.Request;
using Webmotors.Challenge.Domain.Entities;
using Webmotors.Challenge.Domain.Interfaces.Services;

namespace Webmotors.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _anuncioService;
        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        // GET: api/<AnuncioController>
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Anuncio> response = _anuncioService.Get();
            return Ok(response);
        }

        // GET api/<AnuncioController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Anuncio response = _anuncioService.Get(id);
            return Ok(response);
        }

        // POST api/<AnuncioController>
        [HttpPost]
        public ActionResult Post([FromBody] AnuncioRequest request)
        {
            _anuncioService.Add(request);
            return Ok("success");
        }

        // PUT api/<AnuncioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AnuncioRequest anuncio)
        {
            _anuncioService.Update(id, anuncio);
            var response = "";
            return Ok(response);
        }

        // DELETE api/<AnuncioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _anuncioService.Delete(id);
            return NoContent();
        }
    }
}
