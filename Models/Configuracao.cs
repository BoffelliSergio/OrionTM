using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    [Table("Configuracao")]
    public class Configuracao
    {
        public int ConfiguracaoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [MaxLength(25)]
        [Display(Name = "Campo")]
        public string Campo { get; set; }

        [Required(ErrorMessage = "Valor Obrigatorio")]
        [MaxLength(25)]
        [Display(Name = "Valor")]
        public string Valor { get; set; }


    }
}
