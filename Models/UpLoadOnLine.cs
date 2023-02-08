using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{

    [Table("UpLoadOnLine")]
    public class UpLoadOnLine
    {
        [Key]
        public int Id_sequencia { get; set; }
        public int TerminalId { get; set; }
        public int StatusId { get; set; }
        public string NomeArquivo { get; set; }
        public string PathArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public string DataArquivo { get; set; }
        public string MascaraArquivo { get; set; }
        public string TipoUpload { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string StrLog { get; set; }

        public virtual Terminal Terminal { get; set; }

        public virtual Status Status { get; set; }




    }
}
