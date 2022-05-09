using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora.API.Model;

namespace Locadora.API.Controllers
{
    public class DiretoresController : Controller
    {
        private readonly ApiDbContext _context;

        public DiretoresController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: Diretores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diretores.ToListAsync());
        }

        // GET: Diretores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // GET: Diretores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diretores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,DataNascimento,Sexo,Id")] Diretor diretor)
        {
            if (ModelState.IsValid)
            {
                diretor.Id = Guid.NewGuid();
                _context.Add(diretor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diretor);
        }

        // GET: Diretores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
            {
                return NotFound();
            }
            return View(diretor);
        }

        // POST: Diretores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,DataNascimento,Sexo,Id")] Diretor diretor)
        {
            if (id != diretor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diretor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiretorExists(diretor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(diretor);
        }

        // GET: Diretores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // POST: Diretores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            _context.Diretores.Remove(diretor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiretorExists(Guid id)
        {
            return _context.Diretores.Any(e => e.Id == id);
        }
    }
}
