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

        //  upload
        public int CtUpLoadTot { get; set; }
        public int CtUpLoadINIC { get; set; }
        public int CtUpLoadEXEC { get; set; }
        public int CtUpLoadOK { get; set; }
        public int CtUpLoadERR { get; set; }

        // download
        public int CtDownLoadTot { get; set; }
        public int CtDownLoadINIC { get; set; }
        public int CtDownLoadEXEC { get; set; }
        public int CtDownLoadOK { get; set; }
        public int CtDownLoadERR { get; set; }

        // scripts

        public int CtScriptTot { get; set; }
        public int CtScriptINIC { get; set; }
        public int CtScriptEXEC { get; set; }
        public int CtScriptOK { get; set; }
        public int CtScriptERR { get; set; }


        // reset
        public int CtResetTot { get; set; }
        public int CtResetINIC { get; set; }
        public int CtResetEXEC { get; set; }
        public int CtResetOK { get; set; }
        public int CtResetERR { get; set; }



    }
}
