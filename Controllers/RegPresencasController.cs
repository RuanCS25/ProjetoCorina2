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
    public class RegPresencasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegPresencasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegPresencas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegPresencas.Include(r => r.Alunos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegPresencas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RegPresencas == null)
            {
                return NotFound();
            }

            var regPresenca = await _context.RegPresencas
                .Include(r => r.Alunos)
                .FirstOrDefaultAsync(m => m.RegPresencaId == id);
            if (regPresenca == null)
            {
                return NotFound();
            }

            return View(regPresenca);
        }

        // GET: RegPresencas/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome");
            return View();
        }

        // POST: RegPresencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegPresencaId,AlunoId,DataPresenca,Refeicao")] RegPresenca regPresenca)
        {
            if (ModelState.IsValid)
            {
                regPresenca.RegPresencaId = Guid.NewGuid();
                _context.Add(regPresenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", regPresenca.AlunoId);
            return View(regPresenca);
        }

        // GET: RegPresencas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RegPresencas == null)
            {
                return NotFound();
            }

            var regPresenca = await _context.RegPresencas.FindAsync(id);
            if (regPresenca == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", regPresenca.AlunoId);
            return View(regPresenca);
        }

        // POST: RegPresencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RegPresencaId,AlunoId,DataPresenca,Refeicao")] RegPresenca regPresenca)
        {
            if (id != regPresenca.RegPresencaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regPresenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegPresencaExists(regPresenca.RegPresencaId))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", regPresenca.AlunoId);
            return View(regPresenca);
        }

        // GET: RegPresencas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RegPresencas == null)
            {
                return NotFound();
            }

            var regPresenca = await _context.RegPresencas
                .Include(r => r.Alunos)
                .FirstOrDefaultAsync(m => m.RegPresencaId == id);
            if (regPresenca == null)
            {
                return NotFound();
            }

            return View(regPresenca);
        }

        // POST: RegPresencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RegPresencas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegPresencas'  is null.");
            }
            var regPresenca = await _context.RegPresencas.FindAsync(id);
            if (regPresenca != null)
            {
                _context.RegPresencas.Remove(regPresenca);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegPresencaExists(Guid id)
        {
            return (_context.RegPresencas?.Any(e => e.RegPresencaId == id)).GetValueOrDefault();
        }
    }
}
