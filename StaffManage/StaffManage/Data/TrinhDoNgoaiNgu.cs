using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class TrinhDoNgoaiNgu
    {
        [Key]
        public int Mangoaingu { get; set; }
        [Required]
        public string Tenngoaingu { get; set; }
    }
}
