using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrionTM_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class LocaisController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
