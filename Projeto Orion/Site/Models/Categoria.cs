using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [StringLength(100, ErrorMessage = "Max 100")]
        [Required (ErrorMessage = "Campo Obrigatório")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }
        [StringLength(200, ErrorMessage = "Max 200")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public virtual List<Lanche> Lanches { get; set; }
        
    }
}
