using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChucDanh
    {
        [Key]
        public int Machucdanh { get; set; }
        [Required]
        public string Tenchucdanh { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietChucDanh> chiTietChucDanhs { get; set; }
        public ChucDanh()
        {
            chiTietChucDanhs = new HashSet<ChiTietChucDanh>();
        }
    }
}
