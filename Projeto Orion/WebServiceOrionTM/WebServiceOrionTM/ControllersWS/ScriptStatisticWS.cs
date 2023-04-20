using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.ModelWebService.Entity;
using System.Configuration;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.Interface;
using WebServicesOrionTM.Model;


namespace WebServicesOrionTM.ControllersWS
{
    internal class ScriptStatisticWS : WSCommon
    {
        internal ScriptStatisticWS()
        {
        }

        internal override object Statistic(object paobjStatistic)
        {
            try
            {
                ScriptStatistic objScriptStatis = (ScriptStatistic)paobjStatistic;

                bool blexiste = false;

                Status enumValue = (Status) Enum.Parse(typeof(Status), objScriptStatis.Status);
                int intValue = (int)enumValue;

                ISQLConnect iSQLConnect = new ISQLConnect();
                string strReturn = iSQLConnect.IUpdateStatus(objScriptStatis.Sequence, "executascript", intValue);

                if (!blexiste)
                {
                    objScriptStatis.Status = Convert.ToString(Status.ExecuteError);

                    return objScriptStatis;
                }

                //Retorna o objeto configurado
                return objScriptStatis;
            }
            catch (Exception ex)
            {
                LocalLog.Trace.WriteLogText("ScriptStatisticWS..Estatistic() Error." + paobjStatistic.GetType().Name, ex);

                ScriptStatistic objScriptStatis = (ScriptStatistic)paobjStatistic;

                objScriptStatis.Status = Convert.ToString(Status.ExecuteError);

                return objScriptStatis;
            }
        }
    }
}


















