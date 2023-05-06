using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChucDanh
    {
        [Key]
        public int Machucdanh { get; set; }
        [Required]
        public string Tenchucdanh { get; set; }
    }
}
