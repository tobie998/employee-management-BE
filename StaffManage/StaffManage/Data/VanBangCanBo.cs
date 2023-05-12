using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class VanBangCanBo
    {
        [Key]
        public int Mavanbang { get; set; }
        [Required]
        public string Tenvanbang { get; set; }
        public ICollection<ChiTietVanBang> chiTietVanBang { get; set; }

        public VanBangCanBo()
        {
            chiTietVanBang = new HashSet<ChiTietVanBang>();
        }

    }
}
