using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class KyLuat
    {
        [Key]
        public int Makyluat { get; set; }
        [Required]
        public string Tenkyluat { get; set; }
    }
}
