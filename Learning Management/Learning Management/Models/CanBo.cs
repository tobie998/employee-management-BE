using System.ComponentModel.DataAnnotations;

namespace Learning_Management.Models
{
    public class CanBo
    {
        public string MaNhanSu { get; set; }
        public string TenNhanSu { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public int isDelete { get; set; } 
    }
}
