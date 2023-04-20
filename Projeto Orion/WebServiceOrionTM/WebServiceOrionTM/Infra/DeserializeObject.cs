using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using WebServicesOrionTM.Infra;

namespace WebServicesOrionTM.Infra.Deserialize
{
    public class DeserializeObject
    {
        public static Exception Error;

        public DeserializeObject()
        {
        }

        ~DeserializeObject()
        {
        }

        public static object Descerialize(string pastrObjXML, string pastrNameSpace)
        {
            Error = null;

            bool ValidaPathTraversal = VerifyPathTraversal(pastrObjXML);

            if (ValidaPathTraversal)
            {
                LocalLog.Trace.WriteLogText("Error VerifyPathTraversal() on xml reading.");
                return null;
            }

            System.IO.StringReader objStringReader = new System.IO.StringReader(pastrObjXML);
            System.Xml.XmlReader objXmlReader = new System.Xml.XmlTextReader(objStringReader);

            try
            {
                string strClassName = "";

                if (objXmlReader.IsStartElement())
                    strClassName = objXmlReader.LocalName;

                if (pastrNameSpace != "")
                {
                    pastrNameSpace = string.Concat(pastrNameSpace, ".");
                }

                System.Type objType = Type.GetType(string.Concat(pastrNameSpace, strClassName));
                System.Xml.Serialization.XmlSerializer objDeserializer = new System.Xml.Serialization.XmlSerializer(objType);

                return objDeserializer.Deserialize(objXmlReader);

            }
            catch (Exception Ex)
            {
                Error = Ex;
                return null;
            }
            finally
            {
                objXmlReader.Close();
                objStringReader.Close();
            }
        }

        public static object Descerialize(string pastrSourceFile, string pastrNameSpace, string pastrClassName)
        {
            Error = null;

            System.IO.Stream objFS = new System.IO.FileStream(pastrSourceFile, System.IO.FileMode.Open);

            try
            {
                System.Type objType = Type.GetType(string.Concat(pastrNameSpace, ".", pastrClassName));

                System.Xml.Serialization.XmlSerializer objDeserializer = new System.Xml.Serialization.XmlSerializer(objType);
                object objDesc = objDeserializer.Deserialize(objFS);


                return objDesc;
            }
            catch (Exception Ex)
            {
                Error = Ex;
                return null;
            }
            finally
            {
                objFS.Close();
            }
        }

        internal static bool VerifyPathTraversal(string pastrInput)
        {
            bool blCharReturn = false;

            if (!String.IsNullOrEmpty(pastrInput))
            {
                if (pastrInput.ToLower().IndexOf("%2e%2e%2f") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e%2e/") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e.%2f") >= 0 ||
             pastrInput.ToLower().IndexOf(".%2e%2f") >= 0 ||
             pastrInput.ToLower().IndexOf("..%2f") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e./") >= 0 ||
             pastrInput.ToLower().IndexOf(".%2e/") >= 0 ||
             pastrInput.ToLower().IndexOf("../") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e%2e%5c") >= 0 ||
             pastrInput.ToLower().IndexOf(@"%2e%2e\") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e.%5c") >= 0 ||
             pastrInput.ToLower().IndexOf(".%2e%5c") >= 0 ||
             pastrInput.ToLower().IndexOf("..%5c") >= 0 ||
             pastrInput.ToLower().IndexOf(@"%2e.\") >= 0 ||
             pastrInput.ToLower().IndexOf(@".%2e\") >= 0 ||
             pastrInput.ToLower().IndexOf(@"..\") >= 0 ||
             pastrInput.ToLower().IndexOf("%252e%252e%255c") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e%2e/") >= 0 ||
             pastrInput.ToLower().IndexOf("%252e.%255c") >= 0 ||
             pastrInput.ToLower().IndexOf(".%252e%255c") >= 0 ||
             pastrInput.ToLower().IndexOf("..%255c") >= 0 ||
             pastrInput.ToLower().IndexOf(@"%252e.\") >= 0 ||
             pastrInput.ToLower().IndexOf(@".%252e\") >= 0 ||
             pastrInput.ToLower().IndexOf("c+dir") >= 0 ||
             pastrInput.ToLower().IndexOf("c+dir+c:") >= 0 ||
             pastrInput.ToLower().IndexOf("%255c") >= 0 ||
             pastrInput.ToLower().IndexOf("%252e") >= 0 ||
             pastrInput.ToLower().IndexOf("%f0%80%80%af") >= 0 ||
             pastrInput.ToLower().IndexOf("%c1") >= 0 ||
             pastrInput.ToLower().IndexOf("%1c") >= 0 ||
             pastrInput.ToLower().IndexOf("%25") >= 0 ||
             pastrInput.ToLower().IndexOf("%32") >= 0 ||
             pastrInput.ToLower().IndexOf("%35") >= 0 ||
             pastrInput.ToLower().IndexOf("%63") >= 0 ||
             pastrInput.ToLower().IndexOf("%66") >= 0 ||
             pastrInput.ToLower().IndexOf("%252f") >= 0 ||
             pastrInput.ToLower().IndexOf("%255c") >= 0 ||
             pastrInput.ToLower().IndexOf("%5c") >= 0 ||
             pastrInput.ToLower().IndexOf("%5") >= 0 ||
             pastrInput.ToLower().IndexOf("%c0") >= 0 ||
             pastrInput.ToLower().IndexOf("%2f") >= 0 ||
             pastrInput.ToLower().IndexOf("%9v") >= 0 ||
             pastrInput.ToLower().IndexOf("%af") >= 0 ||
             pastrInput.ToLower().IndexOf("%1c") >= 0 ||
             pastrInput.ToLower().IndexOf("%8s") >= 0 ||
             pastrInput.ToLower().IndexOf("%c1") >= 0 ||
             pastrInput.ToLower().IndexOf("%9c") >= 0 ||
             pastrInput.ToLower().IndexOf("%af") >= 0 ||
             pastrInput.ToLower().IndexOf("%pc") >= 0 ||
             pastrInput.ToLower().IndexOf("%e0") >= 0 ||
             pastrInput.ToLower().IndexOf("%80") >= 0 ||
             pastrInput.ToLower().IndexOf("%f8") >= 0 ||
             pastrInput.ToLower().IndexOf("%fc") >= 0 ||
             pastrInput.ToLower().IndexOf("%qf") >= 0 ||
             pastrInput.ToLower().IndexOf("%2e") >= 0 ||
             pastrInput.ToLower().IndexOf("%2f") >= 0 ||
             pastrInput.ToLower().IndexOf("%252e") >= 0 ||
             pastrInput.ToLower().IndexOf("%255c") >= 0 ||
             pastrInput.ToLower().IndexOf("%2f") >= 0 ||
             pastrInput.ToLower().IndexOf("../../") >= 0 ||
             pastrInput.ToLower().IndexOf(@"\..\..") >= 0 ||
             pastrInput.ToLower().IndexOf("passwd") >= 0 ||
             pastrInput.ToLower().IndexOf("shadow") >= 0 ||
             pastrInput.ToLower().IndexOf("%0a") >= 0 ||
             pastrInput.ToLower().IndexOf("%00") >= 0 ||
             pastrInput.ToLower().IndexOf("%25") >= 0 ||
             pastrInput.ToLower().IndexOf("%5c") >= 0 ||
             pastrInput.ToLower().IndexOf("\\&apos;") >= 0 ||
             pastrInput.ToLower().IndexOf("cat%20") >= 0 ||
             pastrInput.ToLower().IndexOf("&apos;") >= 0 ||
             pastrInput.ToLower().IndexOf("%u9090%u6858") >= 0 ||
             pastrInput.ToLower().IndexOf("%ucbd3%u7801%u9090%u6858%ucbd3%u7801%u9090%u6858%ucbd3") >= 0 ||
             pastrInput.ToLower().IndexOf("%u7801%u9090%u9090%u8190%u00c3%u0003%u8b00%u531b%u53ff") >= 0 ||
             pastrInput.ToLower().IndexOf("%u0078%u0000%u00=a") >= 0 ||
             pastrInput.ToLower().IndexOf("%u9090") >= 0 ||
             pastrInput.ToLower().IndexOf("0x90 0x90") >= 0 ||
             pastrInput.ToLower().IndexOf("..%c0%af") >= 0 ||
             pastrInput.ToLower().IndexOf("..%c1%9c") >= 0
            )
                {
                    blCharReturn = true;
                }
            }
            else 
            {
                blCharReturn = false;
            }

            return blCharReturn;
        }

    }
}








