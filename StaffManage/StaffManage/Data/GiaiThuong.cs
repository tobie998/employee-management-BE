using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class GiaiThuong
    {
        [Key]
        public int Magiaithuong { get; set; }
        [Required]
        public string Hinhthuc { get; set; }

        public ICollection<ChiTietGiaiThuong> chiTietGiaiThuongs { get; set; }
        public GiaiThuong()
        {
            chiTietGiaiThuongs = new HashSet<ChiTietGiaiThuong>();
        }
    }
}
