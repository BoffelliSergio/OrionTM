using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Interface;
using WebServicesOrionTM.ModelWebService.Entity;
using System.Data.SqlClient;



namespace WebServicesOrionTM.ControllersWS
{
    internal class ResetParameterWS : WSCommon
    {
        internal ResetParameterWS()
        {
        }

        internal override object Parameter(object paobjParam)
        {
            ResetParameter objParameter = (ResetParameter)paobjParam;

            try
            {
                if (objParameter.Status == Convert.ToString(Status.Start))
                {
                    ISQLConnect iSQLConnect = new ISQLConnect();
                    string FinalOut = iSQLConnect.ICapturaIdSequenciaReset(objParameter.Sequence);

                    if (FinalOut.ToLower() == "shutdown")
                    {
                        objParameter.TypeReset = Convert.ToInt16(TypeReset.ShutDown);
                    }

                    if (FinalOut.ToLower() == "application")
                    {
                        objParameter.TypeReset = Convert.ToInt16(TypeReset.Application);
                    }

                    objParameter.Status = Convert.ToString(Status.Start);

                    return objParameter;
                }

                return objParameter;
            }
            catch (Exception ex)
            {

                LocalLog.Trace.WriteLogText("ResetParameterWS.Allow() Error." + paobjParam.GetType().Name, ex);

                objParameter.TypeReset = Convert.ToInt16(TypeReset.ShutDown); 
                objParameter.Sequence = 100001;
                objParameter.Status = Convert.ToString(Status.ExecuteError);
                
                //Atualizar a base de dados
                
                return objParameter;
            }
        }
    }
}





