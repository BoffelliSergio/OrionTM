using Microsoft.AspNetCore.Mvc;

namespace OrionTM_Web.Controllers
{
    public class BuscaLogController : Controller
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
