using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class KyLuat
    {
        [Key]
        public int Makyluat { get; set; }
        [Required]
        public string Tenkyluat { get; set; }

        public ICollection<ChiTietKyLuat> chiTietKyLuat { get; set; }
        public KyLuat()
        {
            chiTietKyLuat = new HashSet<ChiTietKyLuat>();
        }
    }
}
