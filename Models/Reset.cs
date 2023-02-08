using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{

    [Table("Reset")]
    public class Reset
    {
        [Key]
        public int Id_sequencia { get; set; }
        public int TerminalId { get; set; }
        public int StatusId { get; set; }
        public int TipoReset { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Terminal Terminal { get; set; }

        public virtual Status Status { get; set; }

        //[Id_sequencia][int] identity(1,1) NOT NULL,
        //[id_terminal] [int] NOT NULL,
        //[id_status] [int] NOT NULL,
        //[TipoReset] [int] NOT NULL,
        //[DataCadastro] [datetime]  NOT NULL,
        //[DataAtualizacao] [datetime] NOT NULL,


    }
}
