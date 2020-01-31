using API_Contatos2.Models;
using API_Contatos2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace API_Contatos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : Controller
    {
        private readonly ContatoRepository _repositorio;

        public ContatosController(ContatoRepository repositorio)
        {
            _repositorio = repositorio;
        }
 
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _repositorio.GetAll().ToList();
            if (!CheckAccessCondition())
                return Unauthorized();          // status 401 - ação requer autenticação
            if (resultado == null)
                return NotFound();              // status 404 - objeto não encontrado no servidor
            return Ok(resultado);               // status 200 - solicitação foi bem-sucedida
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contato> Get(int id)
        {
            var resultado = _repositorio.Get(id);
            if (!CheckAccessCondition())
                return Unauthorized();                      // status 401 - ação requer autenticação
            if (resultado == null)
                return NotFound();                          // status 404 - objeto não encontrado no servidor
            return Ok(resultado);                           // status 200 - solicitação foi bem-sucedida
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromForm] Contato contato)
        {
            if (!CheckAccessCondition())
                return Unauthorized();                      // status 401 - ação requer autenticação
            if (contato == null)
                return NotFound();                          // status 404 - objeto não encontrado no servidor
            _repositorio.Add(contato);      
            return Created("api/contatos", contato);        // status 201 - retorna o registro do contato
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Contato contato)
        {
            if (!CheckAccessCondition())
                return Unauthorized();                      // status 401 - ação requer autenticação
            if (contato == null)
                return NotFound();                          // status 404 - objeto não encontrado no servidor
            if (contato.Nome == null && contato.Valor == null && contato.Canal == null && contato.Obs == null)
                return NoContent();                         // status 204 - retorna o registro do contato atualizado, porém se encontra em branco
            _repositorio.Update(contato, id);               // status 201 - retorna o registro do contato atualizado
            return Created("api/contatos", contato);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!CheckAccessCondition())
                return Unauthorized();                      // status 401 - ação requer autenticação
            var contato = _repositorio.Get(id);
            if (contato == null)
                return NotFound();                          // status 404 - objeto não encontrado no servidor
            if (contato.Nome == null && contato.Valor == null && contato.Canal == null && contato.Obs == null)
                return NoContent();                         // status 204 - retorna o registro do contato atualizado, porém se encontra em branco
            _repositorio.Delete(id);
            return Ok("Registro excluído com sucesso.");    // status 200 - solicitação foi bem-sucedida
        }

        private bool CheckAccessCondition()
        {
            //throw new NotImplementedException();
            return true;    // Supondo que já esteja autenticado
        }
    }
}
