using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using WebServicesOrionTM.ControllersWS;
using WebServicesOrionTM.Infra;
using WebServicesOrionTM.Interface;
using WebServicesOrionTM.ModelWebService.Entity;
using System.Web.UI.WebControls;
using System.CodeDom.Compiler;
using System.Data.Odbc;

namespace WebServicesOrionTM.ControllersWS
{
    internal class UploadOnLineParameterWS : WSCommon
    {
        internal UploadOnLineParameterWS()
        {
        }
              
        internal override object Parameter(object paobjParam)
        {
            UploadOnLineParameter objParameter = (UploadOnLineParameter)paobjParam;

            try
            {
                if (objParameter.Status == Convert.ToString(Status.Start))
                {
                    string strFileName = "";
                    string strFilePath = "";
                    string strFileType = "";
                    string strFileDate = "";
                    string strFileMask = "";
                    string strFileByType = "";

                    DataSet dsReturn = new DataSet();
                    ISQLConnect iSQLConnect = new ISQLConnect();
                    dsReturn = iSQLConnect.ICapturaIdSequenciaUploadOnLine(objParameter.Sequence);

                    for (int i = 0; i < dsReturn.Tables["UploadOnLine"].Rows.Count; i++)
                    {
                        strFileName = dsReturn.Tables["UploadOnLine"].Rows[0].ItemArray[0].ToString();
                        strFilePath = dsReturn.Tables["UploadOnLine"].Rows[0].ItemArray[1].ToString();
                        strFileType = dsReturn.Tables["UploadOnLine"].Rows[0].ItemArray[2].ToString();
                        strFileDate = dsReturn.Tables["UploadOnLine"].Rows[0].ItemArray[3].ToString();
                        strFileMask = dsReturn.Tables["UploadOnLine"].Rows[0].ItemArray[4].ToString();
                        strFileByType = dsReturn.Tables["UploadOnLine"].Rows[0].ItemArray[5].ToString();
                    }

                    objParameter.Status = Convert.ToString(Status.Start);

                    //string strFileName = @"";
                    //string strFilePath = @"C:\temp\";
                    //string strFileType = @"log";
                    //string strFileDate = @"";
                    //string strFileMask = @"";
                    //string strFileByType = @"ByFolder";

                    //ByName
                    //string strFileName = @"teste01";
                    //string strFilePath = @"C:\temp\";
                    //string strFileType = @"log";
                    //string strFileDate = @"";
                    //string strFileMask = @"";
                    //string strFileByType = @"ByName";  

                    //ByDate
                    //string strFileName = @"teste[]";
                    //string strFilePath = @"C:\temp\";
                    //string strFileType = @"log";
                    //string strFileDate = @"02/01/2023";
                    //string strFileMask = @"[YYYYMMDD]";
                    //string strFileByType = @"ByDate";  

                    //ByRangeDate
                    //string strFileName = @"teste[]";
                    //string strFilePath = @"C:\temp\";
                    //string strFileType = @"log";
                    //string strFileDate = @"02/01/2023|03/01/2023";
                    //string strFileMask = @"[YYYYMMDD]";
                    //string strFileByType = @"ByRangeDate";

                    //ByFolder
                    //string strFileName = @"";
                    //string strFilePath = @"C:\temp\";
                    //string strFileType = @"log";
                    //string strFileDate = @"";
                    //string strFileMask = @"";
                    //string strFileByType = @"ByFolder";

                    objParameter.FileName = strFileName;
                    objParameter.FilePath = strFilePath;
                    objParameter.FileType = strFileType;
                    objParameter.FileDate = strFileDate;
                    objParameter.FileMask = strFileMask;
                    objParameter.FileByType = strFileByType;
                    objParameter.Status = Convert.ToString(Status.Start);

                    return objParameter;
                }

                return objParameter;
            }
            catch (Exception ex)
            {

                LocalLog.Trace.WriteLogText("UploadOnLineAllowWS.Allow() Error." + paobjParam.GetType().Name, ex);

                objParameter.FileName = "";
                objParameter.FilePath = "";
                objParameter.FileType = "";
                objParameter.FileDate = "";
                objParameter.FileMask = "";
                objParameter.Status = Convert.ToString(Status.ExecuteError);

                //Atualizar a base de dados

                return objParameter;
            }

        }











        //private string ReturnFileExtension(int paSequence, string paIdEquipment, string paIdTask)
        //{
        //    string strReturn = "";

        //    //System.Data.OleDb.OleDbConnection connExt = new OleDbConnection(ParametrosSiteServer.RetornarConexoes());

        //    //System.Data.OleDb.OleDbCommand dbExecutarExt = new System.Data.OleDb.OleDbCommand("spRetornarExtensaoArquivoUpload", connExt);
        //    //dbExecutarExt.CommandType = System.Data.CommandType.StoredProcedure;

        //    //System.Data.OleDb.OleDbParameter parsq_sequencia = new System.Data.OleDb.OleDbParameter("@sq_sequencia", System.Data.OleDb.OleDbType.Integer);
        //    //parsq_sequencia.Direction = System.Data.ParameterDirection.Input;
        //    //parsq_sequencia.Value = paSequence;
        //    //dbExecutarExt.Parameters.Add(parsq_sequencia);

        //    //System.Data.OleDb.OleDbParameter pa_IdEquipment = new System.Data.OleDb.OleDbParameter("@id_equipment", System.Data.OleDb.OleDbType.VarChar (50));
        //    //pa_IdEquipment.Direction = System.Data.ParameterDirection.Input;
        //    //pa_IdEquipment.Value = paIdEquipment;
        //    //dbExecutarExt.Parameters.Add(pa_IdEquipment);

        //    //System.Data.OleDb.OleDbParameter partipo_upload = new System.Data.OleDb.OleDbParameter("@tp_tipo_upload", System.Data.OleDb.OleDbType.SmallInt);
        //    //partipo_upload.Direction = System.Data.ParameterDirection.Input;
        //    //partipo_upload.Value = 0;
        //    //dbExecutarExt.Parameters.Add(partipo_upload);

        //    try
        //    {
        //        //if (connExt.State == ConnectionState.Closed)
        //        //{
        //        //    connExt.Open();
        //        //}

        //        //System.Data.OleDb.OleDbDataReader dr = dbExecutarExt.ExecuteReader(CommandBehavior.CloseConnection);

        //        //while (dr.Read())
        //        //{
        //        //    strRetorno = Microsoft.Security.Application.Encoder.HtmlEncode(dr["extensao"].ToString()).Trim();
        //        //}

        //        //dr.Close();

        //        //if (connExt.State == ConnectionState.Open)
        //        //{
        //        //    connExt.Close();
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        //br.com.procomp.Infra.Log.LogLocal.Trace.WriteLogText("ControllerWS_ATM.UploadOnLParam Erro na execuçao da procedure spRetornarExtensaoArquivoUpload [" + ex.Message + "]");
        //    }
        //    finally
        //    {
        //        //if (connExt.State == ConnectionState.Open)
        //        //{
        //        //    connExt.Close();
        //        //}

        //        //dbExecutarExt.Dispose();
        //    }

        //    return strReturn;
        //}

        //private string FormatDayOfYear(string pastrDay)
        //{
        //    string strDay = "";

        //    // formata o dia para visualizacao
        //    switch (pastrDay.Length)
        //    {
        //        case 0:
        //            strDay = "000";
        //            break;

        //        case 1:
        //            strDay = string.Concat("00", pastrDay);
        //            break;

        //        case 2:
        //            strDay = string.Concat("0" + pastrDay);
        //            break;

        //        case 3:
        //            strDay = pastrDay;
        //            break;
        //    }

        //    return strDay;
        //}

        //private string FormatFileName(string paName)
        //{
        //    return paName;
        //}
        
    }
}

