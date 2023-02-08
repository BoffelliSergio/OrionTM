using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;

namespace OrionTM_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLocalController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLocalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLocal
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Codigo")
        {
            var appDbContext = _context.Local.Include(l => l.Link);
            var resultado = appDbContext.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Codigo.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }

        // GET: Admin/AdminLocal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .Include(l => l.Link)
                .FirstOrDefaultAsync(m => m.LocalId == id);
            if (local == null)
            {
                return NotFound();
            }
            ViewData["LinkId"] = new SelectList(_context.Link, "LinkId", "Nome", local.LinkId);
            return View(local);
        }

        // GET: Admin/AdminLocal/Create
        public IActionResult Create()
        {
            ViewData["LinkId"] = new SelectList(_context.Link, "LinkId", "Nome");
            return View();
        }

        // POST: Admin/AdminLocal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalId,LinkId,Codigo,Nome,Endereco,Numero,Cidade,Estado,Cep,Telefone,Contato")] Local local)
        {
            if (ModelState.IsValid)
            {

                var appDbContext = _context.Local.Include(l => l.Link);
                var resultado = appDbContext.AsNoTracking().AsQueryable();

                resultado = resultado.Where(p => p.Codigo.ToUpper().Equals(local.Codigo.ToUpper()));


                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Local já existe!!!!");
                }
                else
                {
                    _context.Add(local);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                 new LogAuditoria
                 {
                     Usuario = User.Identity.Name,
                     Modulo = "Local",
                     Detalhe = String.Concat("Criou -> ", local.Nome),
                     Data = DateTime.Now
                 });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
                ViewData["LinkId"] = new SelectList(_context.Link, "LinkId", "Nome", local.LinkId);
                return View(local);
            }
        
        // GET: Admin/AdminLocal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var local = await _context.Local.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            ViewData["LinkId"] = new SelectList(_context.Link, "LinkId", "Nome", local.LinkId);
            return View(local);
        }

        // POST: Admin/AdminLocal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocalId,LinkId,Codigo,Nome,Endereco,Numero,Cidade,Estado,Cep,Telefone,Contato")] Local local)
        {
            if (id != local.LocalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                    {
                        _context.Update(local);
                        await _context.SaveChangesAsync();

                        _context.LogAuditoria.Add(
                 new LogAuditoria
                 {
                     Usuario = User.Identity.Name,
                     Modulo = "Local",
                     Detalhe = String.Concat("Editou -> ", local.Nome),
                     Data = DateTime.Now
                 });
                        _context.SaveChanges();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LocalExists(local.LocalId))
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
            
            ViewData["LinkId"] = new SelectList(_context.Link, "LinkId", "Nome", local.LinkId);
            return View(local);
        }

        // GET: Admin/AdminLocal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Local == null)
            {
                return NotFound();
            }

            var local = await _context.Local
                .Include(l => l.Link)
                .FirstOrDefaultAsync(m => m.LocalId == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Admin/AdminLocal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Local == null)
            {
                return Problem("Entity set 'AppDbContext.Local'  is null.");
            }
            var local = await _context.Local.FindAsync(id);
            if (local != null)
            {
                _context.Local.Remove(local);
            }
            
            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
            new LogAuditoria
            {
               Usuario = User.Identity.Name,
               Modulo = "Local",
               Detalhe = String.Concat("Excluiu -> ", local.Nome),
               Data = DateTime.Now
            });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(int id)
        {
          return _context.Local.Any(e => e.LocalId == id);
        }
    }
}
