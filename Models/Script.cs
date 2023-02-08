using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{

    [Table("Script")]
    public class Script
    {
        [Key]
        public int Id_sequencia { get; set; }
        public int TerminalId { get; set; }
        public int StatusId { get; set; }
        public string ScrConteudo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string StrLog { get; set; }

        public virtual Terminal Terminal { get; set; }

        public virtual Status Status { get; set; }


    }
}
