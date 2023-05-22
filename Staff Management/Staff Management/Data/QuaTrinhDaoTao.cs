using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class QuaTrinhDaoTao
    {
        [Key]
        public string Mabacdaotao { get; set; }
        [Required]
        public string Bacdaotao { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietQuaTrinhDaoTao> chiTietQuaTrinhDaoTaos { get; set; }
        public QuaTrinhDaoTao()
        {
            chiTietQuaTrinhDaoTaos = new HashSet<ChiTietQuaTrinhDaoTao>();
        }
    }
}
