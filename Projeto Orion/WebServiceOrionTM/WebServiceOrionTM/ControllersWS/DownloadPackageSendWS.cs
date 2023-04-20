using System;
using System.IO;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.ModelWebService.Entity;
using WebServicesOrionTM.Interface;

namespace WebServicesOrionTM.ControllersWS
{
    internal class DownloadPackageSendWS : WSCommon
    {
        internal DownloadPackageSendWS()
        {
        }

        internal override object Send(object paobjSend)
        {
            try
            {
                DownloadPackageSend objDownloadPackageSend = (DownloadPackageSend)paobjSend;

                string strPathLocalDownloadPackage = ConfigParameters.ReturnWebConfig("PATH_DOWNLOADPACKAGE");
                string strPathLocalDownloadPackageAndName = Path.Combine(strPathLocalDownloadPackage, objDownloadPackageSend.FileName);

                FileInfo objFileInfo = new FileInfo(strPathLocalDownloadPackageAndName);

                objDownloadPackageSend.TotalSize = objFileInfo.Length;

                ZipLib probjZipLib = new ZipLib();
                objDownloadPackageSend.CRCFile = probjZipLib.CRC32File(strPathLocalDownloadPackageAndName);
                probjZipLib = null;

                if (!File.Exists(strPathLocalDownloadPackageAndName))
                {
                    LocalLog.Trace.WriteLogText("DownloadPackageSendWS.Send() Error. File to download not exists. " + strPathLocalDownloadPackageAndName);

                    objDownloadPackageSend.Status = Convert.ToString(Status.ExecuteError);
                    return objDownloadPackageSend;
                }

                FileStream objFileStream = new FileStream(strPathLocalDownloadPackageAndName, FileMode.Open, FileAccess.Read, FileShare.Read, objDownloadPackageSend.SizeBuffer);
                BinaryReader objBinaryReader = new BinaryReader(objFileStream);
                objBinaryReader.BaseStream.Seek(objDownloadPackageSend.InitialPosition, SeekOrigin.Begin);

                objDownloadPackageSend.FileData = new byte[objDownloadPackageSend.SizeBuffer];
                int intBytesRead = objBinaryReader.Read(objDownloadPackageSend.FileData, 0, objDownloadPackageSend.SizeBuffer);

                if (intBytesRead < objDownloadPackageSend.SizeBuffer)
                {
                    objDownloadPackageSend.EndedFileSend = true;
                }

                if (objDownloadPackageSend.EndedFileSend)
                {
                    objFileStream = null;
                    objBinaryReader = null;
                }

                return objDownloadPackageSend;
            }
            catch (Exception ex)
            {
                LocalLog.Trace.WriteLogText("UploadOnLineSendWS.Send() Error." + paobjSend.GetType().Name, ex);

                DownloadPackageSend objDownloadPackageSend = (DownloadPackageSend)paobjSend;
                objDownloadPackageSend.Status = Convert.ToString(Status.ExecuteError);

                return objDownloadPackageSend;
            }
        }
    }
}





