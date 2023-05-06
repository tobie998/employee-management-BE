using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class KhenThuong
    {
        [Key]
        public int Makhenthuong { get; set; }
        [Required]
        public string Tenkhenthuong { get; set; }
    }
}
