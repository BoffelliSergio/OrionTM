using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{

    [Table("Download")]
    public class Download
    {
        [Key]
        public int Id_sequencia { get; set; }
        public int Id_terminal { get; set; }
        public int Id_status { get; set; }
        public int Id_pacote { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

    //[Id_sequencia][int] identity(1,1) NOT NULL,
    //[id_terminal] [int] NOT NULL,
    //[id_status] [int] NOT NULL,
    //[Id_pacote] varchar(8000) NOT NULL,
    //[DataInstalacao] [datetime]  NOT NULL,
    //[DataAtualizacao] [datetime]  NOT NULL,


    }
}
