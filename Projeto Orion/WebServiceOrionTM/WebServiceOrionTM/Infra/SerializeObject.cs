using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.IO;

using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace WebServicesOrionTM.Infra.Serialize
{
    public class SerializeObject
    {
        public static Exception Error;

        public SerializeObject()
        {
        }

        ~SerializeObject()
        {
        }

        public static string Serialize(object paobjSerializable)
        {
            try
            {
                Error = null;
                
                System.Type objType = paobjSerializable.GetType();

                XmlSerializer objSerializer = new XmlSerializer(objType);
                StringWriter objStringWriter = new StringWriter();
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(objStringWriter);

                objSerializer.Serialize(objXmlTextWriter, paobjSerializable);


                return objStringWriter.ToString();

            }
            catch (Exception Ex)
            {
                Error = Ex;
                return null;
            }
        }

        public static bool Serialize(object paobjSerializable, string pastrFileDestination)
        {
            try
            {
                Error = null;
                
                System.Type objType = paobjSerializable.GetType();

                System.Xml.Serialization.XmlSerializer objSerializer = new System.Xml.Serialization.XmlSerializer(objType);
                System.IO.Stream objFS = new System.IO.FileStream(pastrFileDestination, System.IO.FileMode.Create);
                System.Xml.XmlTextWriter objXmlTextWriter = new System.Xml.XmlTextWriter(objFS, new System.Text.UTF8Encoding());
                objSerializer.Serialize(objXmlTextWriter, paobjSerializable);
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




        

        

        