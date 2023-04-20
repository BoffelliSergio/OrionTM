using System;
using System.Collections;
using WebServiceXPiAuth.Infra;

namespace WebServiceXPiAuth.Infra
{
    internal class ConfigParameters
    {
        #region "Accessed variables declare"

        private static LocalLog probjTrace;

        private static SortedList webconfiglist = new SortedList();
        private static bool blInicializeStatusAtWebConfig = false;
        private static ArrayList ArrayListTokens = new ArrayList();
        #endregion

        public static void InicializeWebConfigParameters(LocalLog paobjTrace)
        {
            try
            {
                probjTrace = paobjTrace;
            }
            catch (Exception Ex)
            {
                throw (new Exception("ConfigParameters - InicializeWebConfigParameters Error on class constructor. ", Ex));
            }
        }

        private static void ChargeWebConfig()
        {
            try
            {
                if (blInicializeStatusAtWebConfig == false)
                {
                    webconfiglist.Add("TRACE_ATIVO", System.Configuration.ConfigurationManager.AppSettings["TRACE_ATIVO"].ToString().Trim());
                    webconfiglist.Add("PATH_TRACE", System.Configuration.ConfigurationManager.AppSettings["PATH_TRACE"].ToString().Trim());
                    webconfiglist.Add("TOKEN", System.Configuration.ConfigurationManager.AppSettings["TOKEN"].ToString().Trim());
                    webconfiglist.Add("CONN", System.Configuration.ConfigurationManager.ConnectionStrings["CONN"].ToString().Trim());
                    blInicializeStatusAtWebConfig = true;
                }
            }
            catch (Exception ex)
            {
                probjTrace.WriteLogFile("Error on WebConfig archive access ChargeWebConfig()." + ex.ToString());
            }
        }

        public void InicializeTrace(LocalLog paobjTrace)
        {
            probjTrace = paobjTrace;
        }

        public void InicializeArrayListTokens()
        {
            ArrayListTokens.Clear();
        }

        public bool ConsultaToken(string pastrPrivateToken)
        {
            bool bltokenexiste = false;

            //probjTrace.WriteLogText("ConsultaToken() ArrayListTokens.Count:" + ArrayListTokens.Count.ToString());
            
            for (int i = 0; i < ArrayListTokens.Count; i++)
            {
                if (ArrayListTokens[i].ToString() == pastrPrivateToken.Trim())
                {
                    //probjTrace.WriteLogText("ConsultaToken() ArrayListTokens["+ i.ToString() + "]"+ ArrayListTokens[i].ToString());

                    bltokenexiste = true;
                    break;
                }
            }

            if (bltokenexiste)
            {
                //probjTrace.WriteLogText("ConsultaToken() token já existe.");
                return true;
            }
            else
            {
                //probjTrace.WriteLogText("ConsultaToken() token não existe.");
                return false;
            }
        }

        public bool AdicionaToken(string pastrPrivateToken)
        {
            bool bltokenexiste = false;

            for (int i = 0; i < ArrayListTokens.Count; i++)
            {
                if (ArrayListTokens[i].ToString() == pastrPrivateToken.Trim())
                {
                    bltokenexiste = true;
                    break;
                }
            }

            if (bltokenexiste)
            {
                //probjTrace.WriteLogText("AdicionaToken() token já existe.");
                return false;
            }
            else
            {
                //probjTrace.WriteLogText("AdicionaToken() token não existe.");
                ArrayListTokens.Add(pastrPrivateToken.Trim());
                
                return true;
            }
        }

        public bool ExcluiToken(string pastrPrivateToken)
        {
            bool bltokenexiste = false;

            for (int i = 0; i < ArrayListTokens.Count; i++)
            {
                if (ArrayListTokens[i].ToString() == pastrPrivateToken.Trim())
                {
                    bltokenexiste = true;
                    break;
                }
            }

            if (bltokenexiste)
            {
                ArrayListTokens.Remove(pastrPrivateToken.Trim());
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static string ReturnWebConfig(string PaParameter)
        {
            try
            {
                string strWebConfigReturnParameterValue = "";

                ChargeWebConfig();

                if (webconfiglist[PaParameter] == null)
                {
                    //LocalLog.Trace.WriteLogText("Error. Parameter not found. ReturnWebConfig().");
                }

                strWebConfigReturnParameterValue = webconfiglist[PaParameter].ToString().Trim();
                
                return strWebConfigReturnParameterValue;
            }
            catch (Exception ex)
            {
                probjTrace.WriteLogFile("Error on ReturnWebConfig() Exception: " + ex.ToString());

                return "";
            }
        }
    }
}
