using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrionTM_Web.Context;
using OrionTM_Web.Migrations;
using OrionTM_Web.Models;
using OrionTM_Web.ViewModels;
using ReflectionIT.Mvc.Paging;


using System.ComponentModel.Design;
using System.Linq;

namespace OrionTM_Web.Controllers
{
    
    public class EnvioPacotesController : Controller
    {

        private readonly AppDbContext _context;

        public EnvioPacotesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string filter, string isIniciando, string IsExecutando, string IsOk, string IsErro, int pageindex = 1, string sort = "-DataAtualizacao")
        {
           

            if (User.Identity.IsAuthenticated)
            {

            var appDbContext = _context.Download.Include(t => t.Terminal).Include(t => t.Status).Include(t => t.Pacote); 

            var resultado = appDbContext.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
                {
                     resultado = resultado.Where(p => p.Terminal.Codigo.ToUpper().Contains(filter.ToUpper()) );
                }

                //// incluir os filtros


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


        public IActionResult EnvioPacotesPorTerminais()
        {
            if (User.Identity.IsAuthenticated)
            {
                var ComandosEnvioViewModel = new ComandosEnvioViewModel();
                ComandosEnvioViewModel.Terminais = _context.Terminal;
                ComandosEnvioViewModel.Pacote = _context.Pacote;
                ComandosEnvioViewModel.Download = _context.Download;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnvioPacotesPorTerminais(int? id, string DataInstalacao, string HoraInstalacao, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Pacote = _context.Pacote;
            ComandosEnvioViewModel.Terminais = _context.Terminal;

            List<string> Pacotes_from = form["Pacotes_from"].ToList();
            List<string> terminais_from = form["terminais_from"].ToList();

            var pacoteId = 0;
            var NomePacote = "";
            var NomeTerminal = "";

            foreach (var PacoteId in Pacotes_from)
            {

                var resultPacote = ComandosEnvioViewModel.Pacote.Where(p => p.PacoteId.Equals(Convert.ToInt32(PacoteId)));

                foreach (var l in resultPacote)
                {
                    pacoteId = l.PacoteId;
                    NomePacote = l.Nome;
                }
                              

               if (HoraInstalacao is null || DataInstalacao is null)
                {
                    HoraInstalacao = "IMED";
                    DataInstalacao = "IMED";
                }
                else
                {
                    var dtDataInstalacao = DateTime.Parse(DataInstalacao);
                    DataInstalacao = dtDataInstalacao.ToString("dd/MM/yyyy");
                }

                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in terminais_from)
                {

                    var resultTerminal = ComandosEnvioViewModel.Terminais.Where(p => p.TerminalId.Equals(Convert.ToInt32(item)));
                    foreach (var l in resultTerminal)
                    {
                        NomeTerminal = l.Codigo;
                    }

                    Download d = new Download();
                    d.TerminalId = Convert.ToInt32(item);
                    d.StatusId = 0;
                    d.PacoteId = pacoteId;
                    d.DataInstalacao = DataInstalacao;
                    d.HoraInstalacao = HoraInstalacao;
                    d.DataCadastro = DateTime.Now;
                    d.DataAtualizacao = DateTime.Now;
                    d.StrLog = "";
                    _context.Download.Add(d);
                    _context.SaveChanges();


                    _context.LogAuditoria.Add(
                      new LogAuditoria
                      {
                          Usuario = User.Identity.Name,
                          Modulo = "Pacotes",
                           Detalhe = String.Concat("Pacote = " + NomePacote + " / Terminal =" + NomeTerminal),
                          Data = DateTime.Now
                      });
                    _context.SaveChanges();

                }

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
        public async Task<IActionResult> EnvioPacotesPorLocais(int? id, string DataInstalacao, string HoraInstalacao, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Pacote = _context.Pacote;

           
            List<string> Pacotes_from = form["Pacotes_from"].ToList();
            List<string> Locais_from = form["Locais_from"].ToList();
            var pacoteId = 0;
            var NomePacote = "";

            foreach (var PacoteId in Pacotes_from)
            {

                var resultPacote = ComandosEnvioViewModel.Pacote.Where(p => p.PacoteId.Equals(Convert.ToInt32(PacoteId)));

                foreach (var l in resultPacote)
                {
                    pacoteId = l.PacoteId;
                    NomePacote = l.Nome;

                }


                if (HoraInstalacao is null || DataInstalacao is null)
                {
                    HoraInstalacao = "IMED";
                    DataInstalacao = "IMED";
                }
                else
                {
                    var dtDataInstalacao = DateTime.Parse(DataInstalacao);
                    DataInstalacao = dtDataInstalacao.ToString("dd/MM/yyyy");
                }


                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Locais_from)
                {
                    ComandosEnvioViewModel.Terminais = _context.Terminal;
                    ComandosEnvioViewModel.Terminais = ComandosEnvioViewModel.Terminais.Where(p => p.LocalId == Convert.ToInt32(item)).ToList();

                    foreach (var terminal in ComandosEnvioViewModel.Terminais)
                    {
                        Download d = new Download();
                        d.TerminalId = Convert.ToInt32(terminal.TerminalId);
                        d.StatusId = 0;
                        d.PacoteId = pacoteId;
                        d.DataInstalacao = DataInstalacao;
                        d.HoraInstalacao = HoraInstalacao;
                        d.DataCadastro = DateTime.Now;
                        d.DataAtualizacao = DateTime.Now;
                        d.StrLog = "";
                        _context.Download.Add(d);
                        _context.SaveChanges();


                        _context.LogAuditoria.Add(
                       new LogAuditoria
                       {
                           Usuario = User.Identity.Name,
                           Modulo = "Pacotes",
                           Detalhe = String.Concat("Pacote = " + NomePacote + " / Terminal = " + terminal.Codigo),
                           Data = DateTime.Now
                       });
                        _context.SaveChanges();


                    }

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
        public async Task<IActionResult> EnvioPacotesPorLista(int? id, string DataInstalacao, string HoraInstalacao, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Pacote = _context.Pacote;

            
            List<string> Pacotes_from = form["Pacotes_from"].ToList();
            List<string> Lista_from = form["Lista_from"].ToList();
            var pacoteId = 0;
            var NomePacote = "";

            foreach (var PacoteId in Pacotes_from)
            {
                var resultPacote = ComandosEnvioViewModel.Pacote.Where(p => p.PacoteId.Equals(Convert.ToInt32(PacoteId)));

                foreach (var l in resultPacote)
                {
                    pacoteId = l.PacoteId;
                    NomePacote = l.Nome;
                }


                if (HoraInstalacao is null || DataInstalacao is null)
                {
                    HoraInstalacao = "IMED";
                    DataInstalacao = "IMED";
                }
                else
                {
                    var dtDataInstalacao = DateTime.Parse(DataInstalacao);
                    DataInstalacao = dtDataInstalacao.ToString("dd/MM/yyyy");
                }



                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Lista_from)
                {
                    ComandosEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio.Include(t => t.Terminal);
                    ComandosEnvioViewModel.DetalheListaEnvio = ComandosEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == Convert.ToInt32(item)).ToList();

                    foreach (var lista in ComandosEnvioViewModel.DetalheListaEnvio)
                    {

                        Download d = new Download();
                        d.TerminalId = Convert.ToInt32(lista.TerminalId);
                        d.StatusId = 0;
                        d.PacoteId = pacoteId;
                        d.DataInstalacao = DataInstalacao;
                        d.HoraInstalacao = HoraInstalacao;
                        d.DataCadastro = DateTime.Now;
                        d.DataAtualizacao = DateTime.Now;
                        d.StrLog = "";
                        _context.Download.Add(d);
                        _context.SaveChanges();


                      _context.LogAuditoria.Add(
                      new LogAuditoria
                      {
                          Usuario = User.Identity.Name,
                          Modulo = "Pacotes",
                          Detalhe = String.Concat("Pacote = " + NomePacote + " / Terminal = " + lista.Terminal.Codigo),
                          Data = DateTime.Now
                      });
                        _context.SaveChanges();



                    }
                   


                }
            }
            return RedirectToAction("Index", "EnvioPacotes");

        }





    }
}
