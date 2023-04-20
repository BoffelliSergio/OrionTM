using System;


namespace OrionTMClient.Infra
{

	using System.Diagnostics;
	using Microsoft.Win32;

	/// <summary>
	/// Geracao de registros no Log de eventos do sistema
	/// </summary>
	public class SystemEvent
	{
        ~SystemEvent()
		{
		}

		public void EventWrite(string pastrSource, Exception paobjError, string pastrMessage)
		{
			EventLog objLog = new EventLog("Application",".");
			objLog.Source = @"Application";
			objLog.WriteEntry(string.Concat(pastrMessage.ToString() , " " , paobjError.Message.ToString() , " " , paobjError.InnerException), EventLogEntryType.Error);
		}

		public void EventWrite(string pastrSource, string pastrMessage)
		{
			Exception objError = new Exception(pastrMessage); 
			EventWrite(pastrSource, objError, @"");
		}

		public void EventWrite(string pastrSource, Exception paobjError)
		{
			EventWrite(pastrSource, paobjError,@"");
		}

		public void EventWrite(string pastrSource, string pastrMessage, System.Data.OleDb.OleDbException paobjDataError)
		{
			Exception objError = new Exception(pastrMessage); 
			string strErrorMessages = "";

			for (int i=0; i < paobjDataError.Errors.Count; i++)
			{
				strErrorMessages += "Index #" + i + "\n" +
					"Message: " + paobjDataError.Errors[i].Message + "\n" +
					"NativeError: " + paobjDataError.Errors[i].NativeError + "\n" +
					"Source: " + paobjDataError.Errors[i].Source + "\n" +
					"SQLState: " + paobjDataError.Errors[i].SQLState + "\n";
			}

			EventWrite(pastrSource, objError, strErrorMessages);
		}

		public void EventWrite(string pastrSource, string pastrMessage, System.Data.SqlClient.SqlException paobjDataError)
		{
			Exception objError = new Exception(pastrMessage); 
			string strErrorMessages = "";

			for (int i=0; i < paobjDataError.Errors.Count; i++)
			{
				strErrorMessages += "Index #" + i + "\n" +
					"Message: " + paobjDataError.Errors[i].Message + "\n" +
					"LineNumber: " + paobjDataError.Errors[i].LineNumber + "\n" +
					"Source: " + paobjDataError.Errors[i].Source + "\n" +
					"Procedure: " + paobjDataError.Errors[i].Procedure + "\n";
			}

			EventWrite(pastrSource,objError,strErrorMessages);
		}
	}
}