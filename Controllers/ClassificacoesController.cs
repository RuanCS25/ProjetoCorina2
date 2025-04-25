using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCorina2.Data;
using ProjetoCorina2.Models;

namespace ProjetoCorina2.Controllers
{
    public class ClassificacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassificacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Classificacoes
        public async Task<IActionResult> Index()
        {
              return _context.Classificacoes != null ? 
                          View(await _context.Classificacoes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Classificacoes'  is null.");
        }

        // GET: Classificacoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Classificacoes == null)
            {
                return NotFound();
            }

            var classificacoe = await _context.Classificacoes
                .FirstOrDefaultAsync(m => m.ClassificacoeId == id);
            if (classificacoe == null)
            {
                return NotFound();
            }

            return View(classificacoe);
        }

        // GET: Classificacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classificacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassificacoeId,Descricao")] Classificacoe classificacoe)
        {
            if (ModelState.IsValid)
            {
                classificacoe.ClassificacoeId = Guid.NewGuid();
                _context.Add(classificacoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classificacoe);
        }

        // GET: Classificacoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Classificacoes == null)
            {
                return NotFound();
            }

            var classificacoe = await _context.Classificacoes.FindAsync(id);
            if (classificacoe == null)
            {
                return NotFound();
            }
            return View(classificacoe);
        }

        // POST: Classificacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ClassificacoeId,Descricao")] Classificacoe classificacoe)
        {
            if (id != classificacoe.ClassificacoeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificacoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificacoeExists(classificacoe.ClassificacoeId))
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
            return View(classificacoe);
        }

        // GET: Classificacoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Classificacoes == null)
            {
                return NotFound();
            }

            var classificacoe = await _context.Classificacoes
                .FirstOrDefaultAsync(m => m.ClassificacoeId == id);
            if (classificacoe == null)
            {
                return NotFound();
            }

            return View(classificacoe);
        }

        // POST: Classificacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Classificacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Classificacoes'  is null.");
            }
            var classificacoe = await _context.Classificacoes.FindAsync(id);
            if (classificacoe != null)
            {
                _context.Classificacoes.Remove(classificacoe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificacoeExists(Guid id)
        {
          return (_context.Classificacoes?.Any(e => e.ClassificacoeId == id)).GetValueOrDefault();
        }
    }
}
