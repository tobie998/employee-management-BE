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
    }
}
