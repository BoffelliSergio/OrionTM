using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    public class Pacote
    {

        public int PacoteId { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [Display(Name = "Nome")]
        [MaxLength(10)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatoria")]
        [Display(Name = "Descrição")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Caminho Obrigatorio")]
        [Display(Name = "Caminho do Pacote")]
        [MaxLength(200)]
        public string Caminho { get; set; }

        [Required(ErrorMessage = "Versão Obrigatorio")]
        [Display(Name = "Versão do Pacote")]
        public int Versao { get; set; }

        [Required(ErrorMessage = "Prod Obrigatorio")]
        [Display(Name = "Padote de Produção?")]
        public bool Prod { get; set; }


    }
}
