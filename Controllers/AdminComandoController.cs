using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;

namespace OrionTM_Web.Controllers

{
   
   
    public class AdminComandoController : Controller
    {
        private readonly AppDbContext _context;

        public AdminComandoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminModelo
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {

            var resultado = _context.Comando.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 10, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);

        }


        // GET: Admin/AdminModelo/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComandoId,Nome,Descricao,Caminho")] Comando comando)
        {
            if (ModelState.IsValid)
            {
                var resultado = _context.Comando.AsNoTracking().AsQueryable();
                resultado = resultado.Where(p => p.Nome.ToUpper().Equals(comando.Nome.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Comando já existe!!!!");

                }
                else
                {
                    _context.Add(comando);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Comando",
                        Detalhe = string.Concat("Criou -> ", comando.Nome),
                        Data = DateTime.Now
                    });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(comando);
        }

        // GET: Admin/AdminModelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comando == null)
            {
                return NotFound();
            }

            var comando = await _context.Comando
                .FirstOrDefaultAsync(m => m.ComandoId == id);
            if (comando == null)
            {
                return NotFound();
            }

            return View(comando);

        }

        // GET: Admin/AdminModelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comando == null)
            {
                return NotFound();
            }

            var comando = await _context.Comando.FindAsync(id);
            if (comando == null)
            {
                return NotFound();
            }
            return View(comando);
        }

        // POST: Admin/AdminModelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComandoId,Nome,Descricao,Caminho")] Comando comando)
        {
            if (id != comando.ComandoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comando);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Comandos",
                      Detalhe = string.Concat("Editou -> ", comando.Nome),
                      Data = DateTime.Now
                  });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComandoExists(comando.ComandoId))
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
            return View(comando);
        }


        // GET: Admin/AdminModelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comando == null)
            {
                return NotFound();
            }

            var comando = await _context.Comando
                .FirstOrDefaultAsync(m => m.ComandoId == id);
            if (comando == null)
            {
                return NotFound();
            }

            return View(comando);
        }

        // POST: Admin/AdminModelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comando == null)
            {
                return Problem("Entity set 'AppDbContext.Log'  is null.");
            }
            var comando = await _context.Comando.FindAsync(id);
            if (comando != null)
            {
                _context.Comando.Remove(comando);
            }

            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Comandos",
                      Detalhe = string.Concat("Excluiu -> ", comando.Nome),
                      Data = DateTime.Now
                  });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ComandoExists(int id)
        {
            return _context.Comando.Any(e => e.ComandoId == id);
        }














    }
}
