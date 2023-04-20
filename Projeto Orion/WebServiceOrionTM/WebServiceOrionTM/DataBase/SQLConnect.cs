using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Model;
using WebServicesOrionTM.Interface;
using System.Diagnostics;

namespace WebServicesOrionTM.DataBase
{
    public class SQLConnect
    {
        private LocalLog probjTrace = new LocalLog(ConfigParameters.ReturnWebConfig("PATH_TRACE"));

        private string InitConnecTionOrion()
        {
            try
            {
                return ConfigParameters.ReturnWebConfig("CONNOrion");
            }
            catch
            {
                return "";
            }
        }

        private bool VerificaAutenticacaoToken()
        {
            try
            {
                if (Convert.ToBoolean(ConfigParameters.ReturnWebConfig("VerificaTOKEN")))
                {
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool ValidPublicToken(string public_token)
        {
            bool blretorno = false;

            try
            {
                //To do, fazer validação de vários tokens na base de dados.
                //Necessário para trocar de tempos em tempos as chaves publicas.

                string strTokens = ConfigParameters.ReturnWebConfig("PUBLICTOKEN");
                string[] strTokenArray = strTokens.Split(new char[] { ';' });

                foreach (string strToken in strTokenArray)
                {
                    if (strToken == public_token)
                    {
                        blretorno = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                string teste = ex.ToString();
            }

            return blretorno;
        }

        public string[] ValidaTokens(string IdEquipament, string public_token, string private_token, string Task)
        {
            string[] strOut = new string[4];
            bool ExisteTask = false; 

            if (ValidPublicToken(public_token))
            {
                SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
                SqlCommand dbExecutarSP = new SqlCommand("ReturnIdTask", connDB);
                dbExecutarSP.CommandType = CommandType.StoredProcedure;

                SqlParameter parTerminalId = new SqlParameter("@TerminalId", SqlDbType.Int);
                parTerminalId.Direction = ParameterDirection.Input;
                parTerminalId.Value = Convert.ToInt32(IdEquipament);
                dbExecutarSP.Parameters.Add(parTerminalId);

                //SqlParameter parPublicToken = new SqlParameter("@PublicYoken", SqlDbType.NVarChar, 100);
                //parPublicToken.Direction = ParameterDirection.Input;
                //parPublicToken.Value = public_token;
                //dbExecutarSP.Parameters.Add(parPublicToken);

                //SqlParameter parValidPublicToken = new SqlParameter("@ValidPublicToken", SqlDbType.Bit);
                //parValidPublicToken.Direction = ParameterDirection.Input;

                //if (VerificaAutenticacaoToken())
                //{
                //    parValidPublicToken.Value = 1;
                //}
                //else
                //{
                //    parValidPublicToken.Value = 0;
                //}

                //dbExecutarSP.Parameters.Add(parValidPublicToken);
                try
                {
                    if (connDB.State == ConnectionState.Closed)
                    {
                        connDB.Open();
                    }

                    SqlDataReader dr = dbExecutarSP.ExecuteReader();

                    while (dr.Read())
                    {
                        //Status
                        strOut[0] = Convert.ToString(Status.GetName(typeof(Status), Convert.ToInt32(dr["Status"])));
                        //IdTask
                        strOut[1] = Convert.ToString(dr["IdTask"]);
                        //Task
                        strOut[2] = Convert.ToString(dr["Task"]);
                        //message
                        strOut[3] = Convert.ToString(Messages.GetName(typeof(Messages), Convert.ToInt32(dr["Message"])));
                        
                        ExisteTask = true;
                    }
                    dr.Close();

                    if (!ExisteTask)
                    {
                        strOut[0] = Convert.ToString(Status.ExecuteOk);
                        strOut[1] = "0";
                        strOut[2] = Convert.ToString(Tasks.Default);
                        strOut[3] = Convert.ToString(Messages.Ok); 
                    }

                    if (connDB.State == ConnectionState.Open)
                    {
                        connDB.Close();
                    }
                }
                catch (Exception ex)
                {
                    strOut[0] = Convert.ToString(Status.ExecuteError);
                    strOut[1] = "0";
                    strOut[2] = Convert.ToString(Tasks.Default);
                    strOut[3] = Convert.ToString(Messages.ConnectionDBError);
                }
                finally
                {
                    if (connDB.State == ConnectionState.Open)
                    {
                        connDB.Close();
                    }
                }
            }
            else
            {
                strOut[0] = Convert.ToString(Status.ExecuteError);
                strOut[1] = "0";
                strOut[2] = Convert.ToString(Tasks.Default);
                strOut[3] = Convert.ToString(Messages.ErrorValidationPublicToken);
            }
            
            return strOut;
        }


        //public string RetornaTaskReset(int IdSequencia, string public_token, string private_token)
        public string RetornaTaskReset(int IdSequencia)
        {
            bool ExisteTask = false;
            string strOut = "";
            
            //if (ValidPublicToken(public_token))
            //{
                SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
                SqlCommand dbExecutarSP = new SqlCommand("ReturnReset", connDB);
                dbExecutarSP.CommandType = CommandType.StoredProcedure;

                SqlParameter parIdSequencia = new SqlParameter("@Id_Sequencia", SqlDbType.Int);
                parIdSequencia.Direction = ParameterDirection.Input;
                parIdSequencia.Value = IdSequencia;
                dbExecutarSP.Parameters.Add(parIdSequencia);

                //SqlParameter parPublicToken = new SqlParameter("@PublicYoken", SqlDbType.NVarChar, 100);
                //parPublicToken.Direction = ParameterDirection.Input;
                //parPublicToken.Value = public_token;
                //dbExecutarSP.Parameters.Add(parPublicToken);

                //SqlParameter parValidPublicToken = new SqlParameter("@ValidPublicToken", SqlDbType.Bit);
                //parValidPublicToken.Direction = ParameterDirection.Input;

                //if (VerificaAutenticacaoToken())
                //{
                //    parValidPublicToken.Value = 1;
                //}
                //else
                //{
                //    parValidPublicToken.Value = 0;
                //}

                //dbExecutarSP.Parameters.Add(parValidPublicToken);
                try
                {
                    if (connDB.State == ConnectionState.Closed)
                    {
                        connDB.Open();
                    }

                    SqlDataReader dr = dbExecutarSP.ExecuteReader();

                    while (dr.Read())
                    {
                        //reset
                        strOut = Convert.ToString(TypeReset.GetName(typeof(TypeReset), Convert.ToInt16(dr["TipoReset"])));
                        
                        ExisteTask = true;
                    }
                    dr.Close();

                    if (!ExisteTask)
                    {
                        strOut = "";
                    }

                    if (connDB.State == ConnectionState.Open)
                    {
                        connDB.Close();
                    }
                }
                catch (Exception ex)
                {
                    strOut = "";
                }
                finally
                {
                    if (connDB.State == ConnectionState.Open)
                    {
                        connDB.Close();
                    }
                }
            //}
            //else
            //{
            //    strOut = "";
            //}

            return strOut;
        }


        public string RetornaTaskScript(int IdSequencia)
        {
            bool ExisteTask = false;
            string strOut = "";

            //if (ValidPublicToken(public_token))
            //{
            SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
            SqlCommand dbExecutarSP = new SqlCommand("ReturnScript", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parIdSequencia = new SqlParameter("@Id_Sequencia", SqlDbType.Int);
            parIdSequencia.Direction = ParameterDirection.Input;
            parIdSequencia.Value = IdSequencia;
            dbExecutarSP.Parameters.Add(parIdSequencia);

            //SqlParameter parPublicToken = new SqlParameter("@PublicYoken", SqlDbType.NVarChar, 100);
            //parPublicToken.Direction = ParameterDirection.Input;
            //parPublicToken.Value = public_token;
            //dbExecutarSP.Parameters.Add(parPublicToken);

            //SqlParameter parValidPublicToken = new SqlParameter("@ValidPublicToken", SqlDbType.Bit);
            //parValidPublicToken.Direction = ParameterDirection.Input;

            //if (VerificaAutenticacaoToken())
            //{
            //    parValidPublicToken.Value = 1;
            //}
            //else
            //{
            //    parValidPublicToken.Value = 0;
            //}

            //dbExecutarSP.Parameters.Add(parValidPublicToken);
            try
            {
                if (connDB.State == ConnectionState.Closed)
                {
                    connDB.Open();
                }

                SqlDataReader dr = dbExecutarSP.ExecuteReader();

                while (dr.Read())
                {
                    //reset
                    strOut = Convert.ToString(dr["TextScript"]);

                    ExisteTask = true;
                }
                dr.Close();

                if (!ExisteTask)
                {
                    strOut = "";
                }

                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            catch (Exception ex)
            {
                strOut = "";
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            //}
            //else
            //{
            //    strOut = "";
            //}

            return strOut;
        }

        public DataSet RetornaTaskUploadOnLine(int IdSequencia)
        {
            DataSet dsReturn = new DataSet();

            try
            {
                //if (ValidPrivateToken(public_token, private_token, "sp WS_RiscoRetornoNomesGraficov3"))
                {
                    SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    SqlCommand dbExecutarSP = new SqlCommand("ReturnUploadOnLine", connDB);
                    dbExecutarSP.CommandType = CommandType.StoredProcedure;

                    SqlParameter parIdSequencia = new SqlParameter("@Id_Sequencia", SqlDbType.Int);
                    parIdSequencia.Direction = ParameterDirection.Input;
                    parIdSequencia.Value = IdSequencia;
                    dbExecutarSP.Parameters.Add(parIdSequencia);

                    //SqlParameter parPublicToken = new SqlParameter("@PublicYoken", SqlDbType.NVarChar, 100);
                    //parPublicToken.Direction = ParameterDirection.Input;
                    //parPublicToken.Value = public_token;
                    //dbExecutarSP.Parameters.Add(parPublicToken);

                    //SqlParameter parValidPublicToken = new SqlParameter("@ValidPublicToken", SqlDbType.Bit);
                    //parValidPublicToken.Direction = ParameterDirection.Input;

                    //if (VerificaAutenticacaoToken())
                    //{
                    //    parValidPublicToken.Value = 1;
                    //}
                    //else
                    //{
                    //    parValidPublicToken.Value = 0;
                    //}

                    //dbExecutarSP.Parameters.Add(parValidPublicToken);

                    try
                    {
                        if (connDB.State == ConnectionState.Closed)
                        {
                            connDB.Open();
                        }

                        dataAdapter.SelectCommand = dbExecutarSP;
                        dataAdapter.Fill(dsReturn, "UploadOnLine");

                        if (connDB.State == ConnectionState.Open)
                        {
                            connDB.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    finally
                    {
                        if (connDB.State == ConnectionState.Open)
                        {
                            connDB.Close();
                        }
                    }

                    return dsReturn;
                }
            }
            catch (Exception ex)
            {
            }

            return dsReturn;
        }

        public DataSet RetornaTaskDownloadPackage(int IdSequencia)
        {
            DataSet dsReturn = new DataSet();

            try
            {
                //if (ValidPrivateToken(public_token, private_token, "sp WS_RiscoRetornoNomesGraficov3"))
                {
                    SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    SqlCommand dbExecutarSP = new SqlCommand("ReturnDownloadPackage", connDB);
                    dbExecutarSP.CommandType = CommandType.StoredProcedure;

                    SqlParameter parIdSequencia = new SqlParameter("@Id_Sequencia", SqlDbType.Int);
                    parIdSequencia.Direction = ParameterDirection.Input;
                    parIdSequencia.Value = IdSequencia;
                    dbExecutarSP.Parameters.Add(parIdSequencia);

                    //SqlParameter parPublicToken = new SqlParameter("@PublicYoken", SqlDbType.NVarChar, 100);
                    //parPublicToken.Direction = ParameterDirection.Input;
                    //parPublicToken.Value = public_token;
                    //dbExecutarSP.Parameters.Add(parPublicToken);

                    //SqlParameter parValidPublicToken = new SqlParameter("@ValidPublicToken", SqlDbType.Bit);
                    //parValidPublicToken.Direction = ParameterDirection.Input;

                    //if (VerificaAutenticacaoToken())
                    //{
                    //    parValidPublicToken.Value = 1;
                    //}
                    //else
                    //{
                    //    parValidPublicToken.Value = 0;
                    //}

                    //dbExecutarSP.Parameters.Add(parValidPublicToken);

                    try
                    {
                        if (connDB.State == ConnectionState.Closed)
                        {
                            connDB.Open();
                        }

                        dataAdapter.SelectCommand = dbExecutarSP;
                        dataAdapter.Fill(dsReturn, "DownloadPackage");

                        if (connDB.State == ConnectionState.Open)
                        {
                            connDB.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        if (connDB.State == ConnectionState.Open)
                        {
                            connDB.Close();
                        }
                    }

                    return dsReturn;
                }
            }
            catch (Exception ex)
            {
            }

            return dsReturn;
        }

        public string UpdateStatus(int IdSequencia, string TipoOper, int Status)
        {
            string saida = "0";
                        
            SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
            SqlCommand dbExecutarSP = new SqlCommand("UpdateStatus", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parIdSequencia = new SqlParameter("@Id_Sequencia", SqlDbType.Int);
            parIdSequencia.Direction = ParameterDirection.Input;
            parIdSequencia.Value = IdSequencia;
            dbExecutarSP.Parameters.Add(parIdSequencia);

            SqlParameter parTipoOper = new SqlParameter("@Tipo_Oper", SqlDbType.VarChar, 50);
            parTipoOper.Direction = ParameterDirection.Input;
            parTipoOper.Value = TipoOper;
            dbExecutarSP.Parameters.Add(parTipoOper);

            SqlParameter parStatusId = new SqlParameter("@Status_Id", SqlDbType.Int);
            parStatusId.Direction = ParameterDirection.Input;
            parStatusId.Value = Status;
            dbExecutarSP.Parameters.Add(parStatusId);

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

                saida = "Ok";
            }
            catch (Exception ex)
            {
                saida = "Erro DB";
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }
            
            return saida;
        }

        public bool UpdateHeartBeat(string IdEquipment, string Version)
        {
            bool saida = false;

            SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
            SqlCommand dbExecutarSP = new SqlCommand("UpdateHeartBeat", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parTerminalId = new SqlParameter("@TerminalId", SqlDbType.Int);
            parTerminalId.Direction = ParameterDirection.Input;
            parTerminalId.Value = Convert.ToInt32(IdEquipment);
            dbExecutarSP.Parameters.Add(parTerminalId);

            SqlParameter parVersion = new SqlParameter("@Version", SqlDbType.VarChar, 100);
            parVersion.Direction = ParameterDirection.Input;
            parVersion.Value = Version;
            dbExecutarSP.Parameters.Add(parVersion);

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

                saida = true;
            }
            catch (Exception ex)
            {
                saida = false;
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }

            return saida;
        }


        public string UpdateUploadOnLineFileReceivedUrl(int IdSequencia, string FileReceivedUrl)
        {
            string saida = "0";

            SqlConnection connDB = new SqlConnection(InitConnecTionOrion());
            SqlCommand dbExecutarSP = new SqlCommand("UpdateFileReceivedUrl", connDB);
            dbExecutarSP.CommandType = CommandType.StoredProcedure;

            SqlParameter parIdSequencia = new SqlParameter("@Id_Sequencia", SqlDbType.Int);
            parIdSequencia.Direction = ParameterDirection.Input;
            parIdSequencia.Value = IdSequencia;
            dbExecutarSP.Parameters.Add(parIdSequencia);

            SqlParameter parTipoOper = new SqlParameter("@File_Received_Url", SqlDbType.VarChar, 500);
            parTipoOper.Direction = ParameterDirection.Input;
            parTipoOper.Value = FileReceivedUrl;
            dbExecutarSP.Parameters.Add(parTipoOper);

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

                saida = "Ok";
            }
            catch (Exception ex)
            {
                saida = "Erro DB";
            }
            finally
            {
                if (connDB.State == ConnectionState.Open)
                {
                    connDB.Close();
                }
            }

            return saida;
        }

    }
}