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

        public async Task<IActionResult> Index(string filter, string isIniciando, string IsExecutando, string IsOk, string IsErro, int pageindex = 1, string sort = "-DataAtualizacao")
        {

            if (User.Identity.IsAuthenticated)
            {
            var appDbContext = _context.Script.Include(t => t.Terminal).Include(t => t.Status);

            var resultado = appDbContext.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Terminal.Codigo.ToUpper().Contains(filter.ToUpper()));
            }
                //// incluir os filtros
                ///

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
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(1) || p.StatusId.Equals(2));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (!string.IsNullOrWhiteSpace(IsExecutando)) && (string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(1) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }

                if ((!string.IsNullOrWhiteSpace(isIniciando)) && (string.IsNullOrWhiteSpace(IsExecutando)) && (!string.IsNullOrWhiteSpace(IsOk)) && (!string.IsNullOrWhiteSpace(IsErro)))
                {
                    resultado = resultado.Where(p => p.StatusId.Equals(0) || p.StatusId.Equals(2) || p.StatusId.Equals(3) || p.StatusId.Equals(4));
                }




            var model = await PagingList.CreateAsync(resultado, 8, pageindex, sort, "TerminalId");
            model.RouteValue = new RouteValueDictionary { { "filter", filter }, { "isIniciando", isIniciando }, { "IsExecutando", IsExecutando }, { "IsOk", IsOk }, { "IsErro", IsErro } };
            return View(model);
            }
            return RedirectToAction("Login", "Account");
        }



        public IActionResult ComandoPorTerminais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.Comandos = _context.Comando;
                ComandosEnvioViewModel.Script = _context.Script;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComandoPorTerminais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Comandos = _context.Comando;
            ComandosEnvioViewModel.Terminais = _context.Terminal;


            List<string> Comandos_from = form["Comandos_from"].ToList();
            List<string> terminais_from = form["terminais_from"].ToList();

            foreach (var ComandoId in Comandos_from)
            {
                var resultScript = ComandosEnvioViewModel.Comandos.Where(p => p.ComandoId.Equals(Convert.ToInt32(ComandoId)));

                var strConteuto = "";
                var NomeComando = "";
                var NomeTerminal = "";


                foreach (var l in resultScript)
                {
                    strConteuto = l.Caminho;
                    NomeComando = l.Nome;
                }

                    //ADICIONA NOVOS ITENS A LISTA
                    foreach (var item in terminais_from)
                {

                    var resultTerminal = ComandosEnvioViewModel.Terminais.Where(p => p.TerminalId.Equals(Convert.ToInt32(item)));
                    foreach (var l in resultTerminal)
                    {
                        NomeTerminal = l.Codigo;
                    }


                    Script s = new Script();

                    s.TerminalId = Convert.ToInt32(item);
                    s.NomeComando = NomeComando;
                    s.StatusId = 0;
                    s.ScrConteudo = strConteuto;
                    s.DataCadastro = DateTime.Now;
                    s.DataAtualizacao = DateTime.Now;
                    s.StrLog = "";
                    _context.Script.Add(s);
                    _context.SaveChanges();

                    _context.LogAuditoria.Add(
                        new LogAuditoria
                        {
                            Usuario = User.Identity.Name,
                            Modulo = "Comandos",
                            Detalhe = String.Concat("Script = " + NomeComando + " / Terminal = " + NomeTerminal),
                            Data = DateTime.Now
                        });
                    _context.SaveChanges();




                }

               

            }
            if (Comandos_from.Count == 0 || terminais_from.Count == 0)
            {
                return RedirectToAction("ComandoPorTerminais", "Comandos");
            }
            return RedirectToAction("Index", "Comandos");
        }


        public IActionResult ComandoPorLocais()
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
        public async Task<IActionResult> ComandoPorLocais(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Comandos = _context.Comando;
                        
            List<string> Comandos_from = form["Comandos_from"].ToList();
            List<string> Locais_from = form["Locais_from"].ToList();

            var strConteuto = "";
            var NomeComando = "";

            foreach (var ComandoId in Comandos_from)
            {

                var resultScript = ComandosEnvioViewModel.Comandos.Where(p => p.ComandoId.Equals(Convert.ToInt32(ComandoId)));


                foreach (var l in resultScript)
                {
                    strConteuto = l.Caminho;
                    NomeComando = l.Nome;
                }


                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Locais_from)
                {
                    ComandosEnvioViewModel.Terminais = _context.Terminal;
                    ComandosEnvioViewModel.Terminais = ComandosEnvioViewModel.Terminais.Where(p => p.LocalId == Convert.ToInt32(item)).ToList();

                    foreach (var terminal in ComandosEnvioViewModel.Terminais)
                    {
                        Script s = new Script();
                        s.TerminalId = Convert.ToInt32(terminal.TerminalId);
                        s.NomeComando = NomeComando;
                        s.StatusId = 0;
                        s.ScrConteudo = strConteuto;
                        s.DataCadastro = DateTime.Now;
                        s.DataAtualizacao = DateTime.Now;
                        s.StrLog = "";
                        _context.Script.Add(s);
                        _context.SaveChanges();

                        _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Comandos",
                           Detalhe = String.Concat("Script = " + NomeComando + " / Terminal = " + terminal.Codigo),
                           Data = DateTime.Now
                       });
                        _context.SaveChanges();

                    }
                    

                }
            }

            if (Comandos_from.Count == 0 || Locais_from.Count == 0)
            {
                return RedirectToAction("ComandoPorLocais", "Comandos");
            }

            return RedirectToAction("Index", "Comandos");
        }


        public IActionResult ComandoPorLista()
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
        public async Task<IActionResult> ComandoPorLista(int? id, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Comandos = _context.Comando;

            List<string> Comandos_from = form["Comandos_from"].ToList();
            List<string> Lista_from = form["Lista_from"].ToList();

            var strConteuto = "";
            var NomeComando = "";

            foreach (var ComandoId in Comandos_from)
            {
                var resultScript = ComandosEnvioViewModel.Comandos.Where(p => p.ComandoId.Equals(Convert.ToInt32(ComandoId)));

                foreach (var l in resultScript)
                {
                    strConteuto = l.Caminho;
                    NomeComando = l.Nome;
                }

                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Lista_from)
                {
                    ComandosEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio.Include(t => t.Terminal);
                    ComandosEnvioViewModel.DetalheListaEnvio = ComandosEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == Convert.ToInt32(item)).ToList();

                    foreach (var lista in ComandosEnvioViewModel.DetalheListaEnvio)
                    {

                        Script s = new Script();
                        s.TerminalId = Convert.ToInt32(lista.TerminalId);
                        s.NomeComando = NomeComando;
                        s.StatusId = 0;
                        s.ScrConteudo = strConteuto;
                        s.DataCadastro = DateTime.Now;
                        s.DataAtualizacao = DateTime.Now;
                        s.StrLog = "";
                        _context.Script.Add(s);
                        _context.SaveChanges();

                        _context.LogAuditoria.Add(
                      new LogAuditoria
                      {
                          Usuario = User.Identity.Name,
                          Modulo = "Comandos",
                          Detalhe = String.Concat("Script = " + NomeComando + " / Terminal = " + lista.Terminal.Codigo),
                          Data = DateTime.Now
                      });
                        _context.SaveChanges();
                    }
                   


                }
            }

            if (Comandos_from.Count == 0 || Lista_from.Count == 0)
            {
                return RedirectToAction("ComandoPorLista", "Comandos");
            }
            return RedirectToAction("Index", "Comandos");

        }






    }
}
