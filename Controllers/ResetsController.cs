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
        public async Task<IActionResult> Index(string filter, string isIniciando, string IsExecutando, string IsOk, string IsErro, int pageindex = 1, string sort = "-DataAtualizacao")
        {
            if (User.Identity.IsAuthenticated)
                {
                    var appDbContext = _context.Reset.Include(t => t.Terminal).Include(t => t.Status);

                    var resultado = appDbContext.AsNoTracking().AsQueryable();


                if (!string.IsNullOrWhiteSpace(filter))
                {
                    resultado = resultado.Where(p => p.Terminal.Codigo.ToUpper().Contains(filter.ToUpper()));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0));
                }

                if ((string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(1));
                }

                if ((string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(2));
                }

                if ((string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(1));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(2));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }

                if ((string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(1) || p.StatusId.Equals(2));
                }

                if ((string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(1) || p.StatusId.Equals(2) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }
            
                if ((string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(2) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }
                
                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(1) || p.StatusId.Equals(2) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(1) || p.StatusId.Equals(2) );
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(1)  || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0)  || p.StatusId.Equals(2) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }


                var model = await PagingList.CreateAsync(resultado, 8, pageindex, sort, "Terminal");
                    model.RouteValue = new RouteValueDictionary { { "filter", filter }, { "isIniciando", isIniciando }, { "IsExecutando", IsExecutando }, { "IsOk", IsOk }, { "IsErro", IsErro } };
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
                ComandosEnvioViewModel.Reset = _context.Reset;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPorTerminais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                       
            List<string> terminais_from = form["terminais_from"].ToList();
            List<string> Resets_from = form["Resets_from"].ToList();


            foreach (var TipoReset in Resets_from)
            {

                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in terminais_from)
                {
                    Reset f = new Reset();
                    f.TerminalId = Convert.ToInt32(item);
                    f.StatusId = 0;
                    f.TipoReset = Convert.ToInt32(TipoReset);
                    f.DataCadastro = DateTime.Now;
                    f.DataAtualizacao = DateTime.Now;
                    _context.Reset.Add(f);
                    _context.SaveChanges();
                }

                _context.LogAuditoria.Add(
                        new LogAuditoria
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "Reset",
                            Detalhe = String.Concat("Reset Por Termianal"),
                            Data = DateTime.UtcNow
                        });
                _context.SaveChanges();
            }


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
            List<string> Resets_from = form["Resets_from"].ToList();

            foreach (var TipoReset in Resets_from)
            {
                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Locais_from)
                {
                    ComandosEnvioViewModel.Terminais = _context.Terminal;
                    ComandosEnvioViewModel.Terminais = ComandosEnvioViewModel.Terminais.Where(p => p.LocalId == Convert.ToInt32(item)).ToList();

                    foreach (var terminal in ComandosEnvioViewModel.Terminais)
                    {

                        Reset f = new Reset();
                        f.TerminalId = Convert.ToInt32(terminal.TerminalId);
                        f.StatusId = 0;
                        f.TipoReset = Convert.ToInt32(TipoReset);
                        f.DataCadastro = DateTime.Now;
                        f.DataAtualizacao = DateTime.Now;
                        _context.Reset.Add(f);
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
            List<string> Resets_from = form["Resets_from"].ToList();

            {
                foreach (var TipoReset in Resets_from)
                {

                    //ADICIONA NOVOS ITENS A LISTA
                    foreach (var item in Lista_from)
                    {
                        ComandosEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio;
                        ComandosEnvioViewModel.DetalheListaEnvio = ComandosEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == Convert.ToInt32(item)).ToList();

                        foreach (var lista in ComandosEnvioViewModel.DetalheListaEnvio)
                        {

                            Reset f = new Reset();
                            f.TerminalId = Convert.ToInt32(lista.TerminalId);
                            f.StatusId = 0;
                            f.TipoReset = Convert.ToInt32(TipoReset);
                            f.DataCadastro = DateTime.Now;
                            f.DataAtualizacao = DateTime.Now;
                            _context.Reset.Add(f);
                            _context.SaveChanges();

                        }
                        _context.LogAuditoria.Add(
                           new LogAuditoria
                           {
                               Usuario = User.Identity.Name,
                               Modulo = "Reset",
                               Detalhe = String.Concat("Reset Por Lista"),
                               Data = DateTime.UtcNow
                           });
                        _context.SaveChanges();

                    }
                }
            }

            return RedirectToAction("Index", "Resets");

        }






    }
}
