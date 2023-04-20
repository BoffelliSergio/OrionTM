using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{


    [Table("FilaTasks")]
    public class FilaTasks
    {

        public int FilaTasksId { get; set; }

        public int TerminalId { get; set; }

        public DateTime DtAtualizacao { get; set; }

        public int TasksId { get; set; }

        public int ComandoId { get; set; }
        
        public int LogId { get; set; }

        public int PacoteId { get; set; }

        public int StatusId { get; set; }

        public virtual Terminal Terminal { get; set; }

        public virtual Status Status { get; set; }

        public virtual Comando Comando { get; set; }

        public virtual Log Log { get; set; }

        public virtual Pacote Pacote { get; set; }

        public virtual Tasks Tasks { get; set; }
    }
}
