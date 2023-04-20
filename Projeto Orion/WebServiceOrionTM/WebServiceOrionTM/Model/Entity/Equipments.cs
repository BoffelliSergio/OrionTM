using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicesOrionTM.Model.Entity
{
    public class Equipments : DateTimeController
    {
        // ToDo - Verificar colunas da tabela Terminais
        private string prTerminalId;
        private string prModelId;
        private string prCodigo;
        private string prLocalId;
        private string prIP;
        private string prDNS;
        private string prDefaultGateway;
        private string prdtAtualizacao;
        private string prVrs_Distruibuida;
        private string prVrs_Instalada;
        private string prStatus;
        public Equipments()
        {
        }

        public string TerminalId
        {
            get
            {
                return prTerminalId;
            }
            set
            {
                prTerminalId = value.Trim();
            }
        }

        public string ModelId
        {
            get
            {
                return prModelId;
            }
            set
            {
                prModelId = value.Trim();
            }
        }

        public string Codigo
        {
            get
            {
                return prCodigo;
            }
            set
            {
                prCodigo = value.Trim();
            }
        }

        public string LocalId
        {
            get
            {
                return prLocalId;
            }
            set
            {
                prLocalId = value.Trim();
            }
        }

        public string IP
        {
            get
            {
                return prIP;
            }
            set
            {
                prIP = value.Trim();
            }
        }

        public string DNS
        {
            get
            {
                return prDNS;
            }
            set
            {
                prDNS = value.Trim();
            }
        }

        public string DefaultGateway
        {
            get
            {
                return prDefaultGateway;
            }
            set
            {
                prDefaultGateway = value.Trim();
            }
        }

        public string dtAtualizacao
        {
            get
            {
                return prdtAtualizacao;
            }
            set
            {
                prdtAtualizacao = value.Trim();
            }
        }

        public string Vrs_Distruibuida
        {
            get
            {
                return prVrs_Distruibuida;
            }
            set
            {
                prVrs_Distruibuida = value.Trim();
            }
        }

        public string Vrs_Instalada
        {
            get
            {
                return prVrs_Instalada;
            }
            set
            {
                prVrs_Instalada = value.Trim();
            }
        }

        public string Status
        {
            get
            {
                return prStatus;
            }
            set
            {
                prStatus = value.Trim();
            }
        }

        //private string prstrHostaddressRequest = "";
        //private string prstrSessionId = "";
        //private string prstrVersaoPcpATPCli = "";
        //private short prshrTipoInstaladorCliente = 0;
        //private DateTime prdtmDataUltimaAtualizHTTP = DateTime.MinValue.AddYears(1899);
        //private string prstrVersaoSistema = "";
        //private short prshrStatusTerminal;
        //private short prshrIdPosto = 0;
        //private string prstrModelo = "";
        //private string prstrNumeroSerie = "";
        //private string prstrMemoria = "";
        //private string prstrCpu = "";
        //private string prstrDisco = "";
        //private string prstrNomePacote = "";
        //private string prstrStatusPacote = "";
        //private DateTime prdtmDataAberturaPacote = DateTime.MinValue.AddYears(1899);
        //private DateTime prdtmDataInstalacaoEquipam = DateTime.MinValue.AddYears(1899);
        //private string prstrInfoGeral = "";
        //private string prstrMascaraRede = "";
        //private string prstrVersaoCdInstal = "";
        //private string prstrVersaoDistribuida = "";
        //private bool prblnIntegracaoSiscad;
        //private short prshrStatusCadastroTerminal = 0;
        //private string prstrNomeSalaTer = "";
    }
}
