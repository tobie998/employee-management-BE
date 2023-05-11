using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class DeTaiDuAnKHCN
    {
        [Key]
        public int Madetai { get; set; }
        [Required]
        public string Tendetai { get; set; }

    }
}
