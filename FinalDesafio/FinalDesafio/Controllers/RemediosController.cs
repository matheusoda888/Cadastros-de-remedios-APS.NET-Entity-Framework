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
    public class RemediosController : Controller
    {
        private readonly AtosEntity8Context _context;

        public RemediosController(AtosEntity8Context context)
        {
            _context = context;
        }

        // GET: Remedios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Remedios.ToListAsync());
        }

        // GET: Remedios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Remedios == null)
            {
                return NotFound();
            }

            var remedio = await _context.Remedios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remedio == null)
            {
                return NotFound();
            }

            return View(remedio);
        }

        // GET: Remedios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Remedios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Remedio remedio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(remedio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(remedio);
        }

        // GET: Remedios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Remedios == null)
            {
                return NotFound();
            }

            var remedio = await _context.Remedios.FindAsync(id);
            if (remedio == null)
            {
                return NotFound();
            }
            return View(remedio);
        }

        // POST: Remedios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Remedio remedio)
        {
            if (id != remedio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(remedio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemedioExists(remedio.Id))
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
            return View(remedio);
        }

        // GET: Remedios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Remedios == null)
            {
                return NotFound();
            }

            var remedio = await _context.Remedios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (remedio == null)
            {
                return NotFound();
            }

            return View(remedio);
        }

        // POST: Remedios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Remedios == null)
            {
                return Problem("Entity set 'AtosEntity8Context.Remedios'  is null.");
            }
            var remedio = await _context.Remedios.FindAsync(id);
            if (remedio != null)
            {
                _context.Remedios.Remove(remedio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemedioExists(int id)
        {
          return _context.Remedios.Any(e => e.Id == id);
        }
    }
}
