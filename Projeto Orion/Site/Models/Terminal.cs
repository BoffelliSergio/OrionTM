using Microsoft.VisualBasic;
using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    [Table("Terminal")]
    public class Terminal
    {

        public int TerminalId { get; set; }

        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Codigo Obrigatorio")]
        [Display(Name = "Codigo")]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Local Obrigatorio")]
        public int LocalId { get; set; }

        [Required(ErrorMessage = "IP Obrigatorio")]
        [Display(Name = "End. IP")]
        [MaxLength(15)]
        public string IP { get; set; }

        [Required(ErrorMessage = "DNS Obrigatorio")]
        [Display(Name = "End de DNS")]
        [MaxLength(15)]
        public string DNS { get; set; }

        [Required(ErrorMessage = "DefaulGateway Obrigatorio")]
        [Display(Name = "Default Gateway")]
        [MaxLength(15)]
        public string DefaultGateway { get; set; }
                
        [Required(ErrorMessage = "Data Atualização")]
        [Display(Name = "Data Ultima Atualização")]
        public DateTime DtAtualizaao { get; set; }

        [Required(ErrorMessage = "Versão Distribuida")]
        [Display(Name = "Versão Distribuida")]
        public int Vrs_Distribuida { get; set; }

        [Required(ErrorMessage = "Versão Instalada")]
        [Display(Name = "Versão Instalada")]
        public int Vrs_Instalada { get; set; }

        [Required(ErrorMessage = "Status")]
        [Display(Name = "Status")]
        public int Status { get; set; }

        public virtual Local Local { get; set; }

        public virtual Modelo Modelo { get; set; }




    }
}
