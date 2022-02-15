using System.Linq;
using Liz.Data;
using Liz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Liz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        protected LizDbContext _lizDbContext;
        protected DbSet<Pedido> _dbSet;

        public PedidoController(LizDbContext lizDbContext)
        {
            _lizDbContext = lizDbContext;
            _dbSet = lizDbContext.Set<Pedido>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _dbSet
                .Include(o => o.Cliente)
                .Include(o => o.Status)
                .ToList();

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pedido = _dbSet
                .Include(o => o.Cliente)
                .Include(o => o.Status)
                .FirstOrDefault(o => o.Id == id);

            if (pedido != null)
                return Ok(pedido);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            try
            {
                pedido.Id = 0;

                _dbSet.Add(pedido);

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
            var pedido = _dbSet.FirstOrDefault(o => o.Id == id);

            if (pedido == null)
                return NoContent();

            _dbSet.Remove(pedido);

            _lizDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pedido pedido)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                pedido.Id = id;
                _dbSet.Update(pedido);

                _lizDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}