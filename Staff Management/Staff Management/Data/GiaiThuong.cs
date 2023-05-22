using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class GiaiThuong
    {
        [Key]
        public string Magiaithuong { get; set; }
        [Required]
        public string Hinhthuc { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietGiaiThuong> chiTietGiaiThuongs { get; set; }
        public GiaiThuong()
        {
            chiTietGiaiThuongs = new HashSet<ChiTietGiaiThuong>();
        }
    }
}
