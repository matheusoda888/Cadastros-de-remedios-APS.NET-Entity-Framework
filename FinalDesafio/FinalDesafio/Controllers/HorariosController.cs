using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalDesafio.Models;
using FinalDesafio.Data;

namespace FinalDesafio.Controllers
{
    public class HorariosController : Controller
    {
        private readonly AtosEntity8Context _context;

        public HorariosController(AtosEntity8Context context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var atosEntity8Context = _context.Horarios.Include(h => h.NomePacienteNavigation).Include(h => h.NomeRemedioNavigation);
            return View(await atosEntity8Context.ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.NomePacienteNavigation)
                .Include(h => h.NomeRemedioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["NomePaciente"] = new SelectList(_context.Pacientes, "Nome", "Nome");
            ViewData["NomeRemedio"] = new SelectList(_context.Remedios, "Nome", "Nome");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeRemedio,NomePaciente,Tempo,Horario1")] Horario horario)
        {
            if (ModelState!=null)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NomePaciente"] = new SelectList(_context.Pacientes, "Nome", "Nome", horario.NomePaciente);
            ViewData["NomeRemedio"] = new SelectList(_context.Remedios, "Nome", "Nome", horario.NomeRemedio);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["NomePaciente"] = new SelectList(_context.Pacientes, "Nome", "Nome", horario.NomePaciente);
            ViewData["NomeRemedio"] = new SelectList(_context.Remedios, "Nome", "Nome", horario.NomeRemedio);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeRemedio,NomePaciente,Tempo,Horario1")] Horario horario)
        {
            if (id != horario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.Id))
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
            ViewData["NomePaciente"] = new SelectList(_context.Pacientes, "Nome", "Nome", horario.NomePaciente);
            ViewData["NomeRemedio"] = new SelectList(_context.Remedios, "Nome", "Nome", horario.NomeRemedio);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.NomePacienteNavigation)
                .Include(h => h.NomeRemedioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Horarios == null)
            {
                return Problem("Entity set 'AtosEntity8Context.Horarios'  is null.");
            }
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                _context.Horarios.Remove(horario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
          return _context.Horarios.Any(e => e.Id == id);
        }
    }
}
