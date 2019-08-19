using System.Collections.Generic;
using Livraria.Model;
using Livraria.Business;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private ILivroBusiness _livroBusiness;

        public LivroController(ILivroBusiness livroBusiness)
        {
            _livroBusiness = livroBusiness;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_livroBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var livro = _livroBusiness.FindById(id);
            if (livro == null) return NotFound();
            return Ok(livro);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return new ObjectResult(_livroBusiness.Create(livro));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Livro livro)
        {
            if (livro == null) return BadRequest();
            return new ObjectResult(_livroBusiness.Update(livro));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _livroBusiness.Delete(id);
            return NoContent();
        }
    }
}
