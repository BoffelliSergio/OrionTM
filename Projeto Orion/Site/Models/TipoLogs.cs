using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{
    public class TipoLogs
    {
        [Table("TipoLogs")]
        public class Status
        {
            public int TipoLogsId { get; set; }
            public string TipoLog { get; set; }

        }

    }
}
