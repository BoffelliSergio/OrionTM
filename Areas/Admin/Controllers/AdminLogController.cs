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

    public class AdminLogController : Controller
    {
    private readonly AppDbContext _context;

    public AdminLogController(AppDbContext context)
    {
        _context = context;
    }

        // GET: Admin/AdminModelo
        public async Task<IActionResult> Index(string filter,  int pageindex = 1, string sort = "Nome")
        {

            var resultado = _context.Log.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
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
        public async Task<IActionResult> Create([Bind("LogId,Nome,Descricao,Caminho,TipoArquivo,DataMascara")] Log log)
        {
            if (ModelState.IsValid)
            {


                var resultado = _context.Log.AsNoTracking().AsQueryable();
                resultado = resultado.Where(p => p.Nome.ToUpper().Equals(log.Nome.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Log já existe!!!!");

                }
                else
                {
                    _context.Add(log);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Logs",
                        Detalhe = String.Concat("Criou -> ", log.Nome),
                        Data = DateTime.Now
                    });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(log);
        }


        // GET: Admin/AdminModelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Log == null)
            {
                return NotFound();
            }

            var modelo = await _context.Log
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);

        }

        // GET: Admin/AdminModelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Log == null)
            {
                return NotFound();
            }

            var modelo = await _context.Log.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("LogId,Nome,Descricao,Caminho,TipoArquivo,DataMascara")] Log log)
        {
            if (id != log.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(log);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Logs",
                      Detalhe = String.Concat("Editou -> ", log.Nome),
                      Data = DateTime.Now
                  });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogExists(log.LogId))
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
            return View(log);
        }


        // GET: Admin/AdminModelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Log == null)
            {
                return NotFound();
            }

            var log = await _context.Log
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Admin/AdminModelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Log == null)
            {
                return Problem("Entity set 'AppDbContext.Log'  is null.");
            }
            var log = await _context.Log.FindAsync(id);
            if (log != null)
            {
                _context.Log.Remove(log);
            }

            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Logs",
                      Detalhe = String.Concat("Excluiu -> ", log.Nome),
                      Data = DateTime.Now
                  });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }




        private bool LogExists(int id)
        {
            return _context.Log.Any(e => e.LogId == id);
        }


    }
}
