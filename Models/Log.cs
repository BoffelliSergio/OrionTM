using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace OrionTM_Web.Models
{

    [Table("Log")]
    public class Log
    {

        public int LogId { get; set; }
                
        [Display(Name = "Digite o Nome do Log ou Pasta, caso queira incluir uma mascara de data utilize [] (ex. Atm_[]) ")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatoria")]
        [Display(Name = "Digite uma descição do Log")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Caminho Obrigatório")]
        [Display(Name = "Digite o caminho do Log (Ex. c:\\aplic\\)")]
        [MaxLength(200)]
        public string Caminho { get; set; }

        [Required(ErrorMessage = "Tipo Obrigatorio")]
        [Display(Name = "Selecione o tipo de Log ou PASTA para fazer Upload da pasta completa")]
        [MaxLength(10)]
        public string TipoArquivo { get; set; }
                
        [Display(Name = "Digite a mascara de Data caso tenha inserido [] no nome do Log (ex. yyyy_mm_dd)")]
        [MaxLength(100)]
        public string DataMascara { get; set; }



    }
}
