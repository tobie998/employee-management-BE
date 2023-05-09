using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class QuaTrinhDaoTao
    {
        [Key]
        public int Mabacdaotao { get; set; }
        [Required]
        public string Bacdaotao { get; set; }
        public ICollection<ChiTietQuaTrinhDaoTao> chiTietQuaTrinhDaoTaos { get; set; }
        public QuaTrinhDaoTao()
        {
            chiTietQuaTrinhDaoTaos = new HashSet<ChiTietQuaTrinhDaoTao>();
        }
    }
}
