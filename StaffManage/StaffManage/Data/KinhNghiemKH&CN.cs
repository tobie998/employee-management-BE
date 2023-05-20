using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManage.Data
{
    [Table("KinhNghiemKH&CN")]
    public class KinhNghiemKH_CN
    {
        [Key]
        public int Mahinhthuchoidong { get; set; }
        [Required]
        public string Hinhthuchoidong { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietVeKinhNghiemKH_CN> chiTietVeKinhNghiemKH_CNs { get; set; }
        public KinhNghiemKH_CN()
        {
            chiTietVeKinhNghiemKH_CNs = new HashSet<ChiTietVeKinhNghiemKH_CN>();
        }
    }
}
