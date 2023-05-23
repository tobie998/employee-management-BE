using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class KhenThuong
    {
        [Key]
        public string Makhenthuong { get; set; }
        [Required]
        public string Tenkhenthuong { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietKhenThuong> chiTietKhenThuong { get; set; }
        public KhenThuong()
        {
            chiTietKhenThuong = new HashSet<ChiTietKhenThuong>();
        }
    }
}
