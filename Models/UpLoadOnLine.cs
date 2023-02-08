using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{

    [Table("UpLoadOnLine")]
    public class UpLoadOnLine
    {
        [Key]
        public int Id_sequencia { get; set; }
        public int Id_terminal { get; set; }
        public int Id_status { get; set; }
        public string NomeArquivo { get; set; }
        public string PathArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public string DataArquivo { get; set; }
        public string MascaraArquivo { get; set; }
        public string TipoUpload { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }


        //[Id_sequencia][int] identity(1,1) NOT NULL,
        //[id_terminal] [int] NOT NULL,
        //[id_status] [int] NOT NULL,
        //[NomeArquivo] [varchar] (4000) NULL,
        //[PathArquivo][varchar] (4000) NULL,
        //[TipoArquivo][varchar] (4000) NULL,
        //[DataArquivo][varchar] (4000) NULL,
        //[MascaraArquivo][varchar] (4000) NULL,
        //[TipoUpload][varchar] (4000) NULL,
        //[DataCadastro]    [datetime]   NOT NULL,
        //[DataAtualizacao] [datetime]  NOT NULL,





    }
}
