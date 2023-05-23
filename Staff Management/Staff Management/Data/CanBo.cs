using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManage.Data
{
    public class CanBo
    {
        [Key]
        public string Macanbo { get; set; }
        [Required]
        public string Hoten { get; set;}
        public string Namsinh { get; set;}
        public bool Gioitinh { get; set;}
        public string Hocham { get; set;}
        public string Hocvi { get; set;}
        public int Namhocham { get; set; }
        public int Namhocvi { get; set;}
        public string Diachinharieng { get; set;}
        [MaxLength(13)]
        public string Dienthoainharieng { get; set;}
        [MaxLength(13)]
        public string Dienthoaicoquan { get; set; }
        [MaxLength(13)]
        public string Mobile { get; set;}
        [MaxLength(50)]
        public string Email { get; set;}

        public string Bacluong { get; set;}


        [Range(0, double.MaxValue)]
        public double Luongcoban { get; set;}
        public string Machucdanh { get; set; }
        [ForeignKey("Machucdanh")]
        public ChucDanh ChucDanh { get; set; }
        public string Machucvu { get; set; }
        [ForeignKey("Machucvu")]
        public ChucVu ChucVu { get; set; }
        public string Madonvi { get; set;}

        [ForeignKey("Madonvi")]
        public DonVi DonVi { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietGiaiThuong> chiTietGiaiThuongs { get; set; }
        public ICollection<ChiTietChuyenNganhKH_CN> chiTietChuyenNganhKH_CN { get; set; }
        public ICollection<ChiTietQuaTrinhDaoTao> chiTietQuaTrinhDaoTaos { get; set; }
        public ICollection<ChiTietVeKinhNghiemKH_CN> chiTietVeKinhNghiemKH_CNs { get; set; }
        public ICollection<ChiTietTrinhDoNgoaiNgu> chiTietTrinhDoNgoaiNgu { get; set; }
        public ICollection<NghienCuuSinhDaHuongDan> nghienCuuSinhDaHuongDan { get; set; }
        public ICollection<ChiTietKyLuat> chiTietKyLuat { get; set; }
        public ICollection<ChiTietKhenThuong> chiTietKhenThuong { get; set; }
        public ICollection<ChiTietQuaTrinhCongTac> chiTietQuaTrinhCongTac { get; set; }
        public ICollection<ChiTietCongTrinhKH_CN> chiTietCongTrinhKH_CN { get; set; }
        public ICollection<ChiTietDeTaiDuAnKHCNThamGia> chiTietDeTaiDuAnKHCNThamGia { get; set; }
        public ICollection<DeTaiDuAnKHCNChuTri> deTaiDuAnKHCNChuTri { get; set; }
        public ICollection<CongTrinhVaKetQuaNghienCuuDuocApDung> congTrinhVaKetQuaNghienCuuDuocApDung { get; set; }
        public ICollection<ChiTietVanBang> chiTietVanBang { get; set; }


        public CanBo()
        {
            chiTietGiaiThuongs = new HashSet<ChiTietGiaiThuong>();
            chiTietChuyenNganhKH_CN = new HashSet<ChiTietChuyenNganhKH_CN>();
            chiTietQuaTrinhDaoTaos = new HashSet<ChiTietQuaTrinhDaoTao>();
            chiTietVeKinhNghiemKH_CNs = new HashSet<ChiTietVeKinhNghiemKH_CN>();
            chiTietTrinhDoNgoaiNgu = new HashSet<ChiTietTrinhDoNgoaiNgu>();
            nghienCuuSinhDaHuongDan = new HashSet<NghienCuuSinhDaHuongDan>();
            chiTietKyLuat = new HashSet<ChiTietKyLuat>();
            chiTietKhenThuong = new HashSet<ChiTietKhenThuong>();
            chiTietQuaTrinhCongTac = new HashSet<ChiTietQuaTrinhCongTac>();
            chiTietCongTrinhKH_CN = new HashSet<ChiTietCongTrinhKH_CN>();
            chiTietDeTaiDuAnKHCNThamGia = new HashSet<ChiTietDeTaiDuAnKHCNThamGia>();
            deTaiDuAnKHCNChuTri = new HashSet<DeTaiDuAnKHCNChuTri>();
            congTrinhVaKetQuaNghienCuuDuocApDung = new HashSet<CongTrinhVaKetQuaNghienCuuDuocApDung>();
            chiTietVanBang = new HashSet<ChiTietVanBang>();
        }
    }
}
