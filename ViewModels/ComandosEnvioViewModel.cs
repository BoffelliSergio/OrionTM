using OrionTM_Web.Models;

namespace OrionTM_Web.ViewModels
{
    public class ComandosEnvioViewModel
    {

        public IEnumerable<ListaEnvio> ListaEnvio { get; set; }

        public IEnumerable<Terminal> Terminais { get; set; }

        public IEnumerable<Comando> Comandos { get; set; }

        public IEnumerable<Local> Locais { get; set; }


    }
}
