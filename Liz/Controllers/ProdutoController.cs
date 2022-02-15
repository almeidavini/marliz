using System.Linq;
using Liz.Data;
using Liz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Liz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        protected LizDbContext _lizDbContext;
        protected DbSet<Produto> _dbSet;

        public ProdutoController(LizDbContext lizDbContext)
        {
            _lizDbContext = lizDbContext;
            _dbSet = lizDbContext.Set<Produto>();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _dbSet
                .Include(o => o.TpUnidade)
                .ToList();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _dbSet
                .Include(o => o.TpUnidade)
                .FirstOrDefault(o => o.Id == id);

            if (produto != null)
                return Ok(produto);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                produto.Id = 0;

                _dbSet.Add(produto);

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
            var produto = _dbSet.FirstOrDefault(o => o.Id == id);

            if (produto == null)
                return NoContent();

            _dbSet.Remove(produto);

            _lizDbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Produto produto)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                produto.Id = id;
                _dbSet.Update(produto);

                _lizDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}