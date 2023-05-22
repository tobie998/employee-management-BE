using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManage.Data
{
    public class ChuyenNganhKH_CN
    {
        public string Machuyennganh { get; set; }
        public string Tenchuyennganh { get; set; }
        public string Malinhvuc { get; set; }
        public LinhVucNghienCuu LinhVucNghienCuu { get; set; }
        public ICollection<ChiTietChuyenNganhKH_CN> chiTietChuyenNganhKH_CN { get; set; }
        public ChuyenNganhKH_CN()
        {
            chiTietChuyenNganhKH_CN = new HashSet<ChiTietChuyenNganhKH_CN>();
        }
    }
}
