using System.Linq;
using Liz.Data;
using Liz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Liz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneController : ControllerBase
    {
        protected LizDbContext _lizDbContext;
        protected DbSet<Telefone> _dbSet;

        public TelefoneController(LizDbContext lizDbContext)
        {
            _lizDbContext = lizDbContext;
            _dbSet = lizDbContext.Set<Telefone>();
        }

        [HttpGet("{idCliente/idTelefone}")]
        public IActionResult Get(int idCliente, int idTelefone)
        {
            var telefone = _dbSet.FirstOrDefault(o => o.Id == idTelefone && o.ClienteId == idCliente);

            if (telefone != null)
                return Ok(telefone);
            else
                return NotFound();
        }

        [HttpGet("{idCliente}")]
        public IActionResult Get(int idCliente)
        {
            var telefones = _dbSet
                .Where(o => o.ClienteId == idCliente)
                .ToList();

            return Ok(telefones);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Telefone telefone)
        {
            try
            {
                telefone.Id = 0;

                _dbSet.Add(telefone);

                _lizDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var telefone = _dbSet.FirstOrDefault(o => o.Id == id);

            if (telefone == null)
                return NoContent();

            _dbSet.Remove(telefone);

            _lizDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Telefone telefone)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                telefone.Id = id;
                _dbSet.Update(telefone);

                _lizDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}