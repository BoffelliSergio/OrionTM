using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using OrionTM_Web.ViewModels;
using ReflectionIT.Mvc.Paging;


using System.ComponentModel.Design;

namespace OrionTM_Web.Controllers
{
    
    public class ResetsController : Controller
    {

        private readonly AppDbContext _context;

        public ResetsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "DtAtualizacao")
        {

            if (User.Identity.IsAuthenticated)
            {

                var appDbContext = _context.FilaTasks.Include(t => t.Terminal).Include(t => t.Status);

            var resultado = appDbContext.AsNoTracking().AsQueryable();

            // somente executar comandos
            resultado = resultado.Where(p => p.TasksId.Equals(Convert.ToInt32(6)));

            if (!string.IsNullOrWhiteSpace(filter))
            {
                    resultado = resultado.Where(p => p.Terminal.Codigo.ToUpper().Contains(filter.ToUpper()));
                }

            var model = await PagingList.CreateAsync(resultado, 8, pageindex, sort, "TerminalId");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);
            }
            return RedirectToAction("Login", "Account");
        }



        public IActionResult ResetPorTerminais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.Comandos = _context.Comando;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPorTerminais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> terminais_from = form["terminais_from"].ToList();

        
                  //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in terminais_from)
                {
                    FilaTasks f = new FilaTasks();

                    f.TerminalId = Convert.ToInt32(item);
                    f.DtAtualizacao = DateTime.Now;
                    f.TasksId = 6;
                    f.ComandoId = 0;
                    f.LogId = 0;
                    f.PacoteId = 0;
                    f.StatusId = 0;
                    _context.FilaTasks.Add(f);
                    _context.SaveChanges();
                }

                _context.LogAuditoria.Add(
                        new LogAuditoria
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "Reset",
                            Detalhe = String.Concat("Reset Por Termianal" ),
                            Data = DateTime.UtcNow
                        });
                _context.SaveChanges();


            return RedirectToAction("Index", "Resets");

        }


        public IActionResult ResetPorLocais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Locais = _context.Local;
                ComandosEnvioViewModel.Comandos = _context.Comando;
                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPorLocais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
         
            List<string> Locais_from = form["Locais_from"].ToList();

           
                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Locais_from)
                {
                    ComandosEnvioViewModel.Terminais = _context.Terminal;
                    ComandosEnvioViewModel.Terminais = ComandosEnvioViewModel.Terminais.Where(p => p.LocalId == Convert.ToInt32(item)).ToList();

                    foreach (var terminal in ComandosEnvioViewModel.Terminais)
                    {

                        FilaTasks l = new FilaTasks();
                        l.TerminalId = Convert.ToInt32(terminal.TerminalId);
                        l.DtAtualizacao = DateTime.Now;
                        l.TasksId = 6;
                        l.ComandoId = 0;
                        l.LogId = 0;
                        l.PacoteId = 0;
                        l.StatusId = 0;
                        _context.FilaTasks.Add(l);
                        _context.SaveChanges();
                    }
                    _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Reset",
                           Detalhe = String.Concat("Reset Por Local"),
                           Data = DateTime.UtcNow
                       });
                    _context.SaveChanges();

                }


            return RedirectToAction("Index", "Resets");
        }


        public IActionResult ResetPorLista()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.ListaEnvio = _context.ListaEnvio;
                ComandosEnvioViewModel.Comandos = _context.Comando;
                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPorLista(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Lista_from = form["Lista_from"].ToList();

                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Lista_from)
                {
                    ComandosEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio;
                    ComandosEnvioViewModel.DetalheListaEnvio = ComandosEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == Convert.ToInt32(item)).ToList();

                    foreach (var lista in ComandosEnvioViewModel.DetalheListaEnvio)
                    {

                        FilaTasks l = new FilaTasks();
                        l.TerminalId = Convert.ToInt32(lista.TerminalId);
                        l.DtAtualizacao = DateTime.Now;
                        l.TasksId = 6;
                        l.ComandoId = 0;
                        l.LogId = 0;
                        l.PacoteId = 0;
                        l.StatusId = 0;
                        _context.FilaTasks.Add(l);
                        _context.SaveChanges();

                    }
                    _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Comandos",
                           Detalhe = String.Concat("Reset Por Lista"),
                           Data = DateTime.UtcNow
                       });
                    _context.SaveChanges();
                    
                }

            return RedirectToAction("Index", "Resets");

        }






    }
}
