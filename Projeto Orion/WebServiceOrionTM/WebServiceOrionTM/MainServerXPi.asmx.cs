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

namespace WebServiceXPi
{
    /// <summary>
    /// Descrição resumida de MainServerXPI
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    [System.Web.Script.Services.ScriptService]
    public class MainServerXPi : System.Web.Services.WebService
    {
        private LocalLog probjTrace = new LocalLog(ConfigParameters.ReturnWebConfig("PATH_TRACE"));

        [WebMethod]
        public DataSet MontaCarteiraDS(string public_token, string private_token, string CodCart, string strCodigoAtivoSBrain, string strAtivo_XP, string strCNPJ, string strNomeAtivo, string strCodigoTipoAtivo, string strConsideraCalculo, string strTemGrossup, string strDataVencimento, string strValorTaxa, string strIndice, string strTipoRemuneracao, string strValorAplicado)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IMontaCarteira(public_token, private_token, CodCart, strCodigoAtivoSBrain, strAtivo_XP, strCNPJ, strNomeAtivo, strCodigoTipoAtivo, strConsideraCalculo, strTemGrossup, strDataVencimento, strValorTaxa, strIndice, strTipoRemuneracao, strValorAplicado);
        }

        [WebMethod]
        public DataTable MontaCarteiraDT(string public_token, string private_token, string CodCart, string strCodigoAtivoSBrain, string strAtivo_XP, string strCNPJ, string strNomeAtivo, string strCodigoTipoAtivo, string strConsideraCalculo, string strTemGrossup, string strDataVencimento, string strValorTaxa, string strIndice, string strTipoRemuneracao, string strValorAplicado)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IMontaCarteira(public_token, private_token, CodCart, strCodigoAtivoSBrain, strAtivo_XP, strCNPJ, strNomeAtivo, strCodigoTipoAtivo, strConsideraCalculo, strTemGrossup, strDataVencimento, strValorTaxa, strIndice, strTipoRemuneracao, strValorAplicado).Tables[0];
        }

        [WebMethod]
        public DataSet ReturnDatasDS(string public_token, string private_token, string CodCart)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnDatasDS(public_token, private_token, CodCart);
        }

        [WebMethod]
        public DataTable ReturnDatasDT(string public_token, string private_token, string CodCart)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnDatasDS(public_token, private_token, CodCart).Tables[0];
        }

        [WebMethod]
        public DataSet ReturnIndexadoresDS(string public_token, string private_token)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnIndexadoresDS(public_token, private_token);
        }

        [WebMethod]
        public DataTable ReturnIndexadoresDT(string public_token, string private_token)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnIndexadoresDS(public_token, private_token).Tables[0];
        }

        [WebMethod]
        public DataSet ReturnGraficoRiscoRetornoNomesDS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRiscoRetornoNomesGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);
        }

        [WebMethod]
        public DataTable ReturnGraficoRiscoRetornoNomesDT(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRiscoRetornoNomesGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal).Tables[0];
        }


        [WebMethod]
        public DataSet ReturnGraficoRiscoRetornoDadosDS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRiscoRetornoDadosGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);
        }

        [WebMethod]
        public DataTable ReturnGraficoRiscoRetornoDadosDT(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRiscoRetornoDadosGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal).Tables[0];
        }

        [WebMethod]
        public DataSet ReturnGraficoRentabilidadeCarteiraDS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRentabilidadeCarteiraGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);
        }

        [WebMethod]
        public DataTable ReturnGraficoRentabilidadeCarteiraDT(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRentabilidadeCarteiraGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal).Tables[0];
        }

        [WebMethod]
        public DataSet ReturnPesquisaAtivosDS(string public_token, string private_token, string searchTerm, string cod_tip_atv)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnPesquisaAtivos(public_token, private_token, searchTerm, cod_tip_atv);
        }

        [WebMethod]
        public DataTable ReturnPesquisaAtivosDT(string public_token, string private_token, string searchTerm, string cod_tip_atv)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnPesquisaAtivos(public_token, private_token, searchTerm, cod_tip_atv).Tables[0];
        }

        [WebMethod]
        public DataSet ReturnGraficoRentabilidadeAtivosDS(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRentabilidadeAtivosGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal);
        }

        [WebMethod]
        public DataTable ReturnGraficoRentabilidadeAtivosDT(string public_token, string private_token, string CodCart, string CodIndexador, string Data, string DataFinal)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IReturnRentabilidadeAtivosGrafico(public_token, private_token, CodCart, CodIndexador, Data, DataFinal).Tables[0];
        }

        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //[WebMethod]
        //public void AConsultar(string public_token, string private_token, string Pesquisa)
        //{
        //    ISQLConnect iSQLConnect = new ISQLConnect();

        //    JavaScriptSerializer js = new JavaScriptSerializer();

        //    HttpContext.Current.Response.ContentType = "application/json";
        //    HttpContext.Current.Response.Write(Serialize(iSQLConnect.IReturnListaCarteirasDS(public_token, private_token, Pesquisa).Tables[0]));
        //    HttpContext.Current.Response.End();
        //}

        //private string Serialize(object value)
        //{
        //    Type type = value.GetType();
        //    Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();
        //    json.NullValueHandling = NullValueHandling.Ignore;
        //    json.ObjectCreationHandling = ObjectCreationHandling.Replace;
        //    json.MissingMemberHandling = MissingMemberHandling.Ignore;
        //    json.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //    if (type == typeof(DataTable))
        //        json.Converters.Add(new DataTableConverter());
        //    else if (type == typeof(DataSet))
        //        json.Converters.Add(new DataSetConverter());
        //    StringWriter sw = new StringWriter();
        //    Newtonsoft.Json.JsonTextWriter writer = new JsonTextWriter(sw);
        //    writer.Formatting = Newtonsoft.Json.Formatting.None;
        //    writer.QuoteChar = '"';
        //    json.Serialize(writer, value);
        //    string output = sw.ToString();
        //    writer.Close();
        //    sw.Close();
        //    return output;
        //}
        

        //[WebMethod]
        //public string ReturnUserDataXml(string public_token, string private_token, string Id)
        //{
        //    ISQLConnect iSQLConnect = new ISQLConnect();
        //    DataSet dsSaida = new DataSet();

        //    dsSaida = iSQLConnect.IReturnUserDataDS(public_token, private_token, Id);

        //    StringWriter writer = new StringWriter();
        //    dsSaida.Tables[0].WriteXml(writer, XmlWriteMode.IgnoreSchema, false);

        //    string cabecalhoXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        //    return string.Concat(cabecalhoXml, writer.ToString());
        //}
    }
}
