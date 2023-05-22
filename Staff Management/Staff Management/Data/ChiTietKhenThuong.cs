using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChiTietKhenThuong
    {
        public string Makhenthuong { get; set; }
        public string Macanbo { get; set; }
        public string Tenkhenthuong { get; set; }
        [MaxLength(50)]
        public string Ngayapdung { get; set; }
        public CanBo CanBo { get; set; }
        public KhenThuong KhenThuong { get; set; }
    }
}
