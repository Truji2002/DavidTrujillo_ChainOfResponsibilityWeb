using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DavidTrujillo_EjercicioCF.Data;
using DavidTrujillo_EjercicioCF.Models;
using DavidTrujillo_EjercicioCF.Handlers;
using System.Linq.Expressions;

namespace DavidTrujillo_EjercicioCF.Controllers
{
    public class SanducheController : Controller
    {
        private readonly DavidTrujillo_EjercicioCFContext _context;
        private readonly ValidarNombreHandler _validarNombreHandler;
        private readonly VerificarRangoPrecioHandler _verificarRangoPrecioHandler;

        public SanducheController(DavidTrujillo_EjercicioCFContext context)
        {

            _context = context;
            _validarNombreHandler = new ValidarNombreHandler();
            _verificarRangoPrecioHandler = new VerificarRangoPrecioHandler();

            _validarNombreHandler.NextHandler = _verificarRangoPrecioHandler;
        }

        // GET: Sanduche
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sanduche.ToListAsync());
        }

        // GET: Sanduche/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sanduche == null)
            {
                return NotFound();
            }

            var sanduche = await _context.Sanduche
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanduche == null)
            {
                return NotFound();
            }

            return View(sanduche);
        }

        // GET: Sanduche/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sanduche/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,ConQueso,ConVegetales,Precio")] Sanduche sanduche)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _validarNombreHandler.HandleRequest(sanduche);
                    _context.Add(sanduche);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    
                    TempData["Ingrese un nombre o un valor valido en precio"] = ex.Message;
                    
                }
            }
            return View(sanduche);
        }

        // GET: Sanduche/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sanduche == null)
            {
                return NotFound();
            }

            var sanduche = await _context.Sanduche.FindAsync(id);
            if (sanduche == null)
            {
                return NotFound();
            }
            return View(sanduche);
        }

        // POST: Sanduche/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,ConQueso,ConVegetales,Precio")] Sanduche sanduche)
        {
            if (id != sanduche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    
                 

                        _validarNombreHandler.HandleRequest(sanduche);
                        _context.Update(sanduche);
                        await _context.SaveChangesAsync();
                    
       
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!SanducheExists(sanduche.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    TempData["Ingrese un nombre o un valor valido en precio"] = ex.Message;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(sanduche);
        }

        // GET: Sanduche/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sanduche == null)
            {
                return NotFound();
            }

            var sanduche = await _context.Sanduche
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanduche == null)
            {
                return NotFound();
            }

            return View(sanduche);
        }

        // POST: Sanduche/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sanduche == null)
            {
                return Problem("Entity set 'DavidTrujillo_EjercicioCFContext.Sanduche'  is null.");
            }
            var sanduche = await _context.Sanduche.FindAsync(id);
            if (sanduche != null)
            {
                _context.Sanduche.Remove(sanduche);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanducheExists(int id)
        {
          return _context.Sanduche.Any(e => e.Id == id);
        }
    }
}
