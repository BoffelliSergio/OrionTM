using System;


namespace WebServiceXPiAuth.Infra
{
	using System.Diagnostics;
	using Microsoft.Win32;

	// Gera registros no log do sistema
	public class EventSist
	{
		/// <summary>
		/// Gera informacao no Event Viewer
		/// </summary>
		/// <param name="pastrSource">Source de origem</param>
		/// <param name="paobjError">Objeto System.Exception</param>
		/// <param name="pastrMessage">Mensagem adicional</param>
		public void EventWrite(string pastrSource, Exception paobjError, string pastrMessage)
		{
			EventLog objLog = new EventLog("application",".");

			objLog.Source = @"application";

			// Write an informational entry to the event log.   
			objLog.WriteEntry(string.Concat(pastrMessage.ToString() , " " , paobjError.Message.ToString() , " " , paobjError.InnerException), 
				EventLogEntryType.Error);
		}

		/// <summary>
		/// Gera informacao no Event Viewer
		/// </summary>
		/// <param name="pastrSource">Source de origem</param>
		/// <param name="pastrMessage">Mensagem</param>
		public void EventWrite(string pastrSource, string pastrMessage)
		{
			Exception objErro = new Exception(pastrMessage); 
			EventWrite(pastrSource,objErro,@"");
		}

		/// <summary>
		/// Gera informacao no Event Viewer
		/// </summary>
		/// <param name="pastrSource">Source de origem</param>
		/// <param name="paobjError">Objeto System.Exception</param>
		public void EventWrite(string pastrSource, Exception paobjError)
		{
			EventWrite(pastrSource,paobjError,@"");
		}

		

		
	}
}