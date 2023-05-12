using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChiTietKyLuat
    {
        public int Makyluat { get; set; }
        public string Macanbo { get; set; }
        public string Tenkyluat { get; set; }
        [MaxLength(50)]
        public string Ngayapdung { get; set; }
        public CanBo CanBo { get; set; }
        public KyLuat KyLuat { get; set;}
    }
}
