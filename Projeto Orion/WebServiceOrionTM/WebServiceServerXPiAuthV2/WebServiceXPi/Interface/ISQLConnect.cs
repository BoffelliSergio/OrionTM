using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebServiceXPiAuth.DataBase;

namespace WebServiceXPiAuth.Interface
{
    public class ISQLConnect
    {
        public ISQLConnect()
        {
        }

        ~ISQLConnect()
        {
        }

        public string IAuth(string public_token)
        {
            string hexkey1 = "";
            //hexkey1 = AESEncryptoDecrypto.generate_key();

            SQLConnect sqlconnect = new SQLConnect();
            if (sqlconnect.SQLAuth(public_token))
            {
                hexkey1 = sqlconnect.SQLGeraTokenPrivado(public_token);
                //hexkey1 = AESEncryptoDecrypto.generate_key();
                //Insere o controle do novo token
                sqlconnect.InsereTokenPrivado(public_token, hexkey1);
                return hexkey1;
            }
            else
            {
                return public_token;
            }
        }

        //public DataSet IReturnFeedsDS(string public_token, string private_token, string Ano, string Mes, string Dia, string Id)
        //{
        //    SQLConnect sqlconnect = new SQLConnect();
        //    return sqlconnect.ReturnFeeds(public_token, private_token, Ano, Mes, Dia, Id);
        //}
    }
}