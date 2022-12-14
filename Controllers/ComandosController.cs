using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Models;
using OrionTM_Web.ViewModels;
using ReflectionIT.Mvc.Paging;
using System.ComponentModel.Design;

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
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.FilaTasks = _context.FilaTasks;

                foreach (var terminal in _context.FilaTasks)
                {
                    
                }

                    return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }



        public IActionResult EnvioPorTerminais()
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
        public async Task<IActionResult> EnvioPorTerminais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Comandos_from = form["Comandos_from"].ToList();
            List<string> terminais_from = form["terminais_from"].ToList();

            foreach (var ComandoId in Comandos_from)
            {
                  //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in terminais_from)
                {
                    FilaTasks f = new FilaTasks();

                    f.TerminalId = Convert.ToInt32(item);
                    f.DtAtualizacao = DateTime.Now;
                    f.Task = 5;
                    f.TaskID = Convert.ToInt32(ComandoId);
                    f.Status = 0;
                    _context.FilaTasks.Add(f);
                    _context.SaveChanges();
                }
            }

            // recarrega os dados

            ComandosEnvioViewModel.Terminais = _context.Terminal;
            ComandosEnvioViewModel.Comandos = _context.Comando;
            return View(ComandosEnvioViewModel);
            
        }


        public IActionResult EnvioPorLocais()
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
        public async Task<IActionResult> EnvioPorLocais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Comandos_from = form["Comandos_from"].ToList();
            List<string> Locais_from = form["Locais_from"].ToList();

            foreach (var ComandoId in Comandos_from)
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
                        l.Task = 5;
                        l.TaskID = Convert.ToInt32(ComandoId);
                        l.Status = 0;
                        _context.FilaTasks.Add(l);
                        _context.SaveChanges();

                    }
                }
            }

            // recarrega os dados

            ComandosEnvioViewModel.Comandos = _context.Comando;
            ComandosEnvioViewModel.Locais = _context.Local;
            return View(ComandosEnvioViewModel);
        }


        public IActionResult EnvioPorLista()
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
        public async Task<IActionResult> EnvioPorLista(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Comandos_from = form["Comandos_from"].ToList();
            List<string> Lista_from = form["Lista_from"].ToList();

            foreach (var ComandoId in Comandos_from)
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
                        l.Task = 5;
                        l.TaskID = Convert.ToInt32(ComandoId);
                        l.Status = 0;
                        _context.FilaTasks.Add(l);
                        _context.SaveChanges();

                    }
                }
            }

            // recarrega os dados

            ComandosEnvioViewModel.Comandos = _context.Comando;
            ComandosEnvioViewModel.ListaEnvio = _context.ListaEnvio;
                ;
            return View(ComandosEnvioViewModel);

        }






    }
}
