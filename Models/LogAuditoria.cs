using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{

    [Table("LogAuditoria")]
    public class LogAuditoria
    {

        public int LogAuditoriaId { get; set; }

        [DisplayName("Modulo")]
        public string Modulo { get; set; }

        [DisplayName("Detalhe")]
        public string Detalhe { get; set; }

        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [DisplayName("Usuario")]
        public string Usuario { get; set; }


    }
}
