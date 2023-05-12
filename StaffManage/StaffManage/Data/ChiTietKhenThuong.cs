using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChiTietKhenThuong
    {
        public int Makhenthuong { get; set; }
        public string Macanbo { get; set; }
        public string Tennkhenthuong { get; set; }
        [MaxLength(50)]
        public string Ngayapdung { get; set; }
        public CanBo CanBo { get; set; }
        public KhenThuong KhenThuong { get; set; }
    }
}
