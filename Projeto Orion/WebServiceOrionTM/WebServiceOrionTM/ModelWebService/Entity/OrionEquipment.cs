using System;

namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class OrionEquipment
    {
        private string prPublicToken;
        private string prPrivateToken;
        private string prIdEquipment;
        private string prTask;
        private string prIdTask;
        private string prMessage;
        private string prStatus;
        private string prVersion;

        public OrionEquipment()
        {
        }

        public string PublicToken
        {
            get
            {
                return prPublicToken;
            }
            set
            {
                prPublicToken = value.Trim();
            }
        }

        public string PrivateToken
        {
            get
            {
                return prPrivateToken;
            }
            set
            {
                prPrivateToken = value.Trim();
            }
        }

        public string IdEquipment
        {
            get
            {
                return prIdEquipment;
            }
            set
            {
                prIdEquipment = value.Trim();
            }
        }

        public string Task
        {
            get
            {
                return prTask;
            }
            set
            {
                prTask = value.Trim();
            }
        }

        public string IdTask
        {
            get
            {
                return prIdTask;
            }
            set
            {
                prIdTask = value.Trim();
            }
        }

        public string Message
        {
            get
            {
                return prMessage;
            }
            set
            {
                prMessage = value.Trim();
            }
        }

        public string Status
        {
            get
            {
                return prStatus;
            }
            set
            {
                prStatus = value.Trim();
            }
        }

        public string Version
        {
            get
            {
                return prVersion;
            }
            set
            {
                prVersion = value.Trim();
            }
        }
    }

}




