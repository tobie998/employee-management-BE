using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class LinhVucNghienCuu
    {
        [Key]
        public int Machuyennganh { get; set; }
        [Required]
        public string Tenchuyennganh { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietLinhVucNghienCuu> chiTietLinhVucNghienCuu { get; set; }
        public LinhVucNghienCuu()
        {
            chiTietLinhVucNghienCuu = new HashSet<ChiTietLinhVucNghienCuu>();
        }
    }
}
