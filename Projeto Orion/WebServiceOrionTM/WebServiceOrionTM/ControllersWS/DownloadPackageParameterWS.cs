using System;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.ModelWebService.Entity;
using WebServicesOrionTM.Interface;
using System.Data;

namespace WebServicesOrionTM.ControllersWS
{
    internal class DownloadPackageParameterWS : WSCommon
    {
        internal DownloadPackageParameterWS()
        {
        }

        internal override object Parameter(object paobjParam)
        {
            DownloadPackageParameter objParameter = (DownloadPackageParameter)paobjParam;

            try
            {
                if (objParameter.Status == Convert.ToString(Status.Start))
                {
                    DataSet dsReturn = new DataSet();
                    ISQLConnect iSQLConnect = new ISQLConnect();
                    dsReturn = iSQLConnect.ICapturaIdSequenciaDownloadPackage(objParameter.Sequence);

                    string strFileNamePackage = "";
                    string strInstalationDateHour = "";

                    for (int i = 0; i < dsReturn.Tables["DownloadPackage"].Rows.Count; i++)
                    {
                        strFileNamePackage = dsReturn.Tables["DownloadPackage"].Rows[0].ItemArray[0].ToString();
                        strInstalationDateHour = dsReturn.Tables["DownloadPackage"].Rows[0].ItemArray[1].ToString();
                    }

                    //string strFileNamePackage = @"testepacote.zip";
                    //objParameter.InstalationDateHour = "IMED";
                    //objParameter.InstalationDateHour = "2023-02-20 22:00:000";

                    objParameter.FileNamePackage = strFileNamePackage;
                    objParameter.InstalationDateHour = strInstalationDateHour;
                    objParameter.Status = Convert.ToString(Status.Start);
                    return objParameter;
                }

                return objParameter;
            }
            catch (Exception ex)
            {

                LocalLog.Trace.WriteLogText("UploadOnLineAllowWS.Allow() Error." + paobjParam.GetType().Name, ex);

                objParameter.FileNamePackage = "";
                objParameter.Status = Convert.ToString(Status.ExecuteError);

                //Atualizar a base de dados

                return objParameter;
            }
        }



    }
}

