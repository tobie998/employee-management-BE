using System.ComponentModel.DataAnnotations;

namespace Researcher_Management.Data
{
    public class CanBoNghienCuu
    {
        [Key]
        public string Macanbonghiencuu { get; set; }
        [MaxLength(50)]
        public string Chunhiemdetai { get; set; }
        [MaxLength(50)]
        public string Chucdanhnghenghiep { get; set; }
        public string Hocham { get; set; }
        [MaxLength(15)]
        public string Dienthoai { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public string Khoacongtac { get; set; }
        public int isDelete { get; set; } = 0;

    }
}
