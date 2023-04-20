using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServicesOrionTM.Model.Entity;

namespace WebServicesOrionTM.Model.Entity
{
    public class StatusSend : DateTimeController
    {
        //Campos da tabela
        private string prStatusSend;
        private string prDescriptiono;

        public StatusSend()
        {
        }

        public StatusSend(string paStatusSend)
        {
            this.prStatusSend = paStatusSend;
        }

        public string CodeStatusSend
        {
            get
            {
                return prStatusSend;
            }
            set
            {
                prStatusSend = value;
            }
        }

        public string Description
        {
            get
            {
                return prDescriptiono;
            }
            set
            {
                prDescriptiono = value.Trim();
            }
        }

    }
}
