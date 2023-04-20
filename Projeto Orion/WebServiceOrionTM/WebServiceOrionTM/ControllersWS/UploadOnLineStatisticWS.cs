using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.ModelWebService.Entity;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Interface;


namespace WebServicesOrionTM.ControllersWS
{
    internal class UploadOnLineStatisticWS : WSCommon
    {
        internal UploadOnLineStatisticWS()
        {
        }

        internal override object Statistic(object paobjStatistic)
        {
            try
            {
                UploadOnLineStatistic objUploadOnLineStatis = (UploadOnLineStatistic)paobjStatistic;
        
                bool blexiste = false;

                Status enumValue = (Status)Enum.Parse(typeof(Status), objUploadOnLineStatis.Status);
                int intValue = (int)enumValue;

                ISQLConnect iSQLConnect = new ISQLConnect();
                string strReturn = iSQLConnect.IUpdateStatus(objUploadOnLineStatis.Sequence, "uploadonline", intValue);

                if (!blexiste)
                {
                    objUploadOnLineStatis.Status = Convert.ToString(Status.ExecuteError);

                    return objUploadOnLineStatis;
                }

                //Retorna o objeto configurado
                return objUploadOnLineStatis;
            }
            catch (Exception ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLineStatisticWS..Estatistic() Error." + paobjStatistic.GetType().Name, ex);

                UploadOnLineStatistic objUploadOnLineStatis = (UploadOnLineStatistic)paobjStatistic;

                objUploadOnLineStatis.Status = Convert.ToString(Status.ExecuteError);

                return objUploadOnLineStatis;
            }
        }
    }
}










