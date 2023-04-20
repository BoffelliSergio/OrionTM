using System;
using System.Collections.Generic;
using System.Text;

namespace OrionTMClient.Entity
{
    [Serializable()]
    public class HeartBeat
    {
        private string prIdEquipment;
        private string prVersion;
        private string prStatus;
        public HeartBeat()
        {
        }

        public HeartBeat(string paIdEquipment, string paVersion)
        {
            this.prIdEquipment = paIdEquipment;
            this.prVersion = paVersion;
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
    }
}




