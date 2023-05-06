using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class LinhVucNghienCuu
    {
        [Key]
        public int Machuyennganh { get; set; }
        [Required]
        public string Tenchuyennganh { get; set; }
    }
}
