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

namespace OrionTM_Web.Controllers
{
   
   
    public class AdminLinksController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLinksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLinks
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.Link.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };


            return View(model);

        }

        // GET: Admin/AdminLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Link == null)
            {
                return NotFound();
            }

            var link = await _context.Link
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // GET: Admin/AdminLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminLinks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinkId,Nome,Capacidade")] Link link)
        {
            if (ModelState.IsValid)
            {
                var resultado = _context.Link.AsNoTracking().AsQueryable();

                resultado = resultado.Where(p => p.Nome.ToUpper().Equals(link.Nome.ToUpper()));


                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Link já existe!!!!");

                }
                else
                {

                    _context.Add(link);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                   new LogAuditoria
                   {
                       Usuario = User.Identity.Name,
                       Modulo = "Links",
                       Detalhe = string.Concat("Criou -> ", link.Nome),
                       Data = DateTime.Now
                   });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));

                }

            }
            return View(link);
        }

        // GET: Admin/AdminLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Link == null)
            {
                return NotFound();
            }

            var link = await _context.Link.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return View(link);
        }

        // POST: Admin/AdminLinks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinkId,Nome,Capacidade")] Link link)
        {
            if (id != link.LinkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(link);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                        new LogAuditoria
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "Links",
                            Detalhe = string.Concat("Editou -> ", link.Nome),
                            Data = DateTime.Now
                        });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkExists(link.LinkId))
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

            return View(link);
        }

        // GET: Admin/AdminLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Link == null)
            {
                return NotFound();
            }

            var link = await _context.Link
                .FirstOrDefaultAsync(m => m.LinkId == id);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // POST: Admin/AdminLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Link == null)
            {
                return Problem("Entity set 'AppDbContext.Link'  is null.");
            }
            var link = await _context.Link.FindAsync(id);
            if (link != null)
            {
                _context.Link.Remove(link);
            }

            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Links",
                           Detalhe = string.Concat("Excluiu -> ", link.Nome),
                           Data = DateTime.Now
                       });
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        private bool LinkExists(int id)
        {
            return _context.Link.Any(e => e.LinkId == id);
        }
    }
}
