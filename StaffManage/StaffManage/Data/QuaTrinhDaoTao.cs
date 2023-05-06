using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class QuaTrinhDaoTao
    {
        [Key]
        public int Mabacdaotao { get; set; }
        [Required]
        public string Bacdaotao { get; set; }
    }
}
