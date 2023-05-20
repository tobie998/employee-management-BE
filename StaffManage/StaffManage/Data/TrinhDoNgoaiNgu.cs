using System.ComponentModel.DataAnnotations;

namespace StaffManage.Data
{
    public class TrinhDoNgoaiNgu
    {
        [Key]
        public int Mangoaingu { get; set; }
        [Required]
        public string Tenngoaingu { get; set; }
        public int isDelete { get; set; } = 0;

        public ICollection<ChiTietTrinhDoNgoaiNgu> chiTietTrinhDoNgoaiNgu { get; set; }
        public TrinhDoNgoaiNgu()
        {
            chiTietTrinhDoNgoaiNgu = new HashSet<ChiTietTrinhDoNgoaiNgu>();
        }
    }
}
