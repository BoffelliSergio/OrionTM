using System;
using System.IO;
using System.Configuration;
using OrionTMClient.Infra;

namespace OrionTMClient.Controller
{
    public class ClearTrace
	{
        private int intQtyDay = 0;
        private DateTime dteDeadLine;

        public ClearTrace()
		{

            LocalLog.Trace.WriteLogText("ClearTrace() Starting daily clear...");

            try
            {
                intQtyDay = Convert.ToInt32(ConfigParameters.ReturnClientConfig("QtyDaysMaintenanceTrace"));
            }
            catch
            { 
                try
                {
                    intQtyDay = Convert.ToInt32(ConfigParameters.ReturnClientConfig("QtyDaysMaintenanceTrace"));
                }
                catch
                {
                    intQtyDay = 30; 
                }
            }

            dteDeadLine = DateTime.Now.Date.AddDays((-1) * intQtyDay).AddHours(23).AddMinutes(59).AddSeconds(59);
		}

		public void PerformCleaning()
		{
            LocalLog.Trace.WriteLogText("PerformCleaning() Executing perform cleaning...");

            string[] strFileList = Directory.GetFiles(ConfigParameters.ReturnClientConfig("PathTrace"));
			
			foreach (string strFile in strFileList)
			{
                if (File.GetLastWriteTime(strFile).Date <= dteDeadLine)
				{
					System.Windows.Forms.Application.DoEvents();
                    File.Delete(strFile);
				}
			}

            strFileList = null;

            LocalLog.Trace.WriteLogText("PerformCleaning() Perform cleaning executed successfully!!!");
		}
	}
}

