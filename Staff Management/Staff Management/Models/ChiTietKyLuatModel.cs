using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class ChiTietKyLuatModel
    {
        public string MaKyLuat { get; set; }
        public string MaCanBo { get; set; }
        public string TenKyLuat { get; set; }
        public string NgayApDung { get; set; }
    }
}
