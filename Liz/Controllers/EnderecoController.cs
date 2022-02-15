using System.Linq;
using Liz.Data;
using Liz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Liz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        protected LizDbContext _lizDbContext;
        protected DbSet<Endereco> _dbSet;

        public EnderecoController(LizDbContext lizDbContext)
        {
            _lizDbContext = lizDbContext;
            _dbSet = lizDbContext.Set<Endereco>();
        }

        [HttpGet("{idCliente/idEndereco}")]
        public IActionResult Get(int idCliente, int idEndereco)
        {
            var endereco = _dbSet.FirstOrDefault(o => o.Id == idEndereco && o.ClienteId == idCliente);

            if (endereco != null)
                return Ok(endereco);
            else
                return NotFound();
        }

        [HttpGet("{idCliente}")]
        public IActionResult Get(int idCliente)
        {
            var enderecos = _dbSet
                .Where(o => o.ClienteId == idCliente)
                .ToList();

            return Ok(enderecos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                endereco.Id = 0;

                _dbSet.Add(endereco);

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
            var endereco = _dbSet.FirstOrDefault(o => o.Id == id);

            if (endereco == null)
                return NoContent();

            _dbSet.Remove(endereco);

            _lizDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Endereco endereco)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                endereco.Id = id;
                _dbSet.Update(endereco);

                _lizDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}