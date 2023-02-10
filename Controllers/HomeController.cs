using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using ReflectionIT.Mvc.Paging;
using System.Diagnostics;
using OrionTM_Web.ViewModels;

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
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.Reset = _context.Reset;
                ComandosEnvioViewModel.UpLoadOnLine = _context.UpLoadOnLine;
                ComandosEnvioViewModel.Download= _context.Download;
                ComandosEnvioViewModel.Script = _context.Script;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
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

            //  ok err
            if ((!string.IsNullOrWhiteSpace(IsOnLine)) && (!string.IsNullOrWhiteSpace(IsOffLine)) )
                {
                    resultado = resultado.Where(p => p.Status.Equals(1) || p.Status.Equals(0) );
                }

            if ((string.IsNullOrWhiteSpace(IsOnLine)) && (!string.IsNullOrWhiteSpace(IsOffLine)))
                {
                    resultado = resultado.Where(p => p.Status.Equals(0) );
                }
                
                
            if ((!string.IsNullOrWhiteSpace(IsOnLine)) && (string.IsNullOrWhiteSpace(IsOffLine)))
                {
                    resultado = resultado.Where(p => p.Status.Equals(1));
                }

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } , { "IsOnLine",IsOnLine }  , { "IsOffLine", IsOffLine } };
            return View(model);
            }
            return RedirectToAction("Login", "Account");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}