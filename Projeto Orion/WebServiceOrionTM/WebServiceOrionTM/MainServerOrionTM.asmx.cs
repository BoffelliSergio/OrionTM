using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Services;
using WebServicesOrionTM.Interface;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Infra.Serialize;
using WebServicesOrionTM.Infra.Deserialize;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web.Script.Services;
using System.Web.Security.AntiXss;
using WebServicesOrionTM.Model;
using System.Xml.Serialization;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.ModelWebService.Entity;

namespace WebServicesOrionTM
{
    /// <summary>
    /// Summary description for MainServerOrionTM
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Description = "Orion Equipment Messenger")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MainServerOrionTM : System.Web.Services.WebService
    {
        private IContainer components = null;
        public MainServerOrionTM()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            LocalLog.Trace = new LocalLog(System.Configuration.ConfigurationManager.AppSettings["PATH_TRACE"].ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        [WebMethod(Description = "Equipments Messengers", EnableSession = true)]
        public string Messenger(string pastrMsg)
        {
            WSCommon objFunctions;

            LocalLog.Trace.WriteLogText("Messenger() ´Message received" + pastrMsg);

            try
            {
                string strHttpCurrentRequesrUserHostAddress;

                try
                {
                    strHttpCurrentRequesrUserHostAddress = AntiXssEncoder.HtmlFormUrlEncode(HttpContext.Current.Request.UserHostAddress.Trim());
                }
                catch
                {
                    strHttpCurrentRequesrUserHostAddress = "";
                }

                object objReceived = DeserializeObject.Descerialize(pastrMsg, "WebServicesOrionTM.ModelWebService.Entity");

                LocalLog.Trace.WriteLogText("objReceived.GetType().Name =" + objReceived.GetType().Name);

                switch (objReceived.GetType().Name)
                {
                    
                    case "UploadOnLineParameter":
                        objFunctions = new UploadOnLineParameterWS();
                        return SerializeObject.Serialize(objFunctions.Parameter((UploadOnLineParameter)objReceived));

                    case "UploadOnLineSend":
                        objFunctions = new UploadOnLineSendWS();
                        return SerializeObject.Serialize(objFunctions.Send((UploadOnLineSend)objReceived));

                    case "UploadOnLineStatistic":
                        objFunctions = new UploadOnLineStatisticWS();
                        return SerializeObject.Serialize(objFunctions.Statistic((UploadOnLineStatistic)objReceived));

                    case "ResetParameter":
                        objFunctions = new ResetParameterWS();
                        return SerializeObject.Serialize(objFunctions.Parameter((ResetParameter)objReceived));

                    case "ResetStatistic":
                        objFunctions = new ResetStatisticWS();
                        return SerializeObject.Serialize(objFunctions.Statistic((ResetStatistic)objReceived));

                    case "ScriptParameter":
                        objFunctions = new ScriptParameterWS();
                        return SerializeObject.Serialize(objFunctions.Parameter((ScriptParameter)objReceived));

                    case "ScriptStatistic":
                        objFunctions = new ScriptStatisticWS();
                        return SerializeObject.Serialize(objFunctions.Statistic((ScriptStatistic)objReceived));

                    case "DownloadPackageParameter":
                        objFunctions = new DownloadPackageParameterWS();
                        return SerializeObject.Serialize(objFunctions.Parameter((DownloadPackageParameter)objReceived));

                    case "DownloadPackageSend":
                        objFunctions = new DownloadPackageSendWS();
                        return SerializeObject.Serialize(objFunctions.Send((DownloadPackageSend)objReceived));

                    case "DownloadPackageStatistic":
                        objFunctions = new DownloadPackageStatisticWS();
                        return SerializeObject.Serialize(objFunctions.Statistic((DownloadPackageStatistic)objReceived));

                    default:
                        LocalLog.Trace.WriteLogText("MainServerOrionTM.Messenger() ", string.Concat("An error occured. Messenger object not found. RemoteHost=", strHttpCurrentRequesrUserHostAddress, "MessageName ", objReceived.GetType().Name), new Exception("Message not identifier."));
                        return null;
                }
            }
            catch (Exception eX)
            {
                string strHttpCurrentRequesrUserHostAddress;

                try
                {
                    strHttpCurrentRequesrUserHostAddress = AntiXssEncoder.HtmlFormUrlEncode(HttpContext.Current.Request.UserHostAddress.Trim());

                }
                catch
                {
                    strHttpCurrentRequesrUserHostAddress = "";
                }

                LocalLog.Trace.WriteLogText("Messenger()", string.Concat("An error occurred when received a message. RemoteHost=", Microsoft.Security.Application.AntiXss.HtmlEncode(strHttpCurrentRequesrUserHostAddress), eX));
                return "";
            }
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Equipments Tasks Jason", EnableSession = true)]
        [XmlInclude(typeof(Orion))]
        public string VerificaTaskJS(string strIdEquipment, string strPublKey, string strPrivKey, string strTask)
        { 
            HttpContext.Current.Response.ContentType = "application/json";

            ISQLConnect iSQLConnect = new ISQLConnect();
            
            Orion myOrionobject = new Orion();
            myOrionobject.IdEquipment = strIdEquipment;
            myOrionobject.PublicToken = strPublKey;
            myOrionobject.PrivateToken = strPrivKey;
            myOrionobject.Task = strTask;
            myOrionobject.IdTask = "0";
            myOrionobject.Message = "";

            //Verificação da autorização. O banco de dados vai retornar o id da task IdTask 
            string[] FinalOut = iSQLConnect.IValidaTokensERetornaIdTask(myOrionobject);

            //Monta o retorno para o Client
            RetornoOrion retornoOrion = new RetornoOrion();
            retornoOrion.IdEquipment = strIdEquipment;
            retornoOrion.Task = FinalOut[2];
            retornoOrion.IdTask = FinalOut[1];
            retornoOrion.Message = FinalOut[3];
            retornoOrion.Status = FinalOut[0];

            return Serialize(retornoOrion);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Equipments Tasks Jason", EnableSession = true)]
        [XmlInclude(typeof(Orion))]
        public string RecebeHeartBeatJS(string strIdEquipment, string strVersion)
        {
            HttpContext.Current.Response.ContentType = "application/json";

            ISQLConnect iSQLConnect = new ISQLConnect();

            HeartBeat heartbeat = new HeartBeat();

            heartbeat.IdEquipment = strIdEquipment;
            heartbeat.Version = strVersion;
            heartbeat.Task = "heartbeat";

            if (iSQLConnect.IUpdateHeartBeat(heartbeat))
            {
                heartbeat.Status = Convert.ToString(Status.ExecuteOk);
            }
            else
            {
                heartbeat.Status = Convert.ToString(Status.ExecuteError);
            }

            return Serialize(heartbeat);
        }


        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //[WebMethod]
        //public string RetornaStatusComandos(string IdEquipment, string PubKey, string PrivKey, string IdTask, string Task)
        //{
        //    ISQLConnect iSQLConnect = new ISQLConnect();
        //    HttpContext.Current.Response.ContentType = "application/json";

        //    Orion myOrionobject = new Orion();
        //    myOrionobject.IdEquipment = IdEquipment;
        //    myOrionobject.PublicToken = PrivKey;
        //    myOrionobject.PrivateToken = PubKey;
        //    myOrionobject.Task = Task;
        //    myOrionobject.IdTask = IdTask;
        //    myOrionobject.Message = "";

        //    //Atualiza o status da IdTask
        //    string saidafinal = iSQLConnect.IAtualizaStatusIdTask(myOrionobject);

        //    //Monta o retorno para o Client
        //    RetornoOrion retornoOrion = new RetornoOrion();
        //    retornoOrion.IdEquipment = IdEquipment;
        //    retornoOrion.IdTask = IdTask;
        //    retornoOrion.Task = Task;
        //    retornoOrion.Status = saidafinal;
        //    retornoOrion.Message = Convert.ToString(Status.GetValues(typeof(Status)).GetValue(saidafinal[1]));

        //    return Serialize(retornoOrion);
        //}

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




































    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public string ReturnDatasJS(string public_token, string private_token, string CodCart)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    HttpContext.Current.Response.ContentType = "application/json";

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnDatasDS(public_token, private_token, CodCart);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();

    //    return Serialize(retornoSB);
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnIndexadoresJS(string public_token, string private_token)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnIndexadoresDS(public_token, private_token);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }
    //    HttpContext.Current.Response.End();
    //}

    ////novos 2019-02-14
    ////Antigo - substituído pelo abaixo.
    ////Saida de forma vertical
    ////Retirado o paramêtro "DataFinal"
    ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    ////[WebMethod]
    ////public void ReturnRiscoRetornoNomesGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    ////{
    ////    ISQLConnect iSQLConnect = new ISQLConnect();
    ////    JavaScriptSerializer js = new JavaScriptSerializer();

    ////DataSet DsSaida = new DataSet();
    ////DsSaida = iSQLConnect.IReturnRiscoRetornoNomesGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    ////    if (DsSaida.Tables.Count == 0)
    ////    {
    ////        string json = "Message{StatusCode: 400}";
    ////        HttpContext.Current.Response.Write(Serialize(json));
    ////    }
    ////    else
    ////    {
    ////        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    ////    }
    ////    HttpContext.Current.Response.End();
    ////}

    ////novos 2019-02-14
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRiscoRetornoNomesGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRiscoRetornoNomesGraficoVertical(public_token, private_token, CodCart, CodIndexador, Data);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    ////novos 2019-02-14
    ////Antigo - substituído pelo abaixo.
    ////Saida de forma vertical
    ////Retirado o paramêtro "DataFinal"
    ////[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    ////[WebMethod]
    ////public void ReturnRiscoRetornoDadosGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    ////{
    ////    ISQLConnect iSQLConnect = new ISQLConnect();
    ////    JavaScriptSerializer js = new JavaScriptSerializer();

    ////    DataSet DsSaida = new DataSet();
    ////    DsSaida = iSQLConnect.IReturnRiscoRetornoDadosGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    ////    if (DsSaida.Tables.Count == 0)
    ////    {
    ////        string json = "Message{StatusCode: 400}";
    ////        HttpContext.Current.Response.Write(Serialize(json));
    ////    }
    ////    else
    ////    {
    ////        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    ////    }

    ////    HttpContext.Current.Response.End();

    ////}

    ////novos 2019-02-14
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRiscoRetornoDadosGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    HttpContext.Current.Response.ContentType = "application/json";

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRiscoRetornoDadosGraficoVertical(public_token, private_token, CodCart, CodIndexador, Data);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}


    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRentabilidadeCarteiraGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRentabilidadeCarteiraGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnPesquisaAtivosJS(string public_token, string private_token, string searchTerm, string CodTipoAtivo)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnPesquisaAtivos(public_token, private_token, searchTerm, CodTipoAtivo);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRentabilidadeAtivosGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRentabilidadeAtivosGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRentabilidadeAtivosJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRentabilidadeAtivos(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}


    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRentabilidadeAtivosSBJS(string public_token, string private_token, string CodCart, string CodAtv, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRentabilidadeAtivosSB(public_token, private_token, CodCart, CodAtv, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnRentabilidadeCarteiraJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnRentabilidadeCarteira(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnAlocacaoClasseGraficoJS(string public_token, string private_token, string CodCart, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnAlocacaoClasseGrafico(public_token, private_token, CodCart, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnAlocacaoClasseJS(string public_token, string private_token, string CodCart, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnAlocacaoClasse(public_token, private_token, CodCart, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnLiquidezGraficoJS(string public_token, string private_token, string CodCart, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnLiquidezGrafico(public_token, private_token, CodCart, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnVolatilidadeCarteiraGraficoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnVolatilidadeCarteiraGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnVolatilidadeCarteiraJS(string public_token, string private_token, string CodCart, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnVolatilidadeCarteira(public_token, private_token, CodCart, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnCorrelacaoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnCorrelacao(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnUnderwaterGraficoJS(string public_token, string private_token, string CodCart, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnUnderWaterGrafico(public_token, private_token, CodCart, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnClassesJS(string public_token, string private_token)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnClasses(public_token, private_token);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnTiposRemuneracaoJS(string public_token, string private_token)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnTiposRemuneracao(public_token, private_token);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}

    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnAnaliseDeRiscoJS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnAnaliseDeRisco(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}


    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //[WebMethod]
    //public void ReturnDataOtimoJS(string public_token, string private_token, string CodCart)
    //{
    //    ISQLConnect iSQLConnect = new ISQLConnect();
    //    JavaScriptSerializer js = new JavaScriptSerializer();

    //    DataSet DsSaida = new DataSet();
    //    DsSaida = iSQLConnect.IReturnDataOtimo(public_token, private_token, CodCart);

    //    if (DsSaida.Tables.Count == 0)
    //    {
    //        string json = "Message{StatusCode: 400}";
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(json));
    //    }
    //    else
    //    {
    //        HttpContext.Current.Response.ContentType = "application/json";
    //        HttpContext.Current.Response.Write(Serialize(DsSaida.Tables[0]));
    //    }

    //    HttpContext.Current.Response.End();
    //}



