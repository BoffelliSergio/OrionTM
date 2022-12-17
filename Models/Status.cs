using System.ComponentModel.DataAnnotations.Schema;

namespace OrionTM_Web.Models
{
    [Table("Status")]
    public class Status
    {
        public int StatusId { get; set; }
        public string StsDescricao { get; set; }

    }
}
