using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using OrionTMClient.Entity;
using OrionTMClient.Infra;
using OrionTMClient.Infra.Certificate;
using OrionTMClient.Infra.Serialize;
using OrionTMClient.Interface;
using OrionTMClient.Model;
using OrionTMClient.View;


namespace OrionTMClient.Controller
{
    internal class WSConect : Common
    {
        //probjwsOrion
        internal WSConect()
        {
            //Instancia o servico de gerenciamento de conexao segura
            ServicePointManager.CertificatePolicy = new CertificateValidation();

            this.probjwsOrion = new OrionTMClient.WSOrion.MainServerOrionTM();
            string strServHTTP = ConfigParameters.ReturnXmlClientConfig("NetWorkServerURL");
            
            //if (strServHTTP.Substring(strServHTTP.Length - 1) != "/")
            //    strServHTTP += "/";

            this.probjwsOrion.Url = strServHTTP;

            OrionEquipment = new OrionEquipment();

            OrionEquipment.IdEquipment = ConfigParameters.ReturnXmlClientConfig("NumberEquipment");
            OrionEquipment.PublicToken = ConfigParameters.ReturnXmlClientConfig("PublicToken");
            OrionEquipment.PrivateToken = "1";
            OrionEquipment.Version = ConfigParameters.ReturnXmlClientConfig("Version");
            OrionEquipment.Status = Convert.ToString(Status.Start);
            OrionEquipment.Task = Convert.ToString(Tasks.VerifyTask);
        }

        ~WSConect()
        {
            //Destroi as instancias criadas
            ServicePointManager.CertificatePolicy = null;
            this.probjwsOrion = null;
        }


        internal bool ConnectTask()
        {
            if (this.probjwsOrion.Url.ToLower().IndexOf("https") >= 0)
            {
                LocalLog.Trace.WriteLogText("WSConect_ConnectTask()", "Communicates in a secure environment. HTTPS");
            }
            else
            {
                LocalLog.Trace.WriteLogText("WSConect_ConnectTask()", "Communicates in a commom environment. HTTP");
            }

            return Send("TaskInit");
        }


        internal bool ConnectHeartBeat()
        {
            if (this.probjwsOrion.Url.ToLower().IndexOf("https") >= 0)
            {
                LocalLog.Trace.WriteLogText("WSConect_ConnectHeartBeat()", "Communicates in a secure environment. HTTPS");
            }
            else
            {
                LocalLog.Trace.WriteLogText("WSConect_ConnectHeartBeat()", "Communicates in a commom environment. HTTP");
            }

            return Send("HeartBeat");
        }

        internal bool ConectMessenger()
        {
            if (this.probjwsOrion.Url.ToLower().IndexOf("https") >= 0)
            {
                LocalLog.Trace.WriteLogText("WSConect_ConectMessenger()", "Communicates in a secure environment. HTTPS");
            }
            else
            {
                LocalLog.Trace.WriteLogText("WSConect_ConectMessenger()", "Communicates in a commom environment. HTTP");
            }

            return Send(ref OrionEquipment);
        }


        internal bool Send(ref OrionEquipment paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (OrionEquipment)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref UploadOnLineSend paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (UploadOnLineSend)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref UploadOnLineStatistic paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (UploadOnLineStatistic)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref UploadOnLineParameter paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (UploadOnLineParameter)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref ResetStatistic paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (ResetStatistic)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref ResetParameter paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (ResetParameter)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref ScriptStatistic paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (ScriptStatistic)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref ScriptParameter paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (ScriptParameter)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref DownloadPackageSend paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (DownloadPackageSend)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref DownloadPackageStatistic paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (DownloadPackageStatistic)objSend;
                return true;
            }
            else
                return false;
        }

        internal bool Send(ref DownloadPackageParameter paobjSend)
        {
            object objSend = paobjSend;

            if (Send(ref objSend))
            {
                paobjSend = (DownloadPackageParameter)objSend;
                return true;
            }
            else
                return false;
        }

        

        internal bool Send(ref object paobjSend)
        {
            LocalLog.Trace.WriteLogText("Send()", paobjSend.ToString());

            object objReturn = DeserializeObject.Descerialize(this.probjwsOrion.Messenger(SerializeObject.Serialize(paobjSend)));

            if (objReturn == null)
            {
                LocalLog.Trace.WriteLogText("Send()", new Exception("Send Fail, server not respond."));
                return false;
            }

            LocalLog.Trace.WriteLogText("objReturn =", objReturn.ToString());
            LocalLog.Trace.WriteLogText("objReturn.GetType().Name =", objReturn.GetType().Name);

            switch (objReturn.GetType().Name)
            {
                case "OrionEquipment":
                case "UploadOnLineSend":
                case "UploadOnLineStatistic":
                case "UploadOnLineParameter":
                case "UploadOnLineBuffer":
                case "ScriptParameter":
                case "ScriptStatistic":
                case "ResetParameter":
                case "ResetStatistic":
                case "DownloadPackageStatistic":
                case "DownloadPackageParameter":
                case "DownloadPackageSend":
                    paobjSend = objReturn;
                    return true;

                default:
                    LocalLog.Trace.WriteLogText("Send()", new Exception(string.Concat("Return object not identified:", objReturn.GetType().Name)));
                    return false;
            }
        }

        internal bool Send(string strStepTask)
        {
            LocalLog.Trace.WriteLogText("SendTaskInit()");
            bool boolreturn = false;
            ReturnOrion returnobj = new ReturnOrion();
            ReturnHeartBeat returnobjheartBeat = new ReturnHeartBeat();

            try
            {
                switch (strStepTask)
                {
                    case "TaskInit":
                        try
                        {
                            returnobj = JsonConvert.DeserializeObject<ReturnOrion>(this.probjwsOrion.VerificaTaskJS(OrionEquipment.IdEquipment, OrionEquipment.PublicToken, OrionEquipment.PrivateToken, OrionEquipment.Task));

                            switch (returnobj.Task.ToLower())
                            {
                                case "uploadonline":
                                    if (returnobj.Message.ToLower() == "error")
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() UploadOnline.", "Unexpected error occured.");

                                        boolreturn = false;
                                    }
                                    else
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() UploadOnline.", "Start.");

                                        OrionEquipment.IdTask = returnobj.IdTask;
                                        OrionEquipment.Status = returnobj.Status;

                                        UploadOnLine objUploadOnLine = new UploadOnLine();
                                        objUploadOnLine.Execute();
                                        objUploadOnLine = null;
                                        boolreturn = true;

                                        LocalLog.Trace.WriteLogText("WSConect_Send() UploadOnline.", "Ended.");
                                    }

                                    break;

                                case "executacomandoreset":
                                    if (returnobj.Message.ToLower() == "error")
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() ExecutaComandoReset.", "Ynexpected error occured.");

                                        boolreturn = false;
                                    }
                                    else
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() ExecutaComandoReset.", "Start.");

                                        OrionEquipment.IdTask = returnobj.IdTask;
                                        OrionEquipment.Status = returnobj.Status;

                                        ExecReset objExecReset = new ExecReset();
                                        objExecReset.Execute();
                                        objExecReset = null;
                                        boolreturn = true;

                                        LocalLog.Trace.WriteLogText("WSConect_Send() ExecutaComandoReset.", "Ended.");
                                    }

                                    break;

                                case "executascript":
                                    if (returnobj.Message.ToLower() == "error")
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() ExecutaScript.", "Ynexpected error occured.");

                                        boolreturn = false;
                                    }
                                    else
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() ExecutaScript.", "Start.");

                                        OrionEquipment.IdTask = returnobj.IdTask;
                                        OrionEquipment.Status = returnobj.Status;

                                        ExecScript objExecScript = new ExecScript();
                                        objExecScript.Execute();
                                        objExecScript = null;
                                        boolreturn = true;

                                        LocalLog.Trace.WriteLogText("WSConect_Send() ExecutaScript.", "Ended.");
                                    }

                                    break;


                                case "downloadpackage":
                                    if (returnobj.Message.ToLower() == "error")
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() DownloadPackage.", "Ynexpected error occured.");

                                        boolreturn = false;
                                    }
                                    else
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() DownloadPackage.", "Start.");

                                        OrionEquipment.IdTask = returnobj.IdTask;
                                        OrionEquipment.Status = returnobj.Status;

                                        DownloadPackage objDownloadPackage = new DownloadPackage();
                                        objDownloadPackage.Execute();
                                        objDownloadPackage = null;
                                        boolreturn = true;

                                        LocalLog.Trace.WriteLogText("WSConect_Send() DownloadPackage.", "Ended.");
                                    }

                                    break;

                                default:
                                    LocalLog.Trace.WriteLogText("WSConect_Send() Default.", string.Concat("Do not exists tasks for this equipment.", returnobj.IdEquipment.ToString()));
                                    boolreturn = false;
                                    break;
                            }
                        }
                        catch (Exception Ex)
                        {
                            LocalLog.Trace.WriteLogText("Send() Exception: ", Ex.ToString());
                            boolreturn = false;
                        }

                        break;

                    case "HeartBeat":
                        try
                        {
                            returnobjheartBeat = JsonConvert.DeserializeObject<ReturnHeartBeat>(this.probjwsOrion.RecebeHeartBeatJS(OrionEquipment.IdEquipment, OrionEquipment.Version));

                            switch (returnobjheartBeat.Task.ToLower())
                            {
                                case "heartbeat":
                                    if (returnobjheartBeat.Status.ToLower() == Convert.ToString(Status.ExecuteOk).ToLower())
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() HeartBeat Ok. IdEquipment=", Convert.ToString(returnobjheartBeat.IdEquipment));

                                        boolreturn = true;
                                    }
                                    else
                                    {
                                        LocalLog.Trace.WriteLogText("WSConect_Send() HeartBeat fail. IdEquipment= ", Convert.ToString(returnobjheartBeat.IdEquipment));
                                        boolreturn = false;
                                    }
                                    break;

                                default:
                                    LocalLog.Trace.WriteLogText("WSConect_Send() Default.", string.Concat("Do not exists tasks for this equipment.", Convert.ToString(returnobjheartBeat.IdEquipment)));
                                    boolreturn = false;
                                    break;
                            }
                        }
                        catch (Exception Ex)
                        {
                            LocalLog.Trace.WriteLogText("Send() Exception: ", Ex.ToString());
                            boolreturn = false;
                        }

                        break;

                    default:
                        LocalLog.Trace.WriteLogText("Send()", new Exception(string.Concat("Object returned from WebService was not identified..Type=", returnobj.GetType().Name)));
                        boolreturn = false;
                        break;
                }
                
                this.probjwsOrion = null;
                this.probjcommonviews = null;
            }
            catch (Exception Ex)
            {
                LocalLog.Trace.WriteLogText("Send() Exception: ", Ex.ToString());
                boolreturn = false;
            }

            return boolreturn;
        }

    }
}

