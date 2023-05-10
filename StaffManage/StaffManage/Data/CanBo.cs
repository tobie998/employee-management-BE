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
        public int Namsinh { get; set;}
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

        public int Madonvi { get; set;}

        [ForeignKey("Madonvi")]
        public DonVi DonVi { get; set; }

        public ICollection<ChiTietGiaiThuong> chiTietGiaiThuongs { get; set; }
        public ICollection<ChiTietLinhVucNghienCuu> chiTietLinhVucNghienCuu { get; set; }
        public ICollection<ChiTietChucVu> chiTietChucVus { get; set; }
        public ICollection<ChiTietChucDanh> chiTietChucDanhs { get; set; }
        public ICollection<ChiTietQuaTrinhDaoTao> chiTietQuaTrinhDaoTaos { get; set; }
        public ICollection<ChiTietVeKinhNghiemKH_CN> chiTietVeKinhNghiemKH_CNs { get; set; }
        public CanBo()
        {
            chiTietGiaiThuongs = new HashSet<ChiTietGiaiThuong>();
            chiTietLinhVucNghienCuu = new HashSet<ChiTietLinhVucNghienCuu>();
            chiTietChucVus = new HashSet<ChiTietChucVu>();
            chiTietChucDanhs = new HashSet<ChiTietChucDanh>();
            chiTietQuaTrinhDaoTaos = new HashSet<ChiTietQuaTrinhDaoTao>();
            chiTietVeKinhNghiemKH_CNs = new HashSet<ChiTietVeKinhNghiemKH_CN>();
        }
    }
}
