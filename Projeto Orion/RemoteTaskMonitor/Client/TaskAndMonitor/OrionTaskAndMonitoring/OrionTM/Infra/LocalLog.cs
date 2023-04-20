using System;
using System.IO;
using System.Web;
using System.Configuration;


namespace OrionTMClient.Infra
{

	/// <summary>
	///Trace do sistema. Gera um arquivo de log em disco
	/// </summary>
	public class LocalLog : SystemEvent
	{
        public static LocalLog Trace;

		public static string ActiveTrace = "";

		//Propriedades referente as caracteristicas do Log
		public string publstrPathFile; 
		public string publstrLogFileName = "TRACE";
		public string publstrLogExtension = "TXT";

		public LocalLog(string pastrPathFile)
		{
			publstrPathFile = pastrPathFile;

            if (ActiveTrace == "")
            {
                ActiveTrace = ConfigParameters.ReturnClientConfig("ActiveTrace");
            }
		}

		~LocalLog()
		{
		}

		public bool WriteLogFile(string pastrText)
		{
			try
			{
                string strLogFile = string.Concat(publstrLogFileName.Trim(), DateTime.Now.ToString("yyyyMMdd"), ".", publstrLogExtension.Trim());
                string strLogText = string.Concat(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), " - ", pastrText);

                if (!Directory.Exists(publstrPathFile)) 
				{
                    Directory.CreateDirectory(publstrPathFile);
				}

                StreamWriter Fileobj = File.AppendText(Path.Combine(publstrPathFile, strLogFile));

                Fileobj.WriteLine(strLogText);
                Fileobj.Flush();
                Fileobj.Close();

                Fileobj = null;
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
                if (ActiveTrace == "true")
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
            string strLogText = string.Concat("Source: ", pastrSource, " - ", pastrLogText);

			try 
			{
                if (ActiveTrace == "true")
                    return WriteLogText(strLogText);
				else
					return true;
			}
			catch
			{
				return false;
			}
		}

		public bool WriteLogText(Exception paobjectError)
		{
			try 
			{
                return WriteLogFile(string.Concat("Message=", paobjectError.Message,
                    "   InnerException=", paobjectError.InnerException,
                    "   Source=", paobjectError.Source,
                    "   StackTrace=", paobjectError.StackTrace,
                    "   TargetSite=", paobjectError.TargetSite));
			}
			catch
			{
				return false;
			}			
		}

        public bool WriteLogText(string pastrSource, Exception paobjectError)
		{
			try 
			{
				return WriteLogFile(string.Concat("Source=",pastrSource,
                    "   Message=", paobjectError.Message,
                    "   InnerException=", paobjectError.InnerException,
                    "   Source=", paobjectError.Source,
                    "   StackTrace=", paobjectError.StackTrace,
                    "   TargetSite=", paobjectError.TargetSite));
			}
			catch
			{
				return false;
			}			
		}

        public bool WriteLogText(string pastrSource, string pastrLogText, Exception paobjectError)
		{
			try 
			{
				return WriteLogFile(string.Concat("Source=",pastrSource,
					" - ",pastrLogText,
                    "   Message=", paobjectError.Message,
                    "   InnerException=", paobjectError.InnerException,
                    "   Source=", paobjectError.Source,
                    "   StackTrace=", paobjectError.StackTrace,
                    "   TargetSite=", paobjectError.TargetSite));
			}
			catch
			{
				return false;
			}			
		}
	}
}