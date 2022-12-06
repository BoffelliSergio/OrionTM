using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{

    [Table("Log")]
    public class Log
    {

        public int LogId { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [Display(Name = "Nome")]
        [MaxLength(10)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Descrição Obrigatoria")]
        [Display(Name = "Descrição")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Caminho Obrigatorio")]
        [Display(Name = "Caminho do arquivo")]
        [MaxLength(200)]
        public string Caminho { get; set; }

        }
}
