using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{

    [Table("Modelo")]
    public class Modelo
    {
        public int ModeloId { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [Display(Name = "Nome")]
        [MaxLength(10)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        [Display(Name = "Descrição")]
        [MaxLength(20)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        [Display(Name = "Fabricante")]
        [MaxLength(20)]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Obrigatorio")]
        [Display(Name = "SistemaOperacional")]
        [MaxLength(20)]
        public string SistemaOperacional { get; set; }  
               
    }
}
