using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ev1_u1.Models;

namespace ev1_u1.Controllers
{
    public class ServiciosClientesController : Controller
    {
        private readonly MercyDeveloperContext _context;

        public ServiciosClientesController(MercyDeveloperContext context)
        {
            _context = context;
        }

        // GET: ServiciosClientes
        public async Task<IActionResult> Index()
        {
            var mercyDeveloperContext = _context.ServiciosClientes.Include(s => s.ClientesIdClienteNavigation).Include(s => s.ServiciosIdServicioNavigation);
            return View(await mercyDeveloperContext.ToListAsync());
        }

        // GET: ServiciosClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciosCliente = await _context.ServiciosClientes
                .Include(s => s.ClientesIdClienteNavigation)
                .Include(s => s.ServiciosIdServicioNavigation)
                .FirstOrDefaultAsync(m => m.ServiciosIdServicio == id);
            if (serviciosCliente == null)
            {
                return NotFound();
            }

            return View(serviciosCliente);
        }

        // GET: ServiciosClientes/Create
        public IActionResult Create()
        {
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }

        // POST: ServiciosClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiciosIdServicio,ClientesIdCliente,Inicio,Termino,Observaciones,Tecnico,NProceso")] ServiciosCliente serviciosCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviciosCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", serviciosCliente.ClientesIdCliente);
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", serviciosCliente.ServiciosIdServicio);
            return View(serviciosCliente);
        }

        // GET: ServiciosClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciosCliente = await _context.ServiciosClientes.FindAsync(id);
            if (serviciosCliente == null)
            {
                return NotFound();
            }
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", serviciosCliente.ClientesIdCliente);
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", serviciosCliente.ServiciosIdServicio);
            return View(serviciosCliente);
        }

        // POST: ServiciosClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiciosIdServicio,ClientesIdCliente,Inicio,Termino,Observaciones,Tecnico,NProceso")] ServiciosCliente serviciosCliente)
        {
            if (id != serviciosCliente.ServiciosIdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviciosCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciosClienteExists(serviciosCliente.ServiciosIdServicio))
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
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", serviciosCliente.ClientesIdCliente);
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", serviciosCliente.ServiciosIdServicio);
            return View(serviciosCliente);
        }

        // GET: ServiciosClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciosCliente = await _context.ServiciosClientes
                .Include(s => s.ClientesIdClienteNavigation)
                .Include(s => s.ServiciosIdServicioNavigation)
                .FirstOrDefaultAsync(m => m.ServiciosIdServicio == id);
            if (serviciosCliente == null)
            {
                return NotFound();
            }

            return View(serviciosCliente);
        }

        // POST: ServiciosClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviciosCliente = await _context.ServiciosClientes.FindAsync(id);
            if (serviciosCliente != null)
            {
                _context.ServiciosClientes.Remove(serviciosCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciosClienteExists(int id)
        {
            return _context.ServiciosClientes.Any(e => e.ServiciosIdServicio == id);
        }
    }
}
