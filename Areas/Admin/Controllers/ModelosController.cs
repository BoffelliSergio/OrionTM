using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrionTM_Web.Models;
using OrionTM_Web.Repositories;
using OrionTM_Web.Repositories.Interfaces;

namespace OrionTM_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("Admin")]
    public class ModelosController : Controller
    {

        private readonly IModeloRepository _modeloReository;

        public ModelosController(IModeloRepository modeloReository)
        {
            _modeloReository = modeloReository;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult CadastraModelos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Modelo modelo) // recebe os dados no
                                                     // Modelo atravez do post do formulario
        {
            if (ModelState.IsValid)
            {
                // retorna msg para a pagina
                ViewBag.checkoutCompletoMensagem = "Modelo " + modelo.Nome +  " Cadastrado com Sucesso :)";

                // chama o repositorio atravez da interface e grava no banco de dados
                 _modeloReository.CriarModelo(modelo);

                //chama a pagina de sucesso
                return View("~/Areas/Admin/Views/Modelos/CadastraModelos.cshtml", modelo);
            }

            // volta para a pagina se der erro de validação
            return View("~/Areas/Admin/Views/Modelos/CadastraModelos.cshtml");
        }


    }
}
