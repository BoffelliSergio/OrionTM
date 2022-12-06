using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    public class Comando
    {

        public int ComandoId { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [Display(Name = "Nome")]
        [MaxLength(10)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Descrição Obrigatoria")]
        [Display(Name = "Descrição")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Nome Arquivo Obrigatorio")]
        [Display(Name = "Nome do arquivo")]
        [MaxLength(200)]
        public string Caminho { get; set; }

    }
}
