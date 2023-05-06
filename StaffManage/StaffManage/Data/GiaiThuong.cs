using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class GiaiThuong
    {
        [Key]
        public int Magiaithuong { get; set; }
        [Required]
        public string Hinhthuc { get; set; }
    }
}
