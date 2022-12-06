using Microsoft.AspNetCore.Mvc;

namespace OrionTM_Web.Controllers
{
    public class EnvioController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

    }
}
