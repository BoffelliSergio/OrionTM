using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{
    [Table("Local")]
    public class Local
    {
        public int LocalId { get; set; }

        [Display(Name = "Link")]
        public int LinkId { get; set; }

        [Required(ErrorMessage = "Codigo Obrigatorio")]
        [MaxLength(10)]
        [Display(Name = "Cod Local")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [MaxLength(25)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [MaxLength(50)]
        public string Endereco { get; set; }
        [MaxLength(5)]
        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "Cidade")]
        [MaxLength(25)]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(25)]
        public string Estado { get; set; }

        [Display(Name = "Cep")]
        [MaxLength(8)]
        public string Cep { get; set; }

        [Display(Name = "Telefone")]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Display(Name = "Contato")]
        [MaxLength(15)]
        public string Contato { get; set; }


        public virtual Link Link { get; set; }

    }
}
