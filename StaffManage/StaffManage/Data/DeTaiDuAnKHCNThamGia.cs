using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class DeTaiDuAnKHCNThamGia
    {
        [Key]
        public int Madetai { get; set; }
        [Required]
        public string Tendetai { get; set; }
    }
}
