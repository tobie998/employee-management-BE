using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class KhenThuong
    {
        [Key]
        public int Makhenthuong { get; set; }
        [Required]
        public string Tenkhenthuong { get; set; }
        public ICollection<ChiTietKhenThuong> chiTietKhenThuong { get; set; }
        public KhenThuong()
        {
            chiTietKhenThuong = new HashSet<ChiTietKhenThuong>();
        }
    }
}
