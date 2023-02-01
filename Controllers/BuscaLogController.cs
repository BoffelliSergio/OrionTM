using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using OrionTM_Web.ViewModels;
using ReflectionIT.Mvc.Paging;


using System.ComponentModel.Design;

namespace OrionTM_Web.Controllers
{

    public class BuscaLogController : Controller
    {

        private readonly AppDbContext _context;

        public BuscaLogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string filter, string IsExecutando, string IsOk, string IsErro, int pageindex = 1, string sort = "DtAtualizacao")


        {
            if (User.Identity.IsAuthenticated)
            {

                var appDbContext = _context.FilaTasks.Include(t => t.Terminal).Include(t => t.Status).Include(t => t.Log);

            var resultado = appDbContext.AsNoTracking().AsQueryable();

            // somente executar comandos
            resultado = resultado.Where(p => p.TasksId.Equals(Convert.ToInt32(3)));

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Terminal.Codigo.ToUpper().Contains(filter.ToUpper()));
            }

            // exec ok err
            if ((!string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(6) || p.StatusId.Equals(5) || p.StatusId.Equals(0) || p.StatusId.Equals(2));
            }

            //ok err
            if ((string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(6) || p.StatusId.Equals(5));
            }

            //exec err
            if ((!string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(5) || p.StatusId.Equals(0) || p.StatusId.Equals(2));
            }

            //exec ok
            if ((!string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(6) || p.StatusId.Equals(0) || p.StatusId.Equals(2));
            }

            //exec
            if ((!string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(2));
            }

            //ok
            if ((string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(6));
            }

            //err
            if ((string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
            {
                resultado = resultado.Where(p => p.StatusId.Equals(5));
            }

            var model = await PagingList.CreateAsync(resultado, 8, pageindex, sort, "TerminalId");
            model.RouteValue = new RouteValueDictionary { { "filter", filter }, { "IsExecutando", IsExecutando }, { "IsOk", IsOk }, { "IsErro", IsErro } };
            return View(model);
        }
         return RedirectToAction("Login", "Account");
    }


    public IActionResult BuscaPorTerminais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.Log = _context.Log;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscaPorTerminais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Logs_from = form["Logs_from"].ToList();
            List<string> terminais_from = form["terminais_from"].ToList();

            foreach (var LogId in Logs_from)
            {
                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in terminais_from)
                {
                    FilaTasks f = new FilaTasks();

                    f.TerminalId = Convert.ToInt32(item);
                    f.DtAtualizacao = DateTime.Now;
                    f.TasksId = 3;
                    f.ComandoId = 0;
                    f.LogId = Convert.ToInt32(LogId); 
                    f.PacoteId = 0;
                    f.StatusId = 0;
                    _context.FilaTasks.Add(f);
                    _context.SaveChanges();
                }
            }

            _context.LogAuditoria.Add(
                      new LogAuditoria
                      {
                          Usuario = User.Identity.Name,
                          Modulo = "Busca Logs",
                          Detalhe = String.Concat("Busca Por Termianal"),
                          Data = DateTime.UtcNow
                      });
            _context.SaveChanges();

            return RedirectToAction("Index", "BuscaLog");

        }

        public IActionResult BuscaPorLocais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Locais = _context.Local;
                ComandosEnvioViewModel.Log = _context.Log;
                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscaPorLocais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Logs_from = form["Logs_from"].ToList();
            List<string> Locais_from = form["Locais_from"].ToList();

            foreach (var LogId in Logs_from)
            {
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
                        l.TasksId = 3;
                        l.ComandoId = 0;
                        l.LogId = Convert.ToInt32(LogId);
                        l.PacoteId = 0;
                        l.StatusId = 0;
                        _context.FilaTasks.Add(l);
                        _context.SaveChanges();

                    }
                    _context.LogAuditoria.Add(
                     new LogAuditoria
                     {
                         Usuario = User.Identity.Name,
                         Modulo = "Busca Logs",
                         Detalhe = String.Concat("Busca Por Termianal"),
                         Data = DateTime.UtcNow
                     });
                    _context.SaveChanges();

                }
            }

            return RedirectToAction("Index", "BuscaLog");
        }

        public IActionResult BuscaPorLista()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.ListaEnvio = _context.ListaEnvio;
                ComandosEnvioViewModel.Log = _context.Log;
                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscaPorLista(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Logs_from = form["Logs_from"].ToList();
            List<string> Lista_from = form["Lista_from"].ToList();

            foreach (var LogId in Logs_from)
            {
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
                        l.TasksId = 3;
                        l.ComandoId = 0;
                        l.LogId = Convert.ToInt32(LogId); 
                        l.PacoteId = 0;
                        l.StatusId = 0;
                        _context.FilaTasks.Add(l);
                        _context.SaveChanges();

                    }

                    _context.LogAuditoria.Add(
                     new LogAuditoria
                     {
                         Usuario = User.Identity.Name,
                         Modulo = "Busca Logs",
                         Detalhe = String.Concat("Busca Por Termianal"),
                         Data = DateTime.UtcNow
                     });
                    _context.SaveChanges();

                }
            }

            return RedirectToAction("Index", "BuscaLog");

        }

    }
}
