using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class NghienCuuSinhDaHuongDanModel
    {
        public int MaNCS { get; set; }
        public string MaCanBo { get; set; }
        public string HoTenNCS { get; set; }
        public string VaiTro { get; set; }
        public string DonViCongTac { get; set; }
        public int NamBaoVeCuaNCS { get; set; }
    }
}
