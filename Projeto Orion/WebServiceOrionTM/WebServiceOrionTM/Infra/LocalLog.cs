using System;
using System.IO;

namespace WebServicesOrionTM.Infra
{
    public class LocalLog : EventSist
    {

        public static LocalLog Trace;
        public static string TraceAtivo = "";

        public string pustrPathFile = @"c:\";
        public string pustrLogFileName = "TRACEWebServiceOrionTM";
        public string pustrLogExtension = "TXT";

        public LocalLog(string pastrPathFile)
        {
            pustrPathFile = pastrPathFile;

            if (TraceAtivo == "")
            {
                TraceAtivo = System.Configuration.ConfigurationManager.AppSettings["TRACE_ATIVO"].ToString();
            }
        }
                
        ~LocalLog()
        {
        }

        public bool WriteLogFile(string pastrText)
        {
            try
            {
                string strArqLog = string.Concat(pustrLogFileName.Trim(), DateTime.Now.ToString("yyyyMMdd"), ".", pustrLogExtension.Trim());
                string strTextLog = string.Concat(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), " - ", pastrText);

                if (!Directory.Exists(pustrPathFile))
                {
                    Directory.CreateDirectory(pustrPathFile);
                }

                StreamWriter objArq = File.AppendText(Path.Combine(pustrPathFile, strArqLog));

                objArq.WriteLine(strTextLog);
                objArq.Flush();
                objArq.Close();
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WriteLogText(string pastrLogText)
        {
            try
            {
                if (TraceAtivo == "true")
                    return WriteLogFile(pastrLogText);
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WriteLogText(string pastrSource, string pastrLogText)
        {
            string strTextoLog = string.Concat("Source: ", pastrSource, " - ", pastrLogText);

            try
            {
                if (TraceAtivo == "true")
                    return WriteLogText(strTextoLog);
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public bool WriteLogText(Exception paobjError)
        {
            try
            {
                return WriteLogFile(string.Concat("Message=", paobjError.Message,
                    "   InnerException=", paobjError.InnerException,
                    "   Source=", paobjError.Source,
                    "   StackTrace=", paobjError.StackTrace,
                    "   TargetSite=", paobjError.TargetSite));
            }
            catch
            {
                return false;
            }
        }

        public bool WriteLogText(string pastrSource, Exception paobjError)
        {
            try
            {
                return WriteLogFile(string.Concat("Source=", pastrSource,
                    "   Message=", paobjError.Message,
                    "   InnerException=", paobjError.InnerException,
                    "   Source=", paobjError.Source,
                    "   StackTrace=", paobjError.StackTrace,
                    "   TargetSite=", paobjError.TargetSite));
            }
            catch
            {
                return false;
            }
        }
        
        public bool WriteLogText(string pastrSource, string pastrLogText, Exception paobjError)
        {
            try
            {
                return WriteLogFile(string.Concat("Source=", pastrSource,
                    " - ", pastrLogText,
                    "   Message=", paobjError.Message,
                    "   InnerException=", paobjError.InnerException,
                    "   Source=", paobjError.Source,
                    "   StackTrace=", paobjError.StackTrace,
                    "   TargetSite=", paobjError.TargetSite));
            }
            catch
            {
                return false;
            }
        }
    }
}
