using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;

namespace OrionTM_Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Admin/AdminTerminal


        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Status(string filter, string IsOnLine, string IsOffLine , int pageindex = 1, string sort = "Codigo")
        {
           


            if (User.Identity.IsAuthenticated)
            {
             var appDbContext = _context.Terminal.Include(t => t.Local).Include(t => t.Modelo);

            var resultado = appDbContext.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Codigo.ToUpper().Contains(filter.ToUpper())).OrderBy(l => l.Codigo);
            }

            if( !string.IsNullOrWhiteSpace(IsOnLine) )
                {
                    resultado = resultado.Where(p => p.Status.Equals(1));
                }

            if (!string.IsNullOrWhiteSpace(IsOffLine))
                {
                    resultado = resultado.Where(p => p.Status.Equals(0));
                }
            

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } , { "IsOnLine",IsOnLine }  , { "IsOffLine", IsOffLine } };
            return View(model);
            }
            return RedirectToAction("Login", "Account");
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}