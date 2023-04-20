namespace OrionTM_Web.Models
{
    public class StatusTerminal
    {

        public int TerminalId { get; set; }

        public string Codigo { get; set; }

        public string NmModelo { get; set; }

        public string NmLocal { get; set; }

        public string IP { get; set; }

        public DateTime DtAtualizaao { get; set; }

        public int Status { get; set; }


        // contadores
        // terminais
        public int CtTerTot { get; set; }
        public int CtTerOn { get; set; }
        public int CtTerOff { get; set; }

        

    }
}
