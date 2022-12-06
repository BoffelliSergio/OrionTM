using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using ReflectionIT.Mvc.Paging;
using OrionTM_Web.Models;
using OrionTM_Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrionTM_Web.Controllers
{
    public class ListaEnvioController : Controller
    {
        private readonly AppDbContext _context;

        public ListaEnvioController(AppDbContext context)
        {
            _context = context;
        }   

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.ListaEnvio.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.ToUpper().Contains(filter.ToUpper()));
            }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };


            return View(model);

        }

        public  IActionResult Terminais(int? id)
        {

            var detalhesEnvioViewModel = new DetalhesEnvioViewModel();

            
            detalhesEnvioViewModel.ListaEnvio = _context.ListaEnvio;
            detalhesEnvioViewModel.ListaEnvio = _context.ListaEnvio.Where(p => p.ListaEnvioId == id);

            detalhesEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio;
            detalhesEnvioViewModel.DetalheListaEnvio = detalhesEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == id);
            
            detalhesEnvioViewModel.Terminais = _context.Terminal;


            return View(detalhesEnvioViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Terminais(string ids)
        {

            var detalhesEnvioViewModel = new DetalhesEnvioViewModel();



            return RedirectToAction(nameof(Index));
        }


            // GET: Admin/AdminLinks/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ListaEnvio == null)
            {
                return NotFound();
            }

            var link = await _context.ListaEnvio
                .FirstOrDefaultAsync(m => m.ListaEnvioId == id);
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
            if (_context.ListaEnvio == null)
            {
                return Problem("Entity set 'AppDbContext.Link'  is null.");
            }
            var listaEnvio = await _context.ListaEnvio.FindAsync(id);
            if (listaEnvio != null)
            {
                _context.ListaEnvio.Remove(listaEnvio);
            }

            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "ListaEnvio",
                           Detalhe = String.Concat("Excluiu -> ", listaEnvio.Nome),
                           Data = DateTime.UtcNow
                       });
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        // GET: Admin/AdminLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ListaEnvio == null)
            {
                return NotFound();
            }

            var link = await _context.ListaEnvio.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return View(link);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListaEnvioId,Nome,Descricao")] ListaEnvio ListaEnvio)
        {
            if (id != ListaEnvio.ListaEnvioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ListaEnvio);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                        new LogAuditoria
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "ListaEnvio",
                            Detalhe = String.Concat("Editou -> ", ListaEnvio.Nome),
                            Data = DateTime.UtcNow
                        });
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaEnvioExists(ListaEnvio.ListaEnvioId))
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

            return View(ListaEnvio);
        }


        // GET: Admin/AdminModelo/Create
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListaEnvioId,Nome,Descricao")] ListaEnvio listaEnvio)
        {
            if (ModelState.IsValid)
            {
                var resultado = _context.ListaEnvio.AsNoTracking().AsQueryable();
                resultado = resultado.Where(p => p.Nome.ToUpper().Equals(listaEnvio.Nome.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Lista de Envios já existe!!!!");

                }
                else
                {
                    _context.Add(listaEnvio);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Lista de Envios",
                        Detalhe = String.Concat("Criou -> ", listaEnvio.Nome),
                        Data = DateTime.UtcNow
                    });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(listaEnvio);
        }





        private bool ListaEnvioExists(int id)
        {
            return _context.ListaEnvio.Any(e => e.ListaEnvioId == id);
        }

    }
}
