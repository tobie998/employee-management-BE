using System.ComponentModel.DataAnnotations;

namespace StaffManage.Models
{
    public class CanBoModel
    {
        [Key]
        public String Macanbo { get; set; }
        public int Madonvi { get; set; }
        public string Hoten { get; set; }
        public int Namsinh { get; set; }
        public bool Gioitinh { get; set; }
        public string Hocham { get; set; }
        public string Hocvi { get; set; }
        public int Namhocham { get; set; }
        public int Namhocvi { get; set; }
        public string Diachinharieng { get; set; }
        public string Dienthoainharieng { get; set; }
        public string Dienthoaicoquan { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public string Bacluong { get; set; }
        public double Luongcoban { get; set; }

    }
}
