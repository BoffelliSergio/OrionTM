using System;

namespace OrionTMClient.Entity
{
    [Serializable()]
    public class EquipmentMsgStatus 
    {
        private string prTypeStatus;
        private string prStatus;
        private string prDescription;
        private string prComplement;

        public EquipmentMsgStatus()
        {
        }

        public string TypeStatus
        {
            get
            {
                return prTypeStatus;
            }
            set
            {
                prTypeStatus = value.Trim();
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
                prStatus = value;
            }
        }

        public string Description
        {
            get
            {
                return prDescription;
            }
            set
            {
                prDescription = value.Trim();
            }
        }

        public string Complement
        {
            get
            {
                return prComplement;
            }
            set
            {
                prComplement = value.Trim();
            }
        }
    }
}

