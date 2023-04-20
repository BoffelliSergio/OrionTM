using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;
using OrionTMClient.Infra;

namespace OrionTMClient.View
{
    public class CommonViews 
    {
        internal string FormatFileName(DateTime padteDateMov, string pastrMask)
        {
            Int32 intFrom = pastrMask.IndexOf("[", 0);
            Int32 intTo = pastrMask.IndexOf("]", intFrom);

            if (intFrom < 0)
            {	
                return pastrMask;
            }

            string strDD = padteDateMov.ToString("dd");
            string strMM = padteDateMov.ToString("MM");
            string strYY = padteDateMov.ToString("yy");
            string strYYYY = padteDateMov.ToString("yyyy");

            string strMaskForm = pastrMask.Substring(intFrom + 1, intTo - intFrom - 1).ToUpper();
            strMaskForm = strMaskForm.Replace("DD", strDD);
            strMaskForm = strMaskForm.Replace("MM", strMM);
            strMaskForm = strMaskForm.Replace("YYYY", strYYYY);
            strMaskForm = strMaskForm.Replace("YY", strYY);

            string strFileName = "";

            if (intFrom > 0)
                strFileName = pastrMask.Substring(0, intFrom);

            strFileName = string.Concat(strFileName, strMaskForm, pastrMask.Substring(intTo + 1));

            return strFileName;
        }

        internal string[] FormatFileNameWithBracket(DateTime padteDateMov, string pastrMask)
        {
            string[] outstring = new string[5];
            Int32 intFrom = pastrMask.IndexOf("[", 0);
            Int32 intTo = pastrMask.IndexOf("]", intFrom);

            if (intFrom < 0)
            {
                outstring[0] = "";
                outstring[1] = pastrMask;
                outstring[2] = "";
                outstring[3] = "";
                outstring[4] = "";

                return outstring;
            }

            string strDD = padteDateMov.ToString("dd");
            string strMM = padteDateMov.ToString("MM");
            string strYY = padteDateMov.ToString("yy");
            string strYYYY = padteDateMov.ToString("yyyy");

            string strMaskForm = pastrMask.Substring(intFrom + 1, intTo - intFrom - 1).ToUpper();
            strMaskForm = strMaskForm.Replace("DD", strDD);
            strMaskForm = strMaskForm.Replace("MM", strMM);
            strMaskForm = strMaskForm.Replace("YYYY", strYYYY);
            strMaskForm = strMaskForm.Replace("YY", strYY);

            string strFileName = "";

            if (intFrom > 0)
            {
                strFileName = pastrMask.Substring(0, intFrom);
            }

            strFileName = string.Concat(strFileName, strMaskForm, pastrMask.Substring(intTo + 1));

            outstring[0] = strFileName;
            outstring[1] = strMaskForm;
            outstring[2] = strDD;
            outstring[3] = strMM;

            if (strYY != "")
            {
                outstring[4] = strYY;
            }

            if (strYYYY != "")
            {
                outstring[4] = strYYYY;
            }

            return outstring;
        }

        internal string ReturnInstalledDrive()
        {
            string strDriver = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            int intStrDriver = strDriver.LastIndexOf(@":") + 1;
            strDriver = strDriver.Substring(0, intStrDriver);
            return strDriver;
        }

        //internal string ReadEquipmantXml(string StrNode)
        //{
        //    string strOut = "";

        //    try
        //    {
        //        //var teste = new ConfigParameters();
        //        //teste.ReturnXmlClientConfig();

        //        //string strDriver = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //        //string strPathXml = Path.Combine(strDriver, "XMLEquipment.xml");  

        //        //XmlDocument XmlDoc = new XmlDocument();
        //        //XmlDoc.Load(strPathXml);

        //        foreach (XmlNode node in XmlDoc.DocumentElement.ChildNodes)
        //        {
        //            if(node.Name.ToLower().Trim() == StrNode.ToLower().Trim())
        //            {
        //                strOut = node.InnerText;
        //                break;
        //            }
        //        }
        //    }
        //    catch(Exception Ex)
        //    {
        //        LocalLog.Trace.WriteLogText("ReadEquipmantXml() Exception: ", Ex.ToString());
        //    }

        //    return strOut;
        //}


        //public static string ReturnXmlClientConfig(string PaParameter)
        //{
        //    try
        //    {
        //        ChargeXmlClientConfig();

        //        if (clientxmlconfiglist[PaParameter] == null)
        //        {
        //            LocalLog.Trace.WriteLogText("Error. Parameter not found. ReturnXmlClientConfig().");
        //        }

        //        return clientxmlconfiglist[PaParameter].ToString().Trim(); ;
        //    }
        //    catch (Exception ex)
        //    {
        //        probjTrace.WriteLogFile("Error on ReturnXmlClientConfig() Exception: " + ex.ToString());

        //        return "";
        //    }
        //}



    }
}
