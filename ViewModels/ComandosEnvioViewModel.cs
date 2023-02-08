using OrionTM_Web.Models;

namespace OrionTM_Web.ViewModels
{
    public class ComandosEnvioViewModel
    {
        public IEnumerable<ListaEnvio> ListaEnvio { get; set; }

        public IEnumerable<Terminal> Terminais { get; set; }

        public IEnumerable<Comando> Comandos { get; set; }

        public IEnumerable<Log> Log { get; set; }
        public IEnumerable<Pacote> Pacote { get; set; }

        public IEnumerable<Local> Locais { get; set; }
        
        public IEnumerable<FilaTasks> FilaTasks { get; set; }

        public IEnumerable<UpLoadOnLine> UpLoadOnLine { get; set; }

        public IEnumerable<Reset> Reset { get; set; }

        public IEnumerable<Script> Script { get; set; }

        public IEnumerable<Download> Download { get; set; }

        public IEnumerable<DetalheListaEnvio> DetalheListaEnvio { get; set; }

    }
}
