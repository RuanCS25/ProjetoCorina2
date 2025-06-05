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
    public class AvisosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvisosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Avisos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Avisos.Include(a => a.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Avisos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Avisos == null)
            {
                return NotFound();
            }

            var aviso = await _context.Avisos
                .Include(a => a.Aluno)
                .FirstOrDefaultAsync(m => m.AvisoId == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // GET: Avisos/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome");
            return View();
        }

        // POST: Avisos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvisoId,AlunoId,Descricao")] Aviso aviso)
        {
            if (ModelState.IsValid)
            {
                aviso.AvisoId = Guid.NewGuid();
                _context.Add(aviso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", aviso.AlunoId);
            return View(aviso);
        }

        // GET: Avisos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Avisos == null)
            {
                return NotFound();
            }

            var aviso = await _context.Avisos.FindAsync(id);
            if (aviso == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", aviso.AlunoId);
            return View(aviso);
        }

        // POST: Avisos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AvisoId,AlunoId,Descricao")] Aviso aviso)
        {
            if (id != aviso.AvisoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aviso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvisoExists(aviso.AvisoId))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", aviso.AlunoId);
            return View(aviso);
        }

        // GET: Avisos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Avisos == null)
            {
                return NotFound();
            }

            var aviso = await _context.Avisos
                .Include(a => a.Aluno)
                .FirstOrDefaultAsync(m => m.AvisoId == id);
            if (aviso == null)
            {
                return NotFound();
            }

            return View(aviso);
        }

        // POST: Avisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Avisos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Avisos'  is null.");
            }
            var aviso = await _context.Avisos.FindAsync(id);
            if (aviso != null)
            {
                _context.Avisos.Remove(aviso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvisoExists(Guid id)
        {
            return (_context.Avisos?.Any(e => e.AvisoId == id)).GetValueOrDefault();
        }
    }
}
