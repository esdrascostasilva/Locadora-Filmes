using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Locadora.API.Model;

namespace Locadora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiretoresController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DiretoresController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Diretores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diretor>>> GetDiretores()
        {
            return await _context.Diretores.ToListAsync();
        }

        // GET: api/Diretores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diretor>> GetDiretor(Guid id)
        {
            var diretor = await _context.Diretores.FindAsync(id);

            if (diretor == null)
            {
                return NotFound();
            }

            return diretor;
        }

        // PUT: api/Diretores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiretor(Guid id, Diretor diretor)
        {
            if (id != diretor.Id)
            {
                return BadRequest();
            }

            _context.Entry(diretor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiretorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Diretores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Diretor>> PostDiretor(Diretor diretor)
        {
            _context.Diretores.Add(diretor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiretor", new { id = diretor.Id }, diretor);
        }

        // DELETE: api/Diretores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diretor>> DeleteDiretor(Guid id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
            {
                return NotFound();
            }

            _context.Diretores.Remove(diretor);
            await _context.SaveChangesAsync();

            return diretor;
        }

        private bool DiretorExists(Guid id)
        {
            return _context.Diretores.Any(e => e.Id == id);
        }
    }
}
