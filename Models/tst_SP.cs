using OrionTM_Web.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    public class tst_SP
    {
        [Column("Status", Order = 1)]
        public int Status { get; set; }

        [Column("codigo", Order = 2)]
        public int codigo { get; set; }

        [Column("Modelo", Order = 3)]
        public string Modelo { get; set; }

        [Column("Local", Order = 4)]
        public string Local { get; set; }

        [Column("Ip", Order = 5)]
        public string Ip { get; set; }

        [Column("Atualizacao", Order = 6)]
        public string Atualizacao { get; set; }

       }
}
