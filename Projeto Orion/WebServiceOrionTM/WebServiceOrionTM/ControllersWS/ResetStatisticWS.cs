using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.ModelWebService.Entity;
using System.Configuration;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.Interface;



namespace WebServicesOrionTM.ControllersWS
{
    internal class ResetStatisticWS : WSCommon
    {
        internal ResetStatisticWS()
        {
        }

        internal override object Statistic(object paobjStatistic)
        {
            try
            {
                ResetStatistic objResetStatis = (ResetStatistic)paobjStatistic;

                bool blexiste = false;

                Status enumValue = (Status)Enum.Parse(typeof(Status), objResetStatis.Status);
                int intValue = (int)enumValue;

                ISQLConnect iSQLConnect = new ISQLConnect();
                string strReturn = iSQLConnect.IUpdateStatus(objResetStatis.Sequence, "executacomandoreset", intValue);


                if (!blexiste)
                {
                    objResetStatis.Status = Convert.ToString(Status.ExecuteError);

                    return objResetStatis;
                }

                //Retorna o objeto configurado
                return objResetStatis;
            }
            catch (Exception ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLineStatisticWS..Estatistic() Error." + paobjStatistic.GetType().Name, ex);

                ResetStatistic objResetStatis = (ResetStatistic)paobjStatistic;

                objResetStatis.Status = Convert.ToString(Status.ExecuteError);

                return objResetStatis;
            }
        }
    }
}


















