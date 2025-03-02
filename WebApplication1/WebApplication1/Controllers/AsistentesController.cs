using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AsistentesController : Controller
    {
        private readonly PlataformaDeReservasDeConsultasMedicasContext _context;

        public AsistentesController(PlataformaDeReservasDeConsultasMedicasContext context)
        {
            _context = context;
        }

        // GET: Asistentes
        public async Task<IActionResult> Index()
        {
            var plataformaDeReservasDeConsultasMedicasContext = _context.Asistentes.Include(a => a.IdUsuarioNavigation);
            return View(await plataformaDeReservasDeConsultasMedicasContext.ToListAsync());
        }

        // GET: Asistentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistente = await _context.Asistentes
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdAsistente == id);
            if (asistente == null)
            {
                return NotFound();
            }

            return View(asistente);
        }

        // GET: Asistentes/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Asistentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsistente,Nombre,Apellido,Telefono,Email,FechaDeRegistro,IdUsuario")] Asistente asistente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asistente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", asistente.IdUsuario);
            return View(asistente);
        }

        // GET: Asistentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistente = await _context.Asistentes.FindAsync(id);
            if (asistente == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", asistente.IdUsuario);
            return View(asistente);
        }

        // POST: Asistentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsistente,Nombre,Apellido,Telefono,Email,FechaDeRegistro,IdUsuario")] Asistente asistente)
        {
            if (id != asistente.IdAsistente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asistente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenteExists(asistente.IdAsistente))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", asistente.IdUsuario);
            return View(asistente);
        }

        // GET: Asistentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistente = await _context.Asistentes
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdAsistente == id);
            if (asistente == null)
            {
                return NotFound();
            }

            return View(asistente);
        }

        // POST: Asistentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asistente = await _context.Asistentes.FindAsync(id);
            if (asistente != null)
            {
                _context.Asistentes.Remove(asistente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenteExists(int id)
        {
            return _context.Asistentes.Any(e => e.IdAsistente == id);
        }
    }
}
