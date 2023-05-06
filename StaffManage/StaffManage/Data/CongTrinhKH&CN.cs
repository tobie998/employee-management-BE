using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class CongTrinhKH_CN
    {
        [Key]
        public int MacongtrinhKH { get; set; }
        [Required]
        public string LoaicongtrinhKH { get; set; }
    }
}
