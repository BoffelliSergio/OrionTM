using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    public class Comando
    {

        public int ComandoId { get; set; }

        [Required(ErrorMessage = "Digite o Nome do Comando")]
        [Display(Name = "Digite o Nome do Comando")]
        [MaxLength(10)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Digite a descrição do Comando")]
        [Display(Name = "Digite a descrição do Comando")]
        [MaxLength(50)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o conteudo do Comando")]
        [Display(Name = "Digite o conteudo do Comando")]
        [MaxLength(8000)]
        public string Caminho { get; set; }




    }
}
