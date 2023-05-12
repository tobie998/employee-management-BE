using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class NghienCuuSinhDaHuongDan
    {
        public int MaNCS { get; set; }
        public string Macanbo { get; set; }
        [MaxLength(100)]
        public string HotenNCS { get; set; }
        [MaxLength(50)]
        public string Vaitro { get; set; }
        public string Donvicongtac { get; set; }
        public int NambaovecuaNCS { get; set; }
        public CanBo CanBo { get; set; }


    }
}
