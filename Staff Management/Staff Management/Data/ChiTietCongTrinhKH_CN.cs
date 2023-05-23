using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChiTietCongTrinhKH_CN
    {
        public string MacongtrinhKH { get; set; }
        public string Macanbo { get; set; }
        public string LoaicongtrinhKH { get; set; }
        public string TencongtrinhKH { get; set; }
        public string Vaitro { get; set; }
        public string Noicongbo { get; set; }
        public int Namcongbo { get; set; }
        public CanBo CanBo { get; set; }
        public CongTrinhKH_CN CongTrinhKH_CN { get; set; }
    }
}
