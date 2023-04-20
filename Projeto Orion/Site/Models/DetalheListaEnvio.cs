namespace OrionTM_Web.Models
{
    public class DetalheListaEnvio
    {

        public int DetalheListaEnvioId { get; set; }
        
        public  ListaEnvio ListaEnvio { get; set; }
        public int ListaEnvioId { get; set; }

        public  Terminal Terminal { get; set; }
        public int TerminalId { get; set; }


    }
}
