using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Services;
using WebServiceXPi.Interface;
using WebServiceXPi.Infra;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using WebServiceServerSimuladorXP.Models;
using System.Web.Http;
namespace WebServiceServerSimuladorXP
{
    /// <summary>
    /// Summary description for MainServerXPiJsonMontaCarteira
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MainServerXPiJsonMontaCarteira : System.Web.Services.WebService
    {
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //[WebMethod]
        //public void MontaCarteiraObjectJS(SmartBrain sbObject)
        //{
        //    ISQLConnect iSQLConnect = new ISQLConnect();

        //    SmartBrain mySBobject = new SmartBrain();
        //    mySBobject = sbObject;

        //    string descricao = iSQLConnect.IMontaCarteiraObjectJS(sbObject);
        //    string json = "Message{StatusCode:" + descricao + "}";

        //    HttpContext.Current.Response.ContentType = "application/json";
        //    HttpContext.Current.Response.Write(Serialize(json));
        //    HttpContext.Current.Response.End();
        //}

        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //[WebMethod]
        //public string MontaCarteiraObjectJS(SmartBrain sbObject)
        //{
        //    ISQLConnect iSQLConnect = new ISQLConnect();
        //    //HttpContext.Current.Response.ContentType = "application/json";

        //    SmartBrain mySBobject = new SmartBrain();
        //    mySBobject = sbObject;

        //    string descricao = iSQLConnect.IMontaCarteiraObjectJS(sbObject);
        //    RetornoSmartBrain retornoSB = new RetornoSmartBrain();
        //    retornoSB.CodigoCarteira = descricao;

        //    return Serialize(retornoSB);
        //    //HttpContext.Current.Response.Write(Serialize(retornoSB));

        //    //HttpContext.Current.Response.End();
        //}

        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        [WebMethod]
        public string Ateste(SmartBrain sbObject)
        {
            //ISQLConnect iSQLConnect = new ISQLConnect();
            //HttpContext.Current.Response.ContentType = "application/json";

            SmartBrain mySBobject = new SmartBrain();
            mySBobject = sbObject;

            //string descricao = iSQLConnect.IMontaCarteiraObjectJS(sbObject);
            RetornoSmartBrain retornoSB = new RetornoSmartBrain();

            //retornoSB.CodigoCarteira = descricao;

            retornoSB.CodigoCarteira = "teste";

            return Serialize(retornoSB);
            //HttpContext.Current.Response.Write(Serialize(retornoSB));

            //HttpContext.Current.Response.End();
        }


        private string Serialize(object value)
        {
            Type type = value.GetType();
            Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();
            json.NullValueHandling = NullValueHandling.Ignore;
            json.ObjectCreationHandling = ObjectCreationHandling.Replace;
            json.MissingMemberHandling = MissingMemberHandling.Ignore;
            json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            if (type == typeof(DataTable))
                json.Converters.Add(new DataTableConverter());
            else if (type == typeof(DataSet))
                json.Converters.Add(new DataSetConverter());
            StringWriter sw = new StringWriter();
            Newtonsoft.Json.JsonTextWriter writer = new JsonTextWriter(sw);
            writer.Formatting = Newtonsoft.Json.Formatting.None;
            writer.QuoteChar = '"';
            json.Serialize(writer, value);
            string output = sw.ToString();
            writer.Close();
            sw.Close();
            return output;
        }
    }
}
