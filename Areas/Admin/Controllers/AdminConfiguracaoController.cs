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
    public class AdminConfiguracaoController : Controller
    {
        private readonly AppDbContext _context;

        public AdminConfiguracaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminConfiguracao
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Campo")
        {
            var resultado = _context.Configuracao.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Campo.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Caampo");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }

        // GET: Admin/AdminConfiguracao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracao
                .FirstOrDefaultAsync(m => m.ConfiguracaoId == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }


        // GET: Admin/AdminConfiguracao/Details/5
        public async Task<IActionResult> LeConfig(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracao
                .FirstOrDefaultAsync(m => m.ConfiguracaoId == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            //return PartialView("_LeBanco", configuracao);
            return View(configuracao);
        }



        // GET: Admin/AdminConfiguracao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminConfiguracao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConfiguracaoId,Campo,Valor")] Configuracao configuracao)
        {
            if (ModelState.IsValid)
            {

                var resultado = _context.Configuracao.AsNoTracking().AsQueryable();
               
                resultado = resultado.Where(p => p.Campo.ToUpper().Equals(configuracao.Campo.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Configuração já existe!!!!");
                }
                else
                {
                    _context.Add(configuracao);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                   new LogAuditoria
                   {
                       Usuario = User.Identity.Name,
                       Modulo = "Configurações",
                       Detalhe = String.Concat("Criou -> ", configuracao.Campo),
                       Data = DateTime.UtcNow
                   });
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                    }
                }
            return View(configuracao);
        }

        // GET: Admin/AdminConfiguracao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }

            var configuracao = await _context.Configuracao.FindAsync(id);
            if (configuracao == null)
            {
                return NotFound();
            }
            return View(configuracao);
        }

        // POST: Admin/AdminConfiguracao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConfiguracaoId,Campo,Valor")] Configuracao configuracao)
        {
            if (id != configuracao.ConfiguracaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(configuracao);
                    await _context.SaveChangesAsync();
                    _context.LogAuditoria.Add(
              new LogAuditoria
              {
                  Usuario = User.Identity.Name,
                  Modulo = "Configurações",
                  Detalhe = String.Concat("Editou -> ", configuracao.Campo),
                  Data = DateTime.UtcNow
              });
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiguracaoExists(configuracao.ConfiguracaoId))
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
            return View(configuracao);
        }

        // GET: Admin/AdminConfiguracao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Configuracao == null)
            {
                return NotFound();
            }




            var configuracao = await _context.Configuracao
                .FirstOrDefaultAsync(m => m.ConfiguracaoId == id);
            if (configuracao == null)
            {
                return NotFound();
            }

            return View(configuracao);
        }

        // POST: Admin/AdminConfiguracao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Configuracao == null)
            {
                return Problem("Entity set 'AppDbContext.Configuracao'  is null.");
            }
            var configuracao = await _context.Configuracao.FindAsync(id);
            if (configuracao != null)
            {
                _context.Configuracao.Remove(configuracao);
            }
            
            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
            new LogAuditoria
            {
                Usuario = User.Identity.Name,
                Modulo = "Configurações",
                Detalhe = String.Concat("Excluiu -> ", configuracao.Campo),
                Data = DateTime.UtcNow
            });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

      




        private bool ConfiguracaoExists(int id)
        {
          return _context.Configuracao.Any(e => e.ConfiguracaoId == id);
        }





    }
}
