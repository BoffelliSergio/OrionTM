using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Services;
using WebServiceXPiAuth.Interface;
using WebServiceXPiAuth.Infra;

namespace WebServiceXPiAuth
{
    /// <summary>
    /// Descrição resumida de MainServerXPi
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
        public string Auth(string public_token)
        {
            ISQLConnect iSQLConnect = new ISQLConnect();
            return iSQLConnect.IAuth(public_token);
        }
    }
}
