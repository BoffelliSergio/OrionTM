using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.ViewModels;

namespace OrionTM_Web.Controllers
{
    public class ComandosController : Controller
    {

        private readonly AppDbContext _context;

        public ComandosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();


                ComandosEnvioViewModel.ListaEnvio = _context.ListaEnvio;

                ComandosEnvioViewModel.Terminais = _context.Terminal;

                ComandosEnvioViewModel.Comandos = _context.Comando;

                ComandosEnvioViewModel.Locais = _context.Local;

                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }
    }
}
