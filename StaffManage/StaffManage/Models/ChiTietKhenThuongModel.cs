using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class ChiTietKhenThuongModel
    {
        public int MaKhenThuong { get; set; }
        public string MaCanBo { get; set; }
        public string TenKhenThuong { get; set; }
        public string NgayApDung { get; set; }
    }
}
