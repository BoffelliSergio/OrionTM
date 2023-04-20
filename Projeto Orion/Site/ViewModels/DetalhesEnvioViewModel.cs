using OrionTM_Web.Models;

namespace OrionTM_Web.ViewModels
{
    public class DetalhesEnvioViewModel
    {

        public int ListaEnvioId { get; set; }

        public IEnumerable<Terminal> Terminais { get; set; }

        public IEnumerable<DetalheListaEnvio> DetalheListaEnvio { get; set; }

        public IEnumerable<ListaEnvio> ListaEnvio { get; set; }
      
    }
}
