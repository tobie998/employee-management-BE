namespace Staff_Management.Models
{
    public class QuanLyDaoTao
    {
        public string MaNhanSu { get; set; }
        public string TenNhanSu { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string ChucVu { get; set; }
        public int isDelete { get; set; } = 0;
    }
}
