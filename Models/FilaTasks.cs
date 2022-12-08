using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{


    [Table("FilaTasks")]
    public class FilaTasks
    {

        public int FilaTasksId { get; set; }

        public int EquipmentId { get; set; }

        public DateTime DtAtualizaao { get; set; }

        public int Task { get; set; }

        public int TaskID { get; set; }

        public int Status { get; set; }


    }
}
