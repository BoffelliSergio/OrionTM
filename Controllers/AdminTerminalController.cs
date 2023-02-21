using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;



namespace OrionTM_Web.Controllers
{
   
    public class AdminTerminalController : Controller
    {
        private readonly AppDbContext _context;

        public AdminTerminalController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminTerminal
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Codigo")
        {
            var appDbContext = _context.Terminal.Include(t => t.Local).Include(t => t.Modelo);

            var resultado = appDbContext.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Codigo.ToUpper().Contains(filter.ToUpper())).OrderBy(l => l.Codigo);
            }



            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
        }

        // GET: Admin/AdminTerminal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal
                .Include(t => t.Local)
                .Include(t => t.Modelo)
                .FirstOrDefaultAsync(m => m.TerminalId == id);
            if (terminal == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "LocalId", "Nome", terminal.LocalId);
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "ModeloId", "Descricao", terminal.ModeloId);

            return View(terminal);
        }

        // GET: Admin/AdminTerminal/Create
        public IActionResult Create()
        {
            ViewData["LocalId"] = new SelectList(_context.Local, "LocalId", "Nome");
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "ModeloId", "Descricao");
            return View();
        }

        // POST: Admin/AdminTerminal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TerminalId,ModeloId,Codigo,LocalId,IP,DNS,DefaultGateway,DtAtualizaao,Vrs_Distribuida,Vrs_Instalada,Status")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                var dt = DateTime.Now;
                terminal.DtAtualizaao = dt;

                var appDbContext = _context.Terminal.Include(t => t.Local).Include(t => t.Modelo);

                var resultado = appDbContext.AsNoTracking().AsQueryable();

                resultado = resultado.Where(p => p.Codigo.ToUpper().Equals(terminal.Codigo.ToUpper()));

                if (resultado.Count() > 0)
                {
                    ModelState.AddModelError("Aviso", "Terminal já existe!!!!");

                }
                else
                {
                    terminal.Vrs_Distribuida = 0;
                    terminal.Vrs_Instalada = 0;
                    terminal.Status = 0;
                    _context.Add(terminal);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        Usuario = User.Identity.Name,
                        Modulo = "Terminais",
                        Detalhe = string.Concat("Criou -> ", terminal.Codigo),
                        Data = DateTime.Now
                    });
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));

                }

            }

            ViewData["LocalId"] = new SelectList(_context.Local, "LocalId", "Nome", terminal.LocalId);
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "ModeloId", "Descricao", terminal.ModeloId);
            return View(terminal);
        }

        // GET: Admin/AdminTerminal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal.FindAsync(id);
            if (terminal == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "LocalId", "Nome", terminal.LocalId);
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "ModeloId", "Descricao", terminal.ModeloId);
            return View(terminal);
        }

        // POST: Admin/AdminTerminal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TerminalId,ModeloId,Codigo,LocalId,IP,DNS,DefaultGateway,DtAtualizaao,Vrs_Distribuida,Vrs_Instalada,Status")] Terminal terminal)
        {
            if (id != terminal.TerminalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dt = DateTime.Now;
                terminal.DtAtualizaao = dt;


                _context.Update(terminal);
                await _context.SaveChangesAsync();

                _context.LogAuditoria.Add(
                   new LogAuditoria
                   {
                       Usuario = User.Identity.Name,
                       Modulo = "Terminais",
                       Detalhe = string.Concat("Editou -> ", terminal.Codigo),
                       Data = DateTime.Now
                   });
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LocalId"] = new SelectList(_context.Local, "LocalId", "Nome", terminal.LocalId);
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "ModeloId", "Descricao", terminal.ModeloId);
            return View(terminal);
        }

        // GET: Admin/AdminTerminal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal
                .Include(t => t.Local)
                .Include(t => t.Modelo)
                .FirstOrDefaultAsync(m => m.TerminalId == id);
            if (terminal == null)
            {
                return NotFound();
            }
            ViewData["LocalId"] = new SelectList(_context.Local, "LocalId", "Nome", terminal.LocalId);
            ViewData["ModeloId"] = new SelectList(_context.Modelo, "ModeloId", "Descricao", terminal.ModeloId);
            return View(terminal);
        }

        // POST: Admin/AdminTerminal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Terminal == null)
            {
                return Problem("Entity set 'AppDbContext.Terminal'  is null.");
            }
            var terminal = await _context.Terminal.FindAsync(id);
            if (terminal != null)
            {
                _context.Terminal.Remove(terminal);
            }

            await _context.SaveChangesAsync();
            _context.LogAuditoria.Add(
               new LogAuditoria
               {
                   Usuario = User.Identity.Name,
                   Modulo = "Terminais",
                   Detalhe = string.Concat("Excluiu -> ", terminal.Codigo),
                   Data = DateTime.Now
               });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool TerminalExists(int id)
        {
            return _context.Terminal.Any(e => e.TerminalId == id);
        }
    }
}
