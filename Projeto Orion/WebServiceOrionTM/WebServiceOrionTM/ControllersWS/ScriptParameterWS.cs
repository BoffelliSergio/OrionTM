using System;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Interface;
using WebServicesOrionTM.ModelWebService.Entity;
using System.Web.UI.WebControls;
using WebServicesOrionTM.ControllersWS;
using System.Data.SqlClient;



namespace WebServicesOrionTM.ControllersWS
{
    internal class ScriptParameterWS : WSCommon
    {
        internal ScriptParameterWS()
        {
        }

        internal override object Parameter(object paobjParam)
        {
            ScriptParameter objParameter = (ScriptParameter)paobjParam;

            try
            {
                if (objParameter.Status == Convert.ToString(Status.Start))
                {
                    ISQLConnect iSQLConnect = new ISQLConnect();
                    string FinalOut = iSQLConnect.ICapturaIdSequenciaScript(objParameter.Sequence);
                    objParameter.TextScript = FinalOut;
                    objParameter.Status = Convert.ToString(Status.Start);

                    return objParameter;
                }

                return objParameter;
            }
            catch (Exception ex)
            {

                LocalLog.Trace.WriteLogText("ScriptParameterWS.Allow() Error." + paobjParam.GetType().Name, ex);

                objParameter.TextScript = "";
                objParameter.Sequence = 100001;
                objParameter.Status = Convert.ToString(Status.ExecuteError);

                //Atualizar a base de dados

                return objParameter;
            }
        }
    }
}





