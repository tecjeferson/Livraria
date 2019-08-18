using System.Collections.Generic;
using Livraria.Model;
using Livraria.Services;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_livroService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var livro = _livroService.FindById(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return new ObjectResult(_livroService.Create(livro));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return new ObjectResult(_livroService.Update(livro));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _livroService.Delete(id);
            return NoContent();
        }
    }
}
