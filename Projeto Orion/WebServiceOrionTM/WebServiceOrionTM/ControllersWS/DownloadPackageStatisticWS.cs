using System;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.ModelWebService.Entity;
using WebServicesOrionTM.Interface;


namespace WebServicesOrionTM.ControllersWS
{
    internal class DownloadPackageStatisticWS : WSCommon
    {
        internal DownloadPackageStatisticWS()
        {
        }

        internal override object Statistic(object paobjStatistic)
        {
            try
            {
                DownloadPackageStatistic objDownloadPackageStatistic = (DownloadPackageStatistic)paobjStatistic;

                bool blexiste = false;

                Status enumValue = (Status)Enum.Parse(typeof(Status), objDownloadPackageStatistic.Status);
                int intValue = (int)enumValue;


                ISQLConnect iSQLConnect = new ISQLConnect();
                string strReturn = iSQLConnect.IUpdateStatus(objDownloadPackageStatistic.Sequence, "downloadpackage", intValue);

                if (!blexiste)
                {
                    objDownloadPackageStatistic.Status = Convert.ToString(Status.ExecuteError);

                    return objDownloadPackageStatistic;
                }

                //Retorna o objeto configurado
                return objDownloadPackageStatistic;
            }
            catch (Exception ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLineStatisticWS..Estatistic() Error." + paobjStatistic.GetType().Name, ex);

                DownloadPackageStatistic objDownloadPackageStatistic = (DownloadPackageStatistic)paobjStatistic;

                objDownloadPackageStatistic.Status = Convert.ToString(Status.ExecuteError);

                return objDownloadPackageStatistic;
            }
        }
    }
}

