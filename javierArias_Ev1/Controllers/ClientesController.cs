using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using javierArias_Ev1.Data;
using javierArias_Ev1.Models;

namespace javierArias_Ev1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly javierArias_Ev1Context _context;

        public ClientesController(javierArias_Ev1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Cliente
                .Include(c => c.PlanDeRecompensa)
                .Include(c => c.Reservas)
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nombre,Edad,Saldo,Email,EsActivo,FechaRegistro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();

                // Crear Plan de Recompensa por defecto
                var plan = new PlanDeRecompensa
                {
                    Nombre = "Bienvenida",
                    FechaInicio = DateTime.Now,
                    PuntosAcumulados = 0,
                    ClienteId = cliente.ClienteId
                };
                _context.PlanDeRecompensa.Add(plan);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombre,Edad,Saldo,Email,EsActivo,FechaRegistro")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.ClienteId == id);

            if (cliente == null)
                return NotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }
    }
}
