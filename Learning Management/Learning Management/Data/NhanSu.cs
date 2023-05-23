using System.ComponentModel.DataAnnotations;

namespace Learning_Management.Data
{
    public class NhanSu
    {
        [Key]
        public string Manhansu { get; set; }
        [MaxLength(50)]
        public string Tennhansu { get; set; }
        [MaxLength(100)]
        public string Diachi { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Chucvu { get; set; }
        public int isDelete { get; set; } = 0;


    }
}
