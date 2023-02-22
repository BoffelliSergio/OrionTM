using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;

namespace OrionTM_Web.Controllers
{
    public class StatusTerminalController : Controller
    {
        private readonly GetStatusDBContext _dbContext;

        public StatusTerminalController(GetStatusDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Status()
        {
            var StatusTerminal = _dbContext.GetMyEntitiesFromStoredProcedure();
            return View(StatusTerminal);
        }
    }
}
