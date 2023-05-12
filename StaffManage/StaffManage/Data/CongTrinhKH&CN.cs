using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class CongTrinhKH_CN
    {
        [Key]
        public int MacongtrinhKH { get; set; }
        [Required]
        public string LoaicongtrinhKH { get; set; }
        public ICollection<ChiTietCongTrinhKH_CN> chiTietCongTrinhKH_CN { get; set; }
        public CongTrinhKH_CN()
        {
            chiTietCongTrinhKH_CN = new HashSet<ChiTietCongTrinhKH_CN>();
        }

    }
}
