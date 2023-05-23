using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class CanBoModel
    {
        [Key]
        public String MaCanBo { get; set; }
        public string MaDonVi { get; set; }
        public string HoTen { get; set; }
        public string NamSinh { get; set; }
        public bool GioiTinh { get; set; }
        public string HocHam { get; set; }
        public string HocVi { get; set; }
        public int NamHocHam { get; set; }
        public int NamHocVi { get; set; }
        public string DiaChiNhaRieng { get; set; }
        public string DienThoaiNhaRieng { get; set; }
        public string DienThoaiCoQuan { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string MaChucVu { get; set; }
        public string MaChucDanh { get; set; }
        public string BacLuong { get; set; }
        public double LuongCoBan { get; set; }

    }
}
