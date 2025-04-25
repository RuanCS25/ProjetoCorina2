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
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alunos.Include(a => a.Classificacoe).Include(a => a.Horario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alunos/Details/5    
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Classificacoe)
                .Include(a => a.Horario)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["ClassificacoeId"] = new SelectList(_context.Classificacoes, "ClassificacoeId", "Descricao");
            ViewData["HorarioId"] = new SelectList(_context.Horarios, "HorarioId", "Turno");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoId,Nome,Email,Celular,CPF,ClassificacoeId,HorarioId,Senha")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.AlunoId = Guid.NewGuid();
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassificacoeId"] = new SelectList(_context.Classificacoes, "ClassificacoeId", "Descricao", aluno.ClassificacoeId);
            ViewData["HorarioId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioId", aluno.HorarioId);
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["ClassificacoeId"] = new SelectList(_context.Classificacoes, "ClassificacoeId", "Descricao", aluno.ClassificacoeId);
            ViewData["HorarioId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioId", aluno.HorarioId);
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AlunoId,Nome,Email,Celular,CPF,ClassificacoeId,HorarioId,Senha")] Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.AlunoId))
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
            ViewData["ClassificacoeId"] = new SelectList(_context.Classificacoes, "ClassificacoeId", "Descricao", aluno.ClassificacoeId);
            ViewData["HorarioId"] = new SelectList(_context.Horarios, "HorarioId", "HorarioId", aluno.HorarioId);
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Alunos == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Classificacoe)
                .Include(a => a.Horario)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Alunos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alunos'  is null.");
            }
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(Guid id)
        {
            return (_context.Alunos?.Any(e => e.AlunoId == id)).GetValueOrDefault();
        }
    }
}
