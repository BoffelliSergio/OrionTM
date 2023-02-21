using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using ReflectionIT.Mvc.Paging;


namespace OrionTM_Web.Controllers
{

   
   

    public class AdminLogAuditoriaController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLogAuditoriaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLinks
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "-Data")
        {
            var resultado = _context.LogAuditoria.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Detalhe.ToUpper().Contains(filter.ToUpper()));

            }

            //resultado  = resultado.OrderByDescending(p => p.Data);

            var model = await PagingList.CreateAsync(resultado, 11, pageindex, sort, "Modulo");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }
    }
}
