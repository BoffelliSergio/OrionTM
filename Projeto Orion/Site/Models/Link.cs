using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    public class Link
    {
        public int LinkId { get; set; }

        [Display(Name = "Nome")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "Capacidade")]
        [Required(ErrorMessage = "Capacidade Obrigatorio")]
        public int Capacidade { get; set; } 


    }
}
