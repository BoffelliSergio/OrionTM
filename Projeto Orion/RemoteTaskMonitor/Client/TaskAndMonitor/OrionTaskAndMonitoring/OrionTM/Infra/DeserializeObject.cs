using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace OrionTMClient.Infra
{
    /// <summary>
    /// Serializa e Descerializa objetos em XML
    /// </summary>
    public class DeserializeObject
    {
        public static Exception Error;

        public DeserializeObject()
        {
        }

        ~DeserializeObject()
        {
        }

        public static object Descerialize(string pastrObjXML)
        {
            Error = null;

            System.IO.StringReader objStringReader = new System.IO.StringReader(pastrObjXML);
            System.Xml.XmlReader objXmlReader = new System.Xml.XmlTextReader(objStringReader);

            try
            {
                string strClassName = "";

                //Obtem o tipo da classe a ser descerializada
                if (objXmlReader.IsStartElement())
                {
                    strClassName = objXmlReader.LocalName;
                }
                
                System.Type objType = Type.GetType(string.Concat("OrionTMClient.Entity.", strClassName));
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

        public static object Descerialize(string pastrFileSource, string pastrClassName)
        {
            Error = null;

            System.IO.Stream objFS = new System.IO.FileStream(pastrFileSource, System.IO.FileMode.Open);

            try
            {
                System.Type objType = Type.GetType(string.Concat("OrionTMClient.Entity.", pastrClassName));

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
    }
}
