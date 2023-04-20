using System;


namespace WebServicesOrionTM.ModelWebService.Entity
{
    [Serializable()]
    public class EquipmentMsgStatus : OrionEquipment
    {
        private string prTypeStatus;
        private string prStatusEquipment;
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

        public string StatusEquipment
        {
            get
            {
                return prStatusEquipment;
            }
            set
            {
                prStatusEquipment = value;
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

