using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;

namespace OrionTM_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class AdminModeloController : Controller
    {
        private readonly AppDbContext _context;

        public AdminModeloController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminModelo
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {

            var resultado = _context.Modelo.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
            
        }

        // GET: Admin/AdminModelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(m => m.ModeloId == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Admin/AdminModelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminModelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeloId,Nome,Descricao,Fabricante,SistemaOperacional")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                var resultado = _context.Modelo.AsNoTracking().AsQueryable();
                resultado = resultado.Where(p => p.Nome.ToUpper().Equals(modelo.Nome.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Modelo já existe!!!!");

                }
                else
                {
                    _context.Add(modelo);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Modelos",
                        Detalhe = String.Concat("Criou -> ", modelo.Nome),
                        Data = DateTime.UtcNow
                    });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(modelo);
        }

        // GET: Admin/AdminModelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        // POST: Admin/AdminModelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModeloId,Nome,Descricao,Fabricante,SistemaOperacional")] Modelo modelo)
        {
            if (id != modelo.ModeloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Modelos",
                      Detalhe = String.Concat("Editou -> ", modelo.Nome),
                      Data = DateTime.UtcNow
                  });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.ModeloId))
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
            return View(modelo);
        }

        // GET: Admin/AdminModelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modelo == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(m => m.ModeloId == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Admin/AdminModelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modelo == null)
            {
                return Problem("Entity set 'AppDbContext.Modelo'  is null.");
            }
            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo != null)
            {
                _context.Modelo.Remove(modelo);
            }
            
            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Modelos",
                      Detalhe = String.Concat("Excluiu -> ", modelo.Nome),
                      Data = DateTime.UtcNow
                  });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
          return _context.Modelo.Any(e => e.ModeloId == id);
        }
    }
}
