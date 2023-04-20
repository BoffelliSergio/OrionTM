using System;
using System.Collections.Generic;

namespace OrionTMClient.Model
{
    public class ReturnOrion
    {
        public string IdEquipment { get; set; }
        public string Task { get; set; }
        public string IdTask { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
        public class ReturnHeartBeat
    {
        public int IdEquipment { get; set; }
        public string Task { get; set; }
        public string Status { get; set; }
    }
}

