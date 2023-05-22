using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManage.Data
{
    [Table("ChiTietGiaiThuong")]
    public class ChiTietGiaiThuong
    {
        
        public string Magiaithuong { get; set; }
        public string Macanbo { get; set; }
        public string Hinhthuc { get; set; }
        public string Noidung { get; set; }
        public int Namtangthuong { get; set; }
        public CanBo CanBo { get; set; }
        public GiaiThuong GiaiThuong { get; set; }
    }
}
