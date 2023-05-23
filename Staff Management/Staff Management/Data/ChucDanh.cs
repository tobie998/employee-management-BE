using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class ChucDanh
    {
        [Key]
        public string Machucdanh { get; set; }
        [Required]
        public string Tenchucdanh { get; set; }
        public int isDelete { get; set; } = 0;

    }
}
