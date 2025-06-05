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
    public class RegistroAusencias1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroAusencias1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroAusencias1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroAusencias.Include(r => r.Aluno);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroAusencias1/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RegistroAusencias == null)
            {
                return NotFound();
            }

            var registroAusencia = await _context.RegistroAusencias
                .Include(r => r.Aluno)
                .FirstOrDefaultAsync(m => m.RegistroAusenciaId == id);
            if (registroAusencia == null)
            {
                return NotFound();
            }

            return View(registroAusencia);
        }

        // GET: RegistroAusencias1/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome");
            return View();
        }

        // POST: RegistroAusencias1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroAusenciaId,AlunoId,Data,Refeicao")] RegistroAusencia registroAusencia)
        {
            if (ModelState.IsValid)
            {
                registroAusencia.RegistroAusenciaId = Guid.NewGuid();
                _context.Add(registroAusencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", registroAusencia.AlunoId);
            return View(registroAusencia);
        }

        // GET: RegistroAusencias1/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RegistroAusencias == null)
            {
                return NotFound();
            }

            var registroAusencia = await _context.RegistroAusencias.FindAsync(id);
            if (registroAusencia == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", registroAusencia.AlunoId);
            return View(registroAusencia);
        }

        // POST: RegistroAusencias1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RegistroAusenciaId,AlunoId,Data,Refeicao")] RegistroAusencia registroAusencia)
        {
            if (id != registroAusencia.RegistroAusenciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroAusencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroAusenciaExists(registroAusencia.RegistroAusenciaId))
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
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "AlunoId", "Nome", registroAusencia.AlunoId);
            return View(registroAusencia);
        }

        // GET: RegistroAusencias1/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RegistroAusencias == null)
            {
                return NotFound();
            }

            var registroAusencia = await _context.RegistroAusencias
                .Include(r => r.Aluno)
                .FirstOrDefaultAsync(m => m.RegistroAusenciaId == id);
            if (registroAusencia == null)
            {
                return NotFound();
            }

            return View(registroAusencia);
        }

        // POST: RegistroAusencias1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RegistroAusencias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroAusencias'  is null.");
            }
            var registroAusencia = await _context.RegistroAusencias.FindAsync(id);
            if (registroAusencia != null)
            {
                _context.RegistroAusencias.Remove(registroAusencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroAusenciaExists(Guid id)
        {
            return (_context.RegistroAusencias?.Any(e => e.RegistroAusenciaId == id)).GetValueOrDefault();
        }
    }
}
