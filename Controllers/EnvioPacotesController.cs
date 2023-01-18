using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Migrations;
using OrionTM_Web.Models;
using OrionTM_Web.ViewModels;
using ReflectionIT.Mvc.Paging;


using System.ComponentModel.Design;

namespace OrionTM_Web.Controllers
{
    
    public class EnvioPacotesController : Controller
    {

        private readonly AppDbContext _context;

        public EnvioPacotesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "DtAtualizacao")
        {

            if (User.Identity.IsAuthenticated)
            {

                var appDbContext = _context.FilaTasks.Include(t => t.Terminal).Include(t => t.Status).Include(t => t.Pacote).Include(t=> t.Tasks);

            var resultado = appDbContext.AsNoTracking().AsQueryable();

            // somente executar comandos
            resultado = resultado.Where(p => p.TasksId.Equals(Convert.ToInt32(7)));

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



        public IActionResult EnvioPacotesPorTerminais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.Pacote = _context.Pacote;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnvioPacotesPorTerminais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Pacotes_from = form["Pacotes_from"].ToList();
            List<string> terminais_from = form["terminais_from"].ToList();

            foreach (var PacoteId in Pacotes_from)
            {
                  //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in terminais_from)
                {
                    FilaTasks f = new FilaTasks();
                    f.TerminalId = Convert.ToInt32(item);
                    f.DtAtualizacao = DateTime.Now;
                    f.TasksId = 7;
                    f.ComandoId = 0;
                    f.LogId = 0;
                    f.PacoteId = Convert.ToInt32(PacoteId);
                    f.StatusId = 0;
                    _context.FilaTasks.Add(f);
                    _context.SaveChanges();
                }

                _context.LogAuditoria.Add(
                        new LogAuditoria
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "Pacotes",
                            Detalhe = String.Concat("Envio Pacotes Por Termianal" ),
                            Data = DateTime.UtcNow
                        });
                _context.SaveChanges();

            }

            return RedirectToAction("Index", "EnvioPacotes");
        }


        public IActionResult EnvioPacotesPorLocais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Locais = _context.Local;
                ComandosEnvioViewModel.Pacote = _context.Pacote;
                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnvioPacotesPorLocais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Pacotes_from = form["Pacotes_from"].ToList();
            List<string> Locais_from = form["Locais_from"].ToList();

            foreach (var PacoteId in Pacotes_from)
            {
                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Locais_from)
                {
                    ComandosEnvioViewModel.Terminais = _context.Terminal;
                    ComandosEnvioViewModel.Terminais = ComandosEnvioViewModel.Terminais.Where(p => p.LocalId == Convert.ToInt32(item)).ToList();

                    foreach (var terminal in ComandosEnvioViewModel.Terminais)
                    {

                        FilaTasks f = new FilaTasks();
                        f.TerminalId = Convert.ToInt32(terminal.TerminalId);
                        f.DtAtualizacao = DateTime.Now;
                        f.TasksId = 7;
                        f.ComandoId = 0;
                        f.LogId = 0;
                        f.PacoteId = Convert.ToInt32(PacoteId);
                        f.StatusId = 0;
                        _context.FilaTasks.Add(f);
                        _context.SaveChanges();
                    }
                    _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Pacotes",
                           Detalhe = String.Concat("Envio Pacotes Por Local"),
                           Data = DateTime.UtcNow
                       });
                    _context.SaveChanges();

                }
            }

            return RedirectToAction("Index", "EnvioPacotes");
        }


        public IActionResult EnvioPacotesPorLista()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.ListaEnvio = _context.ListaEnvio;
                ComandosEnvioViewModel.Pacote = _context.Pacote;
                return View(ComandosEnvioViewModel);

            }
            return RedirectToAction("Login", "Account");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnvioPacotesPorLista(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Pacotes_from = form["Pacotes_from"].ToList();
            List<string> Lista_from = form["Lista_from"].ToList();

            foreach (var PacoteId in Pacotes_from)
            {
                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Lista_from)
                {
                    ComandosEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio;
                    ComandosEnvioViewModel.DetalheListaEnvio = ComandosEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == Convert.ToInt32(item)).ToList();

                    foreach (var lista in ComandosEnvioViewModel.DetalheListaEnvio)
                    {

                        FilaTasks f = new FilaTasks();
                        f.TerminalId = Convert.ToInt32(lista.TerminalId);
                        f.DtAtualizacao = DateTime.Now;
                        f.TasksId = 7;
                        f.ComandoId = 0;
                        f.LogId = 0;
                        f.PacoteId = Convert.ToInt32(PacoteId);
                        f.StatusId = 0;
                        _context.FilaTasks.Add(f);
                        _context.SaveChanges();

                    }
                    _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Comandos",
                           Detalhe = String.Concat("Envio Pacotes Por Lista"),
                           Data = DateTime.UtcNow
                       });
                    _context.SaveChanges();


                }
            }
            return RedirectToAction("Index", "EnvioPacotes");

        }






    }
}
