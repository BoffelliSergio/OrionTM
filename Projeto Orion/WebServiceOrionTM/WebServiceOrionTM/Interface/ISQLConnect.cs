using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebServicesOrionTM.DataBase;
using WebServicesOrionTM.Model;
using System.Threading.Tasks;
using WebServicesOrionTM.ModelWebService.Entity;

namespace WebServicesOrionTM.Interface
{
    public class ISQLConnect
    {
        public ISQLConnect()
        {
        }

        ~ISQLConnect()
        {
        }

        public bool IUpdateHeartBeat(HeartBeat sbObject)
        {
            //Atualiza o heartbeat
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.UpdateHeartBeat(sbObject.IdEquipment, sbObject.Version);
        }

        public string[] IValidaTokensERetornaIdTask(Orion sbObject)
        {
            //Verificação da autorização e qual task será executada
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.ValidaTokens(sbObject.IdEquipment, sbObject.PublicToken, sbObject.PrivateToken, sbObject.Task);
        }

        public string ICapturaIdSequenciaReset(int IdSequencia)
        {
            //Verificação da autorização e qual task será executada
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.RetornaTaskReset(IdSequencia);
        }

        public string ICapturaIdSequenciaScript(int IdSequencia)
        {
            //Verificação da autorização e qual task será executada
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.RetornaTaskScript(IdSequencia);
        }

        public DataSet ICapturaIdSequenciaUploadOnLine(int IdSequencia)
        {
            //Verificação da autorização e qual task será executada
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.RetornaTaskUploadOnLine(IdSequencia);
        }

        public DataSet ICapturaIdSequenciaDownloadPackage(int IdSequencia)
        {
            //Verificação da autorização e qual task será executada
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.RetornaTaskDownloadPackage(IdSequencia);
        }


        public string IUpdateStatus(int IdSequencia, string TypeOper, int Status)
        {
            //Atualização do Status de execução dos comandos
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.UpdateStatus(IdSequencia, TypeOper, Status);
        }

        public string IFileReceivedUrl(int IdSequencia, string FileReceivedUrl)
        {
            //Atualização do Status de execução dos comandos
            SQLConnect sqlconnect = new SQLConnect();
            return sqlconnect.UpdateUploadOnLineFileReceivedUrl(IdSequencia, FileReceivedUrl);
        }
    }
}