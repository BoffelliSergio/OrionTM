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
        public async Task<IActionResult> Index(string filter, string isIniciando, string IsExecutando, string IsOk, string IsErro, int pageindex = 1, string sort = "-DataAtualizacao")


        {
            if (User.Identity.IsAuthenticated)
            {

                var appDbContext = _context.UpLoadOnLine.Include(t => t.Terminal).Include(t => t.Status);

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







                var model = await PagingList.CreateAsync(resultado, 8, pageindex, sort, "Terminal");
                model.RouteValue = new RouteValueDictionary { { "filter", filter }, { "isIniciando", isIniciando }, { "IsExecutando", IsExecutando }, { "IsOk", IsOk }, { "IsErro", IsErro } };
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
                ComandosEnvioViewModel.UpLoadOnLine = _context.UpLoadOnLine;
                ComandosEnvioViewModel.Log = _context.Log;
                return View(ComandosEnvioViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscaPorTerminais(int? id , string DataInicio , string DataFim, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Log = _context.Log;

            List<string> Logs_from = form["Logs_from"].ToList();
            List<string> terminais_from = form["terminais_from"].ToList();

            var NomeArquivo  = "";
            var PathArquivo = "";
            var TipoArquivo = "";
            var DataArquivo = "";
            var MascaraArquivo = "";
            var TipoUpload = "";

            foreach (var LogId in Logs_from)
            {
                              
             var   resultLog = ComandosEnvioViewModel.Log.Where(p => p.LogId.Equals(Convert.ToInt32(LogId)));
 
              foreach (var l in resultLog)
                {
                    NomeArquivo = l.Nome;
                    PathArquivo = l.Caminho;

                    if (l.TipoArquivo == "Pasta")
                    {
                        TipoArquivo = l.TipoArquivo;
                        TipoUpload = "ByFolder";
                    }
                    else
                    {
                        // bydate or byrange
                        if (l.TipoArquivo != "Pasta" && l.DataMascara is not null)
                        {
                            if (DataInicio is null)
                            {
                                var dt = DateTime.Now;
                                DataInicio = dt.ToString("dd/MM/yyyy");
                            }else
                            {
                                var dtDataInicio = DateTime.Parse(DataInicio);
                                DataInicio = dtDataInicio.ToString("dd/MM/yyyy");
                            }
                                                       
                           

                            if (DataFim is not null)
                            {
                                var dtDataFin = DateTime.Parse(DataFim);
                                DataFim = dtDataFin.ToString("dd/MM/yyyy");
                                MascaraArquivo = l.DataMascara;
                                TipoArquivo = l.TipoArquivo;
                                DataArquivo = DataInicio + "|" + DataFim;
                                TipoUpload = "ByRangeDate";
                            }
                            else
                            {
                                MascaraArquivo = l.DataMascara;
                                TipoArquivo = l.TipoArquivo;
                                DataArquivo = DataInicio;
                                TipoUpload = "ByDate";
                            }
                        }
                        else
                        {
                            TipoUpload = "ByName";
                            TipoArquivo = l.TipoArquivo;
                        }

                    }
                       
                }

                    //ADICIONA NOVOS ITENS A LISTA
                    foreach (var item in terminais_from)
                    {
                    //utilizando tabelas UpLoadOnline
                    UpLoadOnLine u = new UpLoadOnLine();
                    u.TerminalId = Convert.ToInt32(item); 
                    u.StatusId = 0;
                    u.NomeArquivo = NomeArquivo;
                    u.PathArquivo = PathArquivo;
                    u.TipoArquivo = TipoArquivo;
                    u.DataArquivo = DataArquivo;
                    u.MascaraArquivo = MascaraArquivo;
                    u.TipoUpload = TipoUpload;
                    u.DataCadastro = DateTime.Now;
                    u.DataAtualizacao = DateTime.Now;
                    u.StrLog = "";
                    _context.UpLoadOnLine.Add(u);
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
                ComandosEnvioViewModel.UpLoadOnLine = _context.UpLoadOnLine;
                ComandosEnvioViewModel.Locais = _context.Local;
                ComandosEnvioViewModel.Log = _context.Log;
                return View(ComandosEnvioViewModel);
               
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuscaPorLocais(int? id, string DataInicio, string DataFim, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Log = _context.Log;

            //var DependencyListaEnvioId = Convert.ToInt32(id);
            List<string> Logs_from = form["Logs_from"].ToList();
            List<string> Locais_from = form["Locais_from"].ToList();

            var NomeArquivo = "";
            var PathArquivo = "";
            var TipoArquivo = "";
            var DataArquivo = "";
            var MascaraArquivo = "";
            var TipoUpload = "";


            foreach (var LogId in Logs_from)
            {

                var resultLog = ComandosEnvioViewModel.Log.Where(p => p.LogId.Equals(Convert.ToInt32(LogId)));

                foreach (var l in resultLog)
                {
                    NomeArquivo = l.Nome;
                    PathArquivo = l.Caminho;

                    if (l.TipoArquivo == "Pasta")
                    {
                        TipoArquivo = l.TipoArquivo;
                        TipoUpload = "ByFolder";
                    }
                    else
                    {
                        // bydate or byrange
                        if (l.TipoArquivo != "Pasta" && l.DataMascara is not null)
                        {
                            if (DataInicio is null)
                            {
                                var dt = DateTime.Now;
                                DataInicio = dt.ToString("yyyy-MM-dd");
                            }

                            if (DataFim is not null)
                            {
                                MascaraArquivo = l.DataMascara;
                                TipoArquivo = l.TipoArquivo;
                                DataArquivo = DataInicio + "|" + DataFim;
                                TipoUpload = "ByRangeDate";
                            }
                            else
                            {
                                MascaraArquivo = l.DataMascara;
                                TipoArquivo = l.TipoArquivo;
                                DataArquivo = DataInicio;
                                TipoUpload = "ByDate";
                            }
                        }
                        else
                        {
                            TipoUpload = "ByName";
                            TipoArquivo = l.TipoArquivo;
                        }

                    }

                }

                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Locais_from)
                {
                    ComandosEnvioViewModel.Terminais = _context.Terminal;
                    ComandosEnvioViewModel.Terminais = ComandosEnvioViewModel.Terminais.Where(p => p.LocalId == Convert.ToInt32(item)).ToList();

                    foreach (var terminal in ComandosEnvioViewModel.Terminais)
                    {

                        UpLoadOnLine u = new UpLoadOnLine();
                        u.TerminalId = Convert.ToInt32(terminal.TerminalId);
                        u.StatusId = 0;
                        u.NomeArquivo = NomeArquivo;
                        u.PathArquivo = PathArquivo;
                        u.TipoArquivo = TipoArquivo;
                        u.DataArquivo = DataArquivo;
                        u.MascaraArquivo = MascaraArquivo;
                        u.TipoUpload = TipoUpload;
                        u.DataCadastro = DateTime.Now;
                        u.DataAtualizacao = DateTime.Now;
                        u.StrLog = "";
                        _context.UpLoadOnLine.Add(u);
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
        public async Task<IActionResult> BuscaPorLista(int? id, string DataInicio, string DataFim, IFormCollection form)
        {
            var ComandosEnvioViewModel = new ComandosEnvioViewModel();
            ComandosEnvioViewModel.Log = _context.Log;


           
            List<string> Logs_from = form["Logs_from"].ToList();
            List<string> Lista_from = form["Lista_from"].ToList();

            var NomeArquivo = "";
            var PathArquivo = "";
            var TipoArquivo = "";
            var DataArquivo = "";
            var MascaraArquivo = "";
            var TipoUpload = "";


            foreach (var LogId in Logs_from)
            {

                var resultLog = ComandosEnvioViewModel.Log.Where(p => p.LogId.Equals(Convert.ToInt32(LogId)));

                foreach (var l in resultLog)
                {
                    NomeArquivo = l.Nome;
                    PathArquivo = l.Caminho;

                    if (l.TipoArquivo == "Pasta")
                    {
                        TipoArquivo = l.TipoArquivo;
                        TipoUpload = "ByFolder";
                    }
                    else
                    {
                        // bydate or byrange
                        if (l.TipoArquivo != "Pasta" && l.DataMascara is not null)
                        {
                            if (DataInicio is null)
                            {
                                var dt = DateTime.Now;
                                DataInicio = dt.ToString("yyyy-MM-dd");
                            }

                            if (DataFim is not null)
                            {
                                MascaraArquivo = l.DataMascara;
                                TipoArquivo = l.TipoArquivo;
                                DataArquivo = DataInicio + "|" + DataFim;
                                TipoUpload = "ByRangeDate";
                            }
                            else
                            {
                                MascaraArquivo = l.DataMascara;
                                TipoArquivo = l.TipoArquivo;
                                DataArquivo = DataInicio;
                                TipoUpload = "ByDate";
                            }
                        }
                        else
                        {
                            TipoUpload = "ByName";
                            TipoArquivo = l.TipoArquivo;
                        }

                    }

                }






                //ADICIONA NOVOS ITENS A LISTA
                foreach (var item in Lista_from)
                {
                    ComandosEnvioViewModel.DetalheListaEnvio = _context.DetalheListaEnvio;
                    ComandosEnvioViewModel.DetalheListaEnvio = ComandosEnvioViewModel.DetalheListaEnvio.Where(p => p.ListaEnvioId == Convert.ToInt32(item)).ToList();

                    foreach (var lista in ComandosEnvioViewModel.DetalheListaEnvio)
                    {
                        UpLoadOnLine u = new UpLoadOnLine();
                        u.TerminalId = Convert.ToInt32(lista.TerminalId);
                        u.StatusId = 0;
                        u.NomeArquivo = NomeArquivo;
                        u.PathArquivo = PathArquivo;
                        u.TipoArquivo = TipoArquivo;
                        u.DataArquivo = DataArquivo;
                        u.MascaraArquivo = MascaraArquivo;
                        u.TipoUpload = TipoUpload;
                        u.DataCadastro = DateTime.Now;
                        u.DataAtualizacao = DateTime.Now;
                        u.StrLog = "";
                        _context.UpLoadOnLine.Add(u);
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
