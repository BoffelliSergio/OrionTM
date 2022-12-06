using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    public class ListaEnvio
    {

        public int ListaEnvioId { get; set; }

        [Required(ErrorMessage = "Nome")]
        [Display(Name = "Nome")]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descição")]
        [Display(Name = "Descricao")]
        [StringLength(50)]
        public string Descricao { get; set; }

        public List<DetalheListaEnvio> DetalheListaEnvio { get; set; }

    }
}
