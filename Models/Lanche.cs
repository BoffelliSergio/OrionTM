using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required (ErrorMessage ="Nome Obrigatorio")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Obrigatorio")]
        [Display(Name = "Descrição Curta")]
        [MinLength(20, ErrorMessage = "Minimo {1}")]
        [MaxLength(200, ErrorMessage ="Maximo {1}")]
        public string DescricaoCurta { get; set; }

        [StringLength(200, ErrorMessage = "Max 200")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Nome Obrigatorio")]
        [Display(Name = "Nome do Lanche")]
        [Column(TypeName ="Decimal(10,2)")]
        [Range (1,999.99,ErrorMessage ="O preço de 1 a 999.99")]
        public decimal Preco { get; set; }

        [StringLength(200, ErrorMessage = "Max 200")]
        [Display(Name = "Url da imagem")]
        public string ImagemUrl { get; set; }

        [StringLength(200, ErrorMessage = "Max 200")]
        [Display(Name = "Url da imagem")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name = "Em Estoque?")]
        public bool EmEstoque { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        }



}
