using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Interface;
using WebServicesOrionTM.ModelWebService.Entity;
using System.Web.UI.WebControls;

namespace WebServicesOrionTM.ControllersWS
{
    internal class UploadOnLineSendWS : WSCommon
    {
        internal UploadOnLineSendWS()
        {
        }

        internal override object Send(object paobjSend)
        {
            try
            {
                UploadOnLineSend objUploadOnLineSend = (UploadOnLineSend)paobjSend;

                string strPathLocalUpload = ConfigParameters.ReturnWebConfig("PATH_UPLOADONLINE"); 
                string strPathFileDestination = Path.Combine(strPathLocalUpload, objUploadOnLineSend.FileName);
                BinaryWriter objFileOut;

                if (objUploadOnLineSend.StartSending)
                {
                    objFileOut = new BinaryWriter(File.Create(strPathFileDestination));
                }
                else
                {
                    objFileOut = new BinaryWriter(File.OpenWrite(strPathFileDestination));
                    objFileOut.Seek(0, SeekOrigin.End);
                }

                objFileOut.Write(objUploadOnLineSend.FileData, 0, objUploadOnLineSend.FileData.Length);
                objFileOut.Flush();
                objFileOut.Close();

                ISQLConnect iSQLConnect = new ISQLConnect();
                iSQLConnect.IFileReceivedUrl(objUploadOnLineSend.Sequence, strPathFileDestination);

                objUploadOnLineSend.StartSending = false;
                objUploadOnLineSend.FileData = null;

                return objUploadOnLineSend;
            }
            catch (Exception ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLineSendWS.Send() Error." + paobjSend.GetType().Name, ex);

                UploadOnLineSend objUploadOnLineSend = (UploadOnLineSend)paobjSend;
                objUploadOnLineSend.Status = Convert.ToString(Status.ExecuteError);

                return objUploadOnLineSend;
            }
        }
    }
}





