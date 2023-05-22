using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class KyLuat
    {
        [Key]
        public string Makyluat { get; set; }
        [Required]
        public string Tenkyluat { get; set; }
        public int isDelete { get; set; } = 0;
        public ICollection<ChiTietKyLuat> chiTietKyLuat { get; set; }
        public KyLuat()
        {
            chiTietKyLuat = new HashSet<ChiTietKyLuat>();
        }
    }
}
