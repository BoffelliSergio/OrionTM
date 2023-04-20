using System;
using System.Collections.Generic;
using System.Text;
using OrionTMClient.Entity;
using OrionTMClient.Infra;
using OrionTMClient.Infra.ZipLib;
using OrionTMClient.View;

namespace OrionTMClient.Controller
{
	internal class Common
	{
		internal static bool Init = true;
        internal static string ApplicationPath;
		internal static string Version;
        
        internal static OrionEquipment OrionEquipment;
        internal WSOrion.MainServerOrionTM probjwsOrion;
        internal WSConect probjWSConnect;

        internal CommonViews probjcommonviews;
        protected ZipLib probjZipLib;

        
        //internal ConfigParameters probjconfigparameters;

        internal Common()
		{
        }

		~Common()
		{
		}

        internal static void StatusLog(EquipmentMsgStatus paobjStatus)
        {
            LocalLog.Trace.WriteLogText("Common().StatusLog()",
                string.Concat("Received Status:",
                " TypeStatus=", paobjStatus.TypeStatus,
                " Status=", paobjStatus.Status,
                " Description=", paobjStatus.Description));
        }

        internal string FormatFileName(DateTime padteDateMov, string pastrMask)
        {
            CommonViews commonviews = new CommonViews();
            return commonviews.FormatFileName(padteDateMov, pastrMask);
        }

        internal string[] FormatFileNameWithBracket(DateTime padteDateMov, string pastrMask)
        {
            CommonViews commonviews = new CommonViews();
            return commonviews.FormatFileNameWithBracket(padteDateMov, pastrMask);
        }

        internal string ReturnInstalledDrive()
        {
            CommonViews commonviews = new CommonViews();
            return commonviews.ReturnInstalledDrive();
        }



	}
}
