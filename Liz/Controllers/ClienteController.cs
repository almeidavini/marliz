using System.Linq;
using Liz.Data;
using Liz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Liz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        protected LizDbContext _lizDbContext;
        protected DbSet<Cliente> _dbSet;

        public ClienteController(LizDbContext lizDbContext)
        {
            _lizDbContext = lizDbContext;
            _dbSet = lizDbContext.Set<Cliente>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _dbSet
                .Include(o => o.Enderecos)
                .Include(o => o.Telefones)
                .ToList();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _dbSet
                .Include(o => o.Enderecos)
                .Include(o => o.Telefones)
                .FirstOrDefault(o => o.Id == id);

            if (cliente != null)
                return Ok(cliente);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                cliente.Id = 0;

                _dbSet.Add(cliente);

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
            var cliente = _dbSet.FirstOrDefault(o => o.Id == id);

            if (cliente == null)
                return NoContent();

            _dbSet.Remove(cliente);

            _lizDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                cliente.Id = id;
                _dbSet.Update(cliente);

                _lizDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}