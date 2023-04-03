using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;

namespace OrionTM_Web.Controllers
{
    
   
    public class AdminPacoteController : Controller
    {
        private readonly AppDbContext _context;

        public AdminPacoteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminModelo
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {

            var resultado = _context.Pacote.AsNoTracking().AsQueryable();
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

        // POST: Admin/AdminModelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacoteId,Nome,Descricao,Caminho,Versao,Prod")] Pacote pacote)
        {
            if (ModelState.IsValid)
            {
                var resultado = _context.Modelo.AsNoTracking().AsQueryable();
                resultado = resultado.Where(p => p.Nome.ToUpper().Equals(pacote.Nome.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Pacote já existe!!!!");

                }
                else
                {

                    pacote.Nome = pacote.Nome + ".zip";
                    pacote.Caminho = pacote.Nome;

                    _context.Add(pacote);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Modelos",
                        Detalhe = string.Concat("Criou -> ", pacote.Nome),
                        Data = DateTime.Now
                    });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(pacote);
        }


        // GET: Admin/AdminModelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacote == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote.FindAsync(id);
            if (pacote == null)
            {
                return NotFound();
            }
            return View(pacote);
        }

        // POST: Admin/AdminModelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacoteId,Nome,Descricao,Caminho,Versao,Prod")] Pacote pacote)
        {
            if (id != pacote.PacoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pacote.Nome = pacote.Nome ;
                    pacote.Caminho = pacote.Nome;
                    _context.Update(pacote);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Pacotes",
                      Detalhe = string.Concat("Editou -> ", pacote.Nome),
                      Data = DateTime.Now
                  });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacoteExists(pacote.PacoteId))
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
            return View(pacote);
        }

        // GET: Admin/AdminModelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacote == null)
            {
                return NotFound();
            }

            var pacote = await _context.Pacote
                .FirstOrDefaultAsync(m => m.PacoteId == id);
            if (pacote == null)
            {
                return NotFound();
            }

            return View(pacote);
        }

        // POST: Admin/AdminModelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacote == null)
            {
                return Problem("Entity set 'AppDbContext.Modelo'  is null.");
            }
            var pacote = await _context.Pacote.FindAsync(id);
            if (pacote != null)
            {
                _context.Pacote.Remove(pacote);
            }

            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                  new LogAuditoria
                  {
                      Usuario = User.Identity.Name,
                      Modulo = "Pacotes",
                      Detalhe = string.Concat("Excluiu -> ", pacote.Nome),
                      Data = DateTime.Now
                  });
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PacoteExists(int id)
        {
            return _context.Pacote.Any(e => e.PacoteId == id);
        }

    }
}
