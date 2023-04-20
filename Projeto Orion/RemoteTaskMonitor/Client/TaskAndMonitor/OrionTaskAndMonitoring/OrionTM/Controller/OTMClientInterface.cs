using System;

namespace OrionTMClient.Controller
{
    public delegate void CloseClient();

    public interface OTMClientClientInterface
	{
		event CloseClient evtCloseClient;
	}
}

