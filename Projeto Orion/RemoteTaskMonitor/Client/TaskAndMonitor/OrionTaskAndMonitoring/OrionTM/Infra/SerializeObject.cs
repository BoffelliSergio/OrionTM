using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;


namespace OrionTMClient.Infra.Serialize
{
    /// <summary>
    /// Serializa e Descerializa objetos em XML
    /// </summary>
    public class SerializeObject
    {
        public static Exception Error;

        public SerializeObject()
        {
        }

        ~SerializeObject()
        {
        }

        public static string Serialize(object paSerializeObj)
        {
            try
            {
                Error = null;
                System.Type objType = paSerializeObj.GetType();

                System.Xml.Serialization.XmlSerializer objSerializer = new System.Xml.Serialization.XmlSerializer(objType);
                System.IO.StringWriter objStringWriter = new System.IO.StringWriter();
                System.Xml.XmlTextWriter objXmlTextWriter = new System.Xml.XmlTextWriter(objStringWriter);

                objSerializer.Serialize(objXmlTextWriter, paSerializeObj);

                bool blGeraXmlTransmissao = false;
                string strPathDestinoXml = "";

                
                if (blGeraXmlTransmissao)
                {
                    StreamWriter objArq = null;
                    string strNomeXml = string.Concat("OrionClientSend", DateTime.Now.Year.ToString("0000"),
                        DateTime.Now.Month.ToString("00"),
                        DateTime.Now.Day.ToString("00"),
                        DateTime.Now.Hour.ToString("00"),
                        DateTime.Now.Minute.ToString("00"),
                        DateTime.Now.Second.ToString("00"),
                        DateTime.Now.Millisecond.ToString("000"), ".xml");

                    if (!Directory.Exists(@strPathDestinoXml))
                    {
                        Directory.CreateDirectory(@strPathDestinoXml);
                    }

                    string strXmltemp = objStringWriter.ToString();

                    objArq = File.AppendText(Path.Combine(@strPathDestinoXml, strNomeXml));
                    objArq.WriteLine(strXmltemp);
                    objArq.Flush();
                    objArq.Close();

                    objArq = null;
                }

                objType = null;
                objSerializer = null;
                objStringWriter.Close();
                objXmlTextWriter.Close();

                return objStringWriter.ToString();
            }
            catch (Exception Ex)
            {
                Error = Ex;
                return null;
            }
        }

        public static bool Serialize(object paSerializeObj, string pastrUrlFile)
        {
            try
            {
                Error = null;
                System.Type objType = paSerializeObj.GetType();
                System.Xml.Serialization.XmlSerializer objSerializer = new System.Xml.Serialization.XmlSerializer(objType);
                System.IO.Stream objFS = new System.IO.FileStream(pastrUrlFile, System.IO.FileMode.Create);
                System.Xml.XmlTextWriter objXmlTextWriter = new System.Xml.XmlTextWriter(objFS, new System.Text.UTF8Encoding());
                objSerializer.Serialize(objXmlTextWriter, paSerializeObj);

                objType = null;
                objSerializer = null;
                objXmlTextWriter.Close();
                objFS.Close();
                return true;
            }
            catch (Exception Ex)
            {
                Error = Ex;
                return false;
            }
        }
    }
}
