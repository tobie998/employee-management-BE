using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class ChiTietQuaTrinhCongTacModel
    {
        public int MaQuaTrinhCongTac { get; set; }
        public string MaCanBo { get; set; }
        public string ThoiGian { get; set; }
        public string ViTriCongTac { get; set; }
        public string LinhVucChuyenMon { get; set; }
        public string CoQuanCongTac { get; set; }
    }
}
