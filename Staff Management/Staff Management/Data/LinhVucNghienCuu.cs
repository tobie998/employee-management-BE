using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class LinhVucNghienCuu
    {
        [Key]
        public string Malinhvuc { get; set; }
        [Required]
        public string Tenlinhvuc { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChuyenNganhKH_CN> chuyenNganhKH_CNs { get; set; }
        public LinhVucNghienCuu()
        {
            chuyenNganhKH_CNs = new HashSet<ChuyenNganhKH_CN>();
        }
    }
}
