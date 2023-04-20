using Newtonsoft.Json.Linq;
using OrionTMClient.Infra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace OrionTMClient.Infra
{
    internal class ConfigParameters
    {
        #region "Accessed variables declare"

        private static LocalLog probjTrace;
        private static SortedList clientconfiglist = new SortedList();
        private static SortedList clientxmlconfiglist = new SortedList();
        private static bool blInicializeStatusAtClientConfig = false;
        private static bool blInicializeStatusAtXmlClientConfig = false;
        #endregion

        public static void InicializeClientConfigParameters(LocalLog paobjTrace)
        {
            try
            {
                probjTrace = paobjTrace;
            }
            catch (Exception Ex)
            {
                throw (new Exception("ConfigParameters - InicializeConfigParameters Error on class constructor. ", Ex));
            }
        }

        private static void ChargeClientConfig()
        {
            try
            {
                if (blInicializeStatusAtClientConfig == false)
                {
                    clientconfiglist.Add("ActiveTrace", System.Configuration.ConfigurationManager.AppSettings["ActiveTrace"].ToString().Trim());
                    clientconfiglist.Add("PathTrace", System.Configuration.ConfigurationManager.AppSettings["PathTrace"].ToString().Trim());
                    clientconfiglist.Add("WaitTimeBetweenChecks", System.Configuration.ConfigurationManager.AppSettings["WaitTimeBetweenChecks"].ToString().Trim());
                    clientconfiglist.Add("QtyDaysMaintenanceTrace", System.Configuration.ConfigurationManager.AppSettings["QtyDaysMaintenanceTrace"].ToString().Trim());
                    clientconfiglist.Add("CertificateNotValid", System.Configuration.ConfigurationManager.AppSettings["CertificateNotValid"].ToString().Trim());

                    blInicializeStatusAtClientConfig = true;
                }
            }
            catch (Exception ex)
            {
                probjTrace.WriteLogFile("Error on onfig archive access ChargeClientConfig()." + ex.ToString());
            }
        }

        private static void ChargeXmlClientConfig()
        {
            try
            {
                if(blInicializeStatusAtXmlClientConfig == false )
                {
                    string strDriver = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                    string strPathXml = Path.Combine(strDriver, "XMLEquipment.xml");

                    XmlDocument XmlDoc = new XmlDocument();
                    XmlDoc.Load(strPathXml);

                    foreach (XmlNode node in XmlDoc.DocumentElement.ChildNodes)
                    {
                        clientxmlconfiglist.Add(node.Name, node.InnerText);
                    }

                    blInicializeStatusAtXmlClientConfig = true;
                }
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("ReadEquipmantXml() Exception: ", Ex.ToString());
            }
        }

        public void InicializeTrace(LocalLog paobjTrace)
        {
            probjTrace = paobjTrace;
        }

        public static string ReturnClientConfig(string PaParameter)
        {
            try
            {
                ChargeClientConfig();

                if (clientconfiglist[PaParameter] == null)
                {
                    LocalLog.Trace.WriteLogText("Error. Parameter not found. ReturnClientConfig().");
                }

                return clientconfiglist[PaParameter].ToString().Trim(); ;
            }
            catch (Exception ex)
            {
                probjTrace.WriteLogFile("Error on ReturnClientConfig() Exception: " + ex.ToString());

                return "";
            }
        }

        public static string ReturnXmlClientConfig(string PaParameter)
        {
            try
            {
                ChargeXmlClientConfig();

                if (clientxmlconfiglist[PaParameter] == null)
                {
                    LocalLog.Trace.WriteLogText("Error. Parameter not found. ReturnXmlClientConfig().");
                }

                return clientxmlconfiglist[PaParameter].ToString().Trim(); ;
            }
            catch (Exception ex)
            {
                probjTrace.WriteLogFile("Error on ReturnXmlClientConfig() Exception: " + ex.ToString());

                return "";
            }
        }
    }
}
