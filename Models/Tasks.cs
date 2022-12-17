using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        public int TasksId { get; set; }
        public string TasksDescricao { get; set; }

    }
}
