using System;
using System.Data;
using System.IO;
using OrionTMClient.Entity;

namespace OrionTMClient.Infra
{
    using System.Diagnostics;
    using System.IO;
    using Microsoft.Win32;
    public class GenerateLogEvent
    {
        public Exception Error;

        public GenerateLogEvent()
        {
        }
        ~GenerateLogEvent()
        {
        }

        public bool GenerateEventFile(string paPathFile, DateTime paDateLog, bool pablnAll)
        {
            //Remove o arquivo destino, se existir
            if (File.Exists(paPathFile))
                File.Delete(paPathFile);

            StreamWriter objEvt = null;
            int intContRegs = 0;

            try
            {
                objEvt = File.AppendText(paPathFile);

                objEvt.WriteLine(string.Concat(
                    @"<?xml version=""1.0"" encoding=""utf-8"" ?>", "\r\n",
                    @"<EvtLog xmlns=""http://tempuri.org/EventLogXML.xsd"">", "\r\n"
                    ));

                objEvt.WriteLine(string.Concat(
                    @"		<DataGeracao>", DateTime.Now.ToString(), @"</DataGeracao>", "\r\n"
                    ));

                if (EventLog.GetEventLogs().Length > 0)
                {
                    //Carrega os grupos de logs
                    int i = -1;
                    foreach (EventLog strCurrentLog in EventLog.GetEventLogs())
                    {
                        EventLog objEv = new EventLog(strCurrentLog.Log, System.Environment.MachineName, "PcpATPCli - Log de Eventos do Sistema");

                        i++;
                        objEvt.WriteLine(string.Concat(
                            @"		<EventGrupo>", "\r\n",
                            @"			<EvtLogGrupo>", "\r\n",
                            @"				<IdLogName>", i.ToString(), "</IdLogName>", "\r\n",
                            @"				<LogName>", objEv.Log, "</LogName>", "\r\n",
                            @"				<LogDisplayName>", objEv.LogDisplayName, "</LogDisplayName>", "\r\n",
                            @"				<MachineName>", objEv.MachineName, "</MachineName>", "\r\n",
                            @"				<SourceName>", objEv.Source, "</SourceName>", "\r\n",
                            @"				<LogEntradas>", "\r\n"
                            ));

                        int intQtdEntradas = 0;
                        if (objEv.Entries.Count > 0)
                        {
                            foreach (EventLogEntry objEntries in objEv.Entries)
                            {
                                if (pablnAll ||
                                    paDateLog == objEntries.TimeGenerated.Date)
                                {
                                    string strIcone = "";
                                    switch (objEntries.EntryType)
                                    {
                                        case EventLogEntryType.Error:
                                        case EventLogEntryType.FailureAudit:
                                            strIcone = @"&lt;IMG height=""16"" width=""16"" align=""absmiddle"" hspace=""0"" src=""../images/ico_erro.png"" border=""0"" &gt;";
                                            break;

                                        case EventLogEntryType.Information:
                                            strIcone = @"&lt;IMG height=""16"" width=""16"" align=""absmiddle"" hspace=""0"" src=""../images/ico_informac.png"" border=""0"" &gt;";
                                            break;

                                        case EventLogEntryType.SuccessAudit:
                                            strIcone = @"&lt;IMG height=""16"" width=""16"" align=""absmiddle"" hspace=""0"" src=""../images/ico_chave.gif"" border=""0"" &gt;";
                                            break;

                                        case EventLogEntryType.Warning:
                                            strIcone = @"&lt;IMG height=""16"" width=""16"" align=""absmiddle"" hspace=""0"" src=""../images/ico_aviso.gif"" border=""0"" &gt;";
                                            break;
                                    }

                                    intQtdEntradas++;
                                    objEvt.WriteLine(string.Concat(
                                        @"					<EvtLogEntradas>", "\r\n",
                                        @"						<IdLogName>", i.ToString(), "</IdLogName>", "\r\n",
                                        @"						<Seq>", intQtdEntradas.ToString(), "</Seq>", "\r\n",
                                        @"						<Category>", objEntries.Category, "</Category>", "\r\n",
                                        @"						<CategoryNumber>", objEntries.CategoryNumber.ToString(), "</CategoryNumber>", "\r\n",
                                        @"						<Data>", System.Convert.ToBase64String(objEntries.Data, 0, objEntries.Data.Length), "</Data>", "\r\n",
                                        @"						<IconeType>", strIcone, @" ", Enum.GetName(typeof(EventLogEntryType), objEntries.EntryType), "</IconeType>", "\r\n",
                                        @"						<EntryType>", Enum.GetName(typeof(EventLogEntryType), objEntries.EntryType), "</EntryType>", "\r\n",
                                        @"						<EventID>", objEntries.EventID.ToString(), "</EventID>", "\r\n",
                                        @"						<Index>", objEntries.Index.ToString(), "</Index>", "\r\n",
                                        @"						<MachineName>", objEntries.MachineName, "</MachineName>", "\r\n",
                                        @"						<Message>", objEntries.Message.Replace("<", "&lt;").Replace(">", "&gt;"), "</Message>", "\r\n",
                                        @"						<ReplacementStrings>", "\r\n"
                                        ));

                                    for (int j = 0; j < objEntries.ReplacementStrings.Length; j++)
                                    {
                                        objEvt.WriteLine(string.Concat(
                                            @"							<string>", objEntries.ReplacementStrings[j].Replace("<", "&lt;").Replace(">", "&gt;"), "</string>", "\r\n"
                                            ));
                                    }

                                    objEvt.WriteLine(string.Concat(
                                        @"						</ReplacementStrings>", "\r\n",
                                        @"						<Source>", objEntries.Source, "</Source>", "\r\n",
                                        @"						<TimeGenerated>", objEntries.TimeGenerated.ToString("dd/MM/yyyy HH:mm:ss"), "</TimeGenerated>", "\r\n",
                                        @"						<TimeWritten>", objEntries.TimeWritten.ToString("dd/MM/yyyy HH:mm:ss"), "</TimeWritten>", "\r\n",
                                        @"						<UserName>", objEntries.UserName, "</UserName>", "\r\n",
                                        @"					</EvtLogEntradas>", "\r\n"
                                        ));

                                    intContRegs++;
                                    if (intContRegs > 10000)
                                    {
                                        objEvt.Flush();
                                        objEvt.Close();
                                        objEvt = File.AppendText(paPathFile);
                                        intContRegs = 0;
                                    }
                                }
                            }
                        }

                        objEvt.WriteLine(string.Concat(
                            @"				</LogEntradas>", "\r\n",
                            @"				<QtdEntradas>", intQtdEntradas.ToString(), "</QtdEntradas>", "\r\n",
                            @"			</EvtLogGrupo>", "\r\n",
                            @"		</EventGrupo>", "\r\n"
                            ));
                    }
                }

                objEvt.WriteLine(string.Concat(
                    @"</EvtLog>", "\r\n"
                    ));

                return true;
            }
            catch (Exception Ex)
            {
                this.Error = Ex;
                return false;
            }
            finally
            {
                if (objEvt != null)
                {
                    objEvt.Flush();
                    objEvt.Close();
                    objEvt = null;
                }
            }
        }
    }
}