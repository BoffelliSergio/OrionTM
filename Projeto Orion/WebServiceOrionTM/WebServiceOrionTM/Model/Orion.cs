using System;
using System.Collections.Generic;


namespace WebServicesOrionTM.Model
{
    public class Orion
    {
        public string PublicToken { get; set; }
        public string PrivateToken { get; set; }
        public string IdEquipment { get; set; }
        public string Task { get; set; }
        public string IdTask { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
    }

    public class HeartBeat
    {
        public string IdEquipment { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
        public string Version { get; set; }
    }


    public class RetornoOrion
    {
        public string IdEquipment { get; set; }
        public string Task { get; set; }
        public string IdTask { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}