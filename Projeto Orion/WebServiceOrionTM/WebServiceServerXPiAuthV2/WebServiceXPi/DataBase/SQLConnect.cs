using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebServiceXPiAuth.Infra;

namespace WebServiceXPiAuth.DataBase
{
    public class SQLConnect
    {
        private LocalLog probjTrace = new LocalLog(ConfigParameters.ReturnWebConfig("PATH_TRACE"));

        private string InitConnecTion(string public_token)
        {
            try
            {
                return ConfigParameters.ReturnWebConfig("CONN");
            }
            catch
            {
                return "";
            }
        }

        private bool ValidPrivateToken(string public_token, string private_token, string Oper)
        {
            bool blretorno = false;

            SqlConnection connDB = new SqlConnection(InitConnecTion(public_token));
            SqlCommand dbExecutarSP = new SqlCommand("VerificaStatusTokenPrivado", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parTokenPublico = new SqlParameter("@tokenpublico", SqlDbType.NVarChar, 100);
            parTokenPublico.Direction = ParameterDirection.Input;
            parTokenPublico.Value = public_token;
            dbExecutarSP.Parameters.Add(parTokenPublico);

            SqlParameter parTokenPrivado = new SqlParameter("@tokenprivado", SqlDbType.NVarChar, 100);
            parTokenPrivado.Direction = ParameterDirection.Input;
            parTokenPrivado.Value = private_token;
            dbExecutarSP.Parameters.Add(parTokenPrivado);

            SqlParameter parOper = new SqlParameter("@Oper", SqlDbType.NVarChar, 100);
            parOper.Direction = ParameterDirection.Input;
            parOper.Value = Oper;
            dbExecutarSP.Parameters.Add(parOper);

            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB.Open();
                }

                SqlDataReader dr = dbExecutarSP.ExecuteReader();

                while (dr.Read())
                {
                    blretorno = Convert.ToBoolean(dr["status"]);
                }

                dr.Close();

                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            catch (Exception ex)
            {
                string teste = ex.ToString();
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }

            return blretorno;
        }

        private void SQLChangeStatusPublicToken(string public_token, string private_token)
        {
            SqlConnection connDB = new SqlConnection(InitConnecTion(public_token));
            SqlCommand dbExecutarSP = new SqlCommand("AlteraStatusTokenPrivado", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parTokenPublico = new SqlParameter("@tokenpublico", SqlDbType.NVarChar, 100);
            parTokenPublico.Direction = ParameterDirection.Input;
            parTokenPublico.Value = public_token;
            dbExecutarSP.Parameters.Add(parTokenPublico);

            SqlParameter parTokenPrivado = new SqlParameter("@tokenprivado", SqlDbType.NVarChar, 100);
            parTokenPrivado.Direction = ParameterDirection.Input;
            parTokenPrivado.Value = private_token;
            dbExecutarSP.Parameters.Add(parTokenPrivado);

            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB.Open();
                }

                dbExecutarSP.ExecuteNonQuery();

                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            catch (Exception ex)
            {
                string teste = ex.ToString();
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
        }

        public bool SQLAuth(string public_token)
        {
            bool blretorno = false;

            SqlConnection connDB = new SqlConnection(InitConnecTion(public_token));
            SqlCommand dbExecutarSP = new SqlCommand("VerificaTokenCadastrado", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parToken = new SqlParameter("@token", SqlDbType.NVarChar, 100);
            parToken.Direction = ParameterDirection.Input;
            parToken.Value = public_token;
            dbExecutarSP.Parameters.Add(parToken);

            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB.Open();
                }

                SqlDataReader dr = dbExecutarSP.ExecuteReader();

                while (dr.Read())
                {
                    blretorno = Convert.ToBoolean(dr["existe"]);
                }

                dr.Close();

                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            catch (Exception ex)
            {
                string teste = ex.ToString();
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }

            return blretorno;
        }

        public string SQLGeraTokenPrivado(string public_token)
        {
            string strretorno = "";

            SqlConnection connDB = new SqlConnection(InitConnecTion(public_token));
            SqlCommand dbExecutarSP = new SqlCommand("GeraToken", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB.Open();
                }

                SqlDataReader dr = dbExecutarSP.ExecuteReader();

                while (dr.Read())
                {
                    strretorno = Convert.ToString(dr["token"]);
                }

                dr.Close();

                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            catch (Exception ex)
            {
                string teste = ex.ToString();
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }

            return strretorno;
        }

        public void InsereTokenPrivado(string public_token, string private_token)
        {
            SqlConnection connDB = new SqlConnection(InitConnecTion(public_token));
            SqlCommand dbExecutarSP = new SqlCommand("InsereStatusTokenPrivado", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parTokenPublico = new SqlParameter("@tokenpublico", SqlDbType.NVarChar, 100);
            parTokenPublico.Direction = ParameterDirection.Input;
            parTokenPublico.Value = public_token;
            dbExecutarSP.Parameters.Add(parTokenPublico);

            SqlParameter parTokenPrivado = new SqlParameter("@tokenprivado", SqlDbType.NVarChar, 100);
            parTokenPrivado.Direction = ParameterDirection.Input;
            parTokenPrivado.Value = private_token;
            dbExecutarSP.Parameters.Add(parTokenPrivado);

            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB.Open();
                }

                dbExecutarSP.ExecuteNonQuery();

                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            catch (Exception ex)
            {
                string teste = ex.ToString();
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
        }
    }
}