using System;
using WebServicesOrionTM.Infra;
using System.Web;
using WebServicesOrionTM.Model.Entity;
using WebServicesOrionTM.ModelWebService.Entity;


namespace WebServicesOrionTM.ControllersWS
{
    internal abstract class WSCommon
    {
        protected System.Web.SessionState.HttpSessionState Session;
                
        internal OrionEquipment probjOrionEquipment;

        internal UploadOnLineSend probjUploaOnLineSend;
        
        protected object probjEquipmentMsgStatus;
        
        protected Equipments probjEquipments = new Equipments();
        internal WSCommon()
        {
            Session = HttpContext.Current.Session;
        }

        internal virtual object Parameter(object paobjParameter)
        {
            return null;
        }

        internal virtual object Send(object paobjSender)
        {
            return null;
        }

        internal virtual object Statistic(object paobjEstatistic)
        {
            return null;
        }
                
        internal EquipmentMsgStatus FormatStatus(object paobjStatus)
        {
            string strIpEquipment = HttpContext.Current.Request.UserHostAddress.Trim();

            EquipmentMsgStatus objEquipmentMsgStatus = new EquipmentMsgStatus();

            if (this.probjOrionEquipment != null)
            {
                objEquipmentMsgStatus.Status = this.probjOrionEquipment.Status;
                objEquipmentMsgStatus.IdEquipment = strIpEquipment;
            }

            switch (paobjStatus.GetType().Name)
            {
                case "EquipmentMsgStatus":
                    
                    EquipmentMsgStatus objAtmStatusServico = (EquipmentMsgStatus)paobjStatus;
                    objEquipmentMsgStatus.TypeStatus = paobjStatus.GetType().Name;
                    objEquipmentMsgStatus.Status = objAtmStatusServico.Status;

                    try
                    {
                        // Gravar aqui o log do status na base
                        
                        //br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText("Iniciando pela procedure spRetornarAtmStatusServico");

                        //System.Data.OleDb.OleDbConnection connNovo4 = new OleDbConnection(ParametrosSiteServer.RetornarConexoes());
                        //System.Data.OleDb.OleDbCommand dbExecutarNovo4 = new OleDbCommand("spRetornarAtmStatusServico", connNovo4);
                        //dbExecutarNovo4.CommandType = CommandType.StoredProcedure;

                        //OleDbParameter parOleDbstatusServico = new OleDbParameter("@statuServico", OleDbType.SmallInt);
                        //parOleDbstatusServico.Direction = ParameterDirection.Input;
                        //parOleDbstatusServico.Value = objAtmStatusServico.StatusServico;
                        //dbExecutarNovo4.Parameters.Add(parOleDbstatusServico);

                        //try
                        //{
                        //    if (connNovo4.State == ConnectionState.Closed)
                        //    {
                        //        connNovo4.Open();
                        //    }

                        //    OleDbDataReader dr = dbExecutarNovo4.ExecuteReader(CommandBehavior.CloseConnection);

                        //    while (dr.Read())
                        //    {
                        //        objEquipmentMsgStatus.H1 = Microsoft.Security.Application.Encoder.HtmlEncode(dr["ds_descricao"].ToString()).Trim();
                        //    }
                        //    dr.Close();

                        //    if (connNovo4.State == ConnectionState.Open)
                        //    {
                        //        connNovo4.Close();
                        //    }
                        //}
                        //catch (Exception Ex)
                        //{
                        //    br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText(string.Concat("Erro na execução da procedure spRetornarAtmStatusServico ", Ex));
                        //    objEquipmentMsgStatus.H1 = "Status não cadastrado";
                        //}
                        //finally
                        //{
                        //    if (connNovo4.State == ConnectionState.Open)
                        //    {
                        //        connNovo4.Close();
                        //    }
                        //}

                        //dbExecutarNovo4 = null;
                        //parOleDbstatusServico = null;
                    }
                    catch (Exception ex)
                    {
                        // Gravar aqui o log do status na base

                        //br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText(ex);
                        //br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText("Iniciando pela procedure spRetornarAtmStatusServico");

                        //System.Data.OleDb.OleDbConnection connNovo4 = new OleDbConnection(ParametrosSiteServer.RetornarConexoes());
                        //System.Data.OleDb.OleDbCommand dbExecutarNovo4 = new OleDbCommand("spRetornarAtmStatusServico", connNovo4);
                        //dbExecutarNovo4.CommandType = CommandType.StoredProcedure;

                        //OleDbParameter parOleDbstatusServico = new OleDbParameter("@statuServico", OleDbType.SmallInt);
                        //parOleDbstatusServico.Direction = ParameterDirection.Input;
                        //parOleDbstatusServico.Value = objAtmStatusServico.StatusServico;
                        //dbExecutarNovo4.Parameters.Add(parOleDbstatusServico);

                        //try
                        //{
                        //    if (connNovo4.State == ConnectionState.Closed)
                        //    {
                        //        connNovo4.Open();
                        //    }

                        //    OleDbDataReader dr = dbExecutarNovo4.ExecuteReader(CommandBehavior.CloseConnection);

                        //    while (dr.Read())
                        //    {
                        //        objEquipmentMsgStatus.H1 = Microsoft.Security.Application.Encoder.HtmlEncode(dr["ds_descricao"].ToString()).Trim();
                        //    }
                        //    dr.Close();

                        //    if (connNovo4.State == ConnectionState.Open)
                        //    {
                        //        connNovo4.Close();
                        //    }
                        //}
                        //catch (Exception Ex)
                        //{
                        //    br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText(string.Concat("Erro na execução da procedure spRetornarAtmStatusServico ", Ex));
                        //    objEquipmentMsgStatus.H1 = "Status não cadastrado";
                        //}
                        //finally
                        //{
                        //    if (connNovo4.State == ConnectionState.Open)
                        //    {
                        //        connNovo4.Close();
                        //    }
                        //}

                        //dbExecutarNovo4 = null;
                        //parOleDbstatusServico = null;
                    }
                    return objEquipmentMsgStatus;

                case "StatusSend":
                    
                    StatusSend objStatussend = (StatusSend)paobjStatus;
                    objEquipmentMsgStatus.TypeStatus = paobjStatus.GetType().Name;
                    objEquipmentMsgStatus.Status = objStatussend.CodeStatusSend;

                    try
                    {
                        //br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText("Iniciando pela procedure spRetornarStatusTransmissao");

                        //System.Data.OleDb.OleDbConnection connNovo5 = new OleDbConnection(ParametrosSiteServer.RetornarConexoes());
                        //System.Data.OleDb.OleDbCommand dbExecutarNovo5 = new OleDbCommand("spRetornarStatusTransmissao", connNovo5);
                        //dbExecutarNovo5.CommandType = CommandType.StoredProcedure;

                        //OleDbParameter parOleDbstatusTransmissao = new OleDbParameter("@statustransmissao", OleDbType.SmallInt);
                        //parOleDbstatusTransmissao.Direction = ParameterDirection.Input;
                        //parOleDbstatusTransmissao.Value = objStatusTransmissao.CodStatusTransmissao;
                        //dbExecutarNovo5.Parameters.Add(parOleDbstatusTransmissao);

                        //try
                        //{
                        //    if (connNovo5.State == ConnectionState.Closed)
                        //    {
                        //        connNovo5.Open();
                        //    }

                        //    OleDbDataReader dr = dbExecutarNovo5.ExecuteReader(CommandBehavior.CloseConnection);

                        //    while (dr.Read())
                        //    {
                        //        objEquipmentMsgStatus.H1 = Microsoft.Security.Application.Encoder.HtmlEncode(dr["ds_descricao"].ToString()).Trim();
                        //    }
                        //    dr.Close();

                        //    if (connNovo5.State == ConnectionState.Open)
                        //    {
                        //        connNovo5.Close();
                        //    }
                        //}
                        //catch (Exception Ex)
                        //{
                        //    br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText(string.Concat("Erro na execução da procedure spRetornarStatusTransmissao ", Ex));
                        //    objEquipmentMsgStatus.H1 = "Status não cadastrado";
                        //}
                        //finally
                        //{
                        //    if (connNovo5.State == ConnectionState.Open)
                        //    {
                        //        connNovo5.Close();
                        //    }
                        //}

                        //dbExecutarNovo5 = null;
                        //parOleDbstatusTransmissao = null;
                    }
                    catch (Exception ex)
                    {
                        //br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText(ex);
                        //br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText("Iniciando pela procedure spRetornarStatusTransmissao");

                        //System.Data.OleDb.OleDbConnection connNovo5 = new OleDbConnection(ParametrosSiteServer.RetornarConexoes());
                        //System.Data.OleDb.OleDbCommand dbExecutarNovo5 = new OleDbCommand("spRetornarStatusTransmissao", connNovo5);
                        //dbExecutarNovo5.CommandType = CommandType.StoredProcedure;

                        //OleDbParameter parOleDbstatusTransmissao = new OleDbParameter("@statustransmissao", OleDbType.SmallInt);
                        //parOleDbstatusTransmissao.Direction = ParameterDirection.Input;
                        //parOleDbstatusTransmissao.Value = objStatusTransmissao.CodStatusTransmissao;
                        //dbExecutarNovo5.Parameters.Add(parOleDbstatusTransmissao);

                        //try
                        //{
                        //    if (connNovo5.State == ConnectionState.Closed)
                        //    {
                        //        connNovo5.Open();
                        //    }

                        //    OleDbDataReader dr = dbExecutarNovo5.ExecuteReader(CommandBehavior.CloseConnection);

                        //    while (dr.Read())
                        //    {
                        //        objEquipmentMsgStatus.H1 = Microsoft.Security.Application.Encoder.HtmlEncode(dr["ds_descricao"].ToString()).Trim();
                        //    }
                        //    dr.Close();

                        //    if (connNovo5.State == ConnectionState.Open)
                        //    {
                        //        connNovo5.Close();
                        //    }
                        //}
                        //catch (Exception Ex)
                        //{
                        //    br.com.procomp.Infra.Log.LogSite.Trace.WriteLogText(string.Concat("Erro na execução da procedure spRetornarStatusTransmissao ", Ex));
                        //    objEquipmentMsgStatus.H1 = "Status não cadastrado";
                        //}
                        //finally
                        //{
                        //    if (connNovo5.State == ConnectionState.Open)
                        //    {
                        //        connNovo5.Close();
                        //    }
                        //}


                        //dbExecutarNovo5 = null;
                        //parOleDbstatusTransmissao = null;
                    }
                    return objEquipmentMsgStatus;
            }

            return null;
        }
    }
}




    
        
        
        
        
       