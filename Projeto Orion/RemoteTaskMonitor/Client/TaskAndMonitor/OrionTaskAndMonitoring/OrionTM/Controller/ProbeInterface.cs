using System;

namespace OrionTMClient.Controller
{
	public delegate void CloseProbe();

	public interface ProbeInterface
	{
        event CloseProbe evtCloseProbe;
	}
}
