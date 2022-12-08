using OrionTM_Web.Models;

namespace OrionTM_Web.ViewModels
{
    public class EnvioViewModel
    {

        public IEnumerable<Terminal> Terminais { get; set; }

        public IEnumerable<ListaEnvio> ListaEnvio { get; set; }


    }
}
