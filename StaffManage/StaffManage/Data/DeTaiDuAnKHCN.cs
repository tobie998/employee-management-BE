using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class DeTaiDuAnKHCN
    {
        [Key]
        public int Madetai { get; set; }
        [Required]
        public string Tendetai { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietDeTaiDuAnKHCNThamGia> chiTietDeTaiDuAnKHCNThamGia { get; set; }
        public ICollection<DeTaiDuAnKHCNChuTri> deTaiDuAnKHCNChuTri { get; set; }
        public DeTaiDuAnKHCN()
        {
            chiTietDeTaiDuAnKHCNThamGia = new HashSet<ChiTietDeTaiDuAnKHCNThamGia>();
            deTaiDuAnKHCNChuTri = new HashSet<DeTaiDuAnKHCNChuTri>();
        }

    }
}
