using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class VanBangCanBo
    {
        [Key]
        public string Mavanbang { get; set; }
        [Required]
        public string Tenvanbang { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietVanBang> chiTietVanBang { get; set; }

        public VanBangCanBo()
        {
            chiTietVanBang = new HashSet<ChiTietVanBang>();
        }

    }
}
