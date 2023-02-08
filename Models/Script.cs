using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{

    [Table("Script")]
    public class Script
    {
        [Key]
        public int Id_sequencia { get; set; }
        public int Id_terminal { get; set; }
        public int Id_status { get; set; }
        public string ScrConteudo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }



        //[Id_sequencia][int] identity(1,1) NOT NULL,
        //[id_terminal] [int] NOT NULL,
        //[id_status] [int] NOT NULL,
        //[ScrConteudo] varchar(8000) NOT NULL,
        //[DataCadastro] [datetime]   NOT NULL,
        //[DataAtualizacao] [datetime]  NOT NULL,


    }
}
