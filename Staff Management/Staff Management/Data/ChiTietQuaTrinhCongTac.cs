using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChiTietQuaTrinhCongTac
    {
        public string Maquatrinhcongtac { get; set; }
        public string Macanbo { get; set; }
        [MaxLength(50)]
        public string Thoigian { get; set; }
        public string Vitricongtac { get; set; }
        public string Linhvucchuyenmon { get; set; }
        public string Coquancongtac { get; set; }
        public CanBo CanBo { get; set; }
    }
}
